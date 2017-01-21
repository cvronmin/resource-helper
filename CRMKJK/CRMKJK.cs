using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace CRMKJK
{
    public class CRMKJK
    {
        static Random rand = new Random();
        public static string EncodeEasy (string src, int state = 0)
        {
            return Encode(src, rand, Encoding.Unicode, state);
        }
        public static string EncodeEasy (string src, Encoding encoding, int state = 0)
        {
            return Encode(src, rand, encoding, state);
        }
        public static string Encode (string src, int seed, int state = 0)
        {
            return Encode(src, new Random(seed), Encoding.Unicode, state);
        }
        public static string Encode (string src, int seed, Encoding encoding, int state = 0)
        {
            return Encode(src, new Random(seed), encoding, state);
        }
        public static string Encode (string src, Random rand, int state = 0) {
            return Encode(src, rand, Encoding.Unicode, state);
        }
        public static string Encode (string src, Random rand, Encoding encoding, int state = 0)
        {
            if (string.IsNullOrWhiteSpace(src)) return "";
            bool unicode = false, etb64e = false;
            if (!src.IsASCII() || (state & CRMKJKState.Unicode) != 0)
            {
                src = src.EscapeToUnicode();
                unicode = true;
            }
            if ((state & CRMKJKState.EncodeTextB64Encode) != 0) etb64e = true;
            char[] chars = src.ToCharArray();
            HashSet<char> set = new HashSet<char>(chars.Distinct());
            int encodeRequired = set.Count;
            HashSet<byte> kjk = new HashSet<byte>();
            while (kjk.Count < encodeRequired)
            {
                kjk.Add((byte) rand.Next(32, 96));
            }
            char[] encoded = Encoding.UTF8.GetChars(kjk.ToArray());
            char[] origin = set.ToArray();
            Helper.Shuffle(ref encoded, ref origin);
            char[] enchant = new char[src.Length];
            
            for (int i = 0; i < encoded.Length; i++)
            {
                var enuma = src.IndexesOf(origin[i]);
                foreach (var indices in enuma)
                {
                    enchant[indices] = encoded[i];
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(new string(origin)).Append(new string(encoded));
            int fullencodedre = 0;
            if (etb64e)
            {
                string tmp = Convert.ToBase64String(encoding.GetBytes(string.Format("{0:000}", encodeRequired) + "=" + sb.ToString()));
                sb.Clear().Append(tmp);
                fullencodedre = sb.Length;
            }
            sb.Append(new string(enchant));
            bool zip = false;
            if (sb.Length > 0x80000) { //Too large for data storage
                zip = true;
                string zipped = Helper.ZipString(sb.ToString());
                sb.Clear().Append(zipped);
            }
            sb.Insert(0, '=').Insert(0, string.Format(etb64e ? "{0:00000}" : "{0:000}", etb64e ? fullencodedre : encodeRequired));
            sb.Insert(0, (zip ? "z" : "")).Insert(0, (unicode ? "u" : "")).Insert(0, (etb64e ? "b" : ""));
            set.Clear(); kjk.Clear();
            set = null;kjk = null;
            enchant = encoded = origin = null;
            return sb.ToString();
        }
        public static string Decode (string src) {
            return Decode(src, Encoding.Unicode);
        }
        public static string Decode (string src, Encoding encoding)
        {
            if (string.IsNullOrWhiteSpace(src)) return "";
            var match = System.Text.RegularExpressions.Regex.Match(src, "(b)?(u)?(z)?(\\d{3,10}?(?==))");
            if (!match.Success)
            {
                throw new UnexpectedCRMKJKEncodeException();
            }
            bool encodeTextB64Encoded = match.Groups[1].Success,
                unicode = match.Groups[2].Success,
                zip = match.Groups[3].Success;
            int encodeRequired;
            try
            {

                encodeRequired = Convert.ToInt32(match.Groups[4].Value);
            }
            catch (FormatException e)
            {
                throw new UnexpectedCRMKJKEncodeException("Unexpected exception in converting", e);
            }
            match = null;
            var r = new System.Text.RegularExpressions.Regex("(b)?(u)?(z)?(\\d{3,10}=)");
            src = r.Replace(src, "", 1);
            if (zip) src = Helper.UnzipString(src);
            if (encodeTextB64Encoded)
            {
                string tmp1 = src.Substring(0, encodeRequired);
                var a = Convert.FromBase64String(tmp1);
                try
                {
                    tmp1 = encoding.GetString(a, 0, a.Length);
                    var regex = System.Text.RegularExpressions.Regex.Match(tmp1, "(\\d{3}?(?==))");
                    if (regex.Success)
                    {
                        src =  tmp1 + src.Substring(encodeRequired);
                        var re = new System.Text.RegularExpressions.Regex("(\\d{3}=)");
                        src = re.Replace(src , "", 1);
                        encodeRequired = Convert.ToInt32(regex.Value);
                    }
                    regex = null;
                }
                catch (Exception e)
                {

                    throw new UnexpectedCRMKJKEncodeException("", e);
                }

            }
            char[] oe = src.Substring(0, encodeRequired * 2).ToCharArray();
            char[] origin = new char[encodeRequired];
            char[] encode = new char[encodeRequired];
            Array.Copy(oe, encodeRequired, encode, 0, encodeRequired);
            Array.Copy(oe, 0, origin, 0, encodeRequired);
            string yummystring = src.Substring(encodeRequired * 2);
            char[] enchant = new char[yummystring.Length];
            for (int i = 0; i < origin.Length; i++)
            {
                var enuma = yummystring.IndexesOf(encode[i]);
                foreach (var indices in enuma)
                {
                    enchant[indices] = origin[i];
                }
            }
            string result = new string(enchant);
            if (unicode) result = result.TrapToUnicode();
            oe = origin = enchant = encode = null;
            return result;
        }
    }
    public static class CRMKJKState
    {
        public static readonly int Unicode = 0x1;
        public static readonly int EncodeTextB64Encode = 0x2;
    }
    public static class Helper
    {
        /**
         * source: http://snipplr.com/view/35806/
         */
        public static bool IsASCII (this string value)
        {
            // ASCII encoding replaces non-ascii with question marks, so we use UTF8 to see if multi-byte sequences are there
            return Encoding.UTF8.GetByteCount(value) == value.Length;
        }

        public static string EscapeToUnicode (this string value)
        {
            StringBuilder sb = new StringBuilder();
            char[] chars = value.ToCharArray();
            //byte[] bytes = Encoding.Unicode.GetBytes(value);
            for (int i = 0; i < chars.Length; i++)
            {
                byte[] cb = Encoding.Unicode.GetBytes(chars[i].ToString());
                sb.AppendFormat("\\u{0:X2}{1:X2}", cb[1], cb[0]);
            }
            /*for (int i = 0; i < bytes.Length; i+=2)
            {
                sb.AppendFormat("\\u{0:X2}{1:X2}", bytes[i + 1], bytes[i]);
            }*/
            return sb.ToString();
        }

        public static string TrapToUnicode (this string value)
        {
            string[] a = value.Split(new char[] { '\\','u' },StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < a.Length; i++)
            {
                byte[] bytes = new byte[2];
                a[i] = a[i].PadLeft(4, '0');
                bytes[1] = byte.Parse(int.Parse(a[i].Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(a[i].Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                sb.Append(Encoding.Unicode.GetString(bytes, 0, 2));
                bytes = null;
            }
            GC.Collect();
            return sb.ToString();
        }

        /**
         * src: http://stackoverflow.com/questions/7343465/compression-decompression-string-with-c-sharp
         **/
        public static string ZipString (string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    msi.CopyTo(gs);
                }

                return Convert.ToBase64String(mso.ToArray());
            }
        }

        /**
         * src: http://stackoverflow.com/questions/7343465/compression-decompression-string-with-c-sharp
         **/
        public static string UnzipString (string str)
        {
            byte[] bytes = Convert.FromBase64String(str);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    gs.CopyTo(mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray(), 0, (int) mso.Length);
            }
        }

        public static void Shuffle<T> (ref T[] a, ref T[] b)
        {
            Random r = new Random();
            for (int i = a.Length; i > 0; i--)
            {
                int j = r.Next(i);
                T k = a[j];
                T k1 = b[j];
                a[j] = a[i - 1];
                b[j] = b[i - 1];
                a[i - 1] = k;
                b[i - 1] = k1;
            }
        }
        public static IEnumerable<int> IndexesOf (this string src, char c) {
            if (string.IsNullOrEmpty(src)) throw new ArgumentNullException("src");
            for (int index = 0;; index++)
            {
                index = src.IndexOf(c,index);
                if (index == -1) break;
                yield return index;
            }
        }
    }
}