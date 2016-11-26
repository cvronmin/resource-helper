using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMKJK
{
    public class CRMKJK
    {
        static Random rand = new Random();
        public static string EncodeEasy (string src, int state = 0)
        {
            return Encode(src, rand, state);
        }
        public static string Encode (string src, int seed, int state = 0)
        {
            return Encode(src, new Random(seed), state);
        }
        public static string Encode (string src, Random rand, int state = 0)
        {
            if (string.IsNullOrWhiteSpace(src)) return "";
            bool unicode = false, etb64e = false;
            HashSet<char> set = new HashSet<char>();
            if (!src.IsASCII() || (state & CRMKJKState.Unicode) != 0)
            {
                src = src.EscapeToUnicode();
                unicode = true;
            }
            if ((state & CRMKJKState.EncodeTextB64Encode) != 0) etb64e = true;
            char[] chars = src.ToCharArray();
            foreach (var item in chars)
            {
                set.Add(item);
            }
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
                int j = -1;
                while ((j = src.IndexOf(origin[i], j == -1 ? 0 : j)) != -1)
                {
                    enchant[j] = encoded[i];
                    j++;
                }
            }
            byte[] benchant = Encoding.Unicode.GetBytes(enchant);
            byte[] bencoded = Encoding.Unicode.GetBytes(encoded);
            byte[] borigin = Encoding.Unicode.GetBytes(origin);
            string fullencoded = Encoding.Unicode.GetString(borigin, 0, borigin.Length) + Encoding.Unicode.GetString(bencoded, 0, bencoded.Length);
            int fullencodedre = 0;
            if (etb64e)
            {
                fullencoded = Convert.ToBase64String(Encoding.Unicode.GetBytes(string.Format("{0:000}", encodeRequired) + "=" + fullencoded));
                fullencodedre = fullencoded.Length;
            }
            string full = fullencoded + Encoding.Unicode.GetString(benchant, 0, benchant.Length);
            return (etb64e ? "b" : "") + (unicode ? "u" : "") + string.Format(etb64e ? "{0:0000000000}" : "{0:000}", etb64e ? fullencodedre : encodeRequired) + "=" + full;
        }

        public static string Decode (string src)
        {
            if (string.IsNullOrWhiteSpace(src)) return "";
            var match = System.Text.RegularExpressions.Regex.Match(src, "(b)?(u)?(\\d{3,10}?(?==))");
            if (!match.Success)
            {
                throw new UnexpectedCRMKJKEncodeException();
            }
            bool encodeTextB64Encoded = match.Groups[1].Success, unicode = match.Groups[2].Success;
            int encodeRequired = Convert.ToInt32(match.Groups[3].Value);
            src = System.Text.RegularExpressions.Regex.Replace(src, "(b)?(u)?(\\d{3,10}=)", "");
            if (encodeTextB64Encoded)
            {
                string tmp1 = src.Substring(0, encodeRequired);
                var a = Convert.FromBase64String(tmp1);
                try
                {
                    tmp1 = Encoding.Unicode.GetString(a, 0, a.Length);
                    var regex = System.Text.RegularExpressions.Regex.Match(tmp1, "(\\d{3}?(?==))");
                    if (regex.Success)
                    {
                        src =  tmp1 + src.Substring(encodeRequired);
                        src = System.Text.RegularExpressions.Regex.Replace(src, "(\\d{3}=)", "");
                        encodeRequired = Convert.ToInt32(regex.Value);
                    }
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
                int j = -1;
                while ((j = yummystring.IndexOf(encode[i], j == -1 ? 0 : j)) != -1)
                {
                    enchant[j] = origin[i];
                    j++;
                }
            }
            byte[] benchant = Encoding.Unicode.GetBytes(enchant);
            string result = Encoding.Unicode.GetString(benchant, 0, benchant.Length);
            if (unicode) result = result.TrapToUnicode();
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
            string dst = "";
            char[] src = value.ToCharArray();
            for (int i = 0; i < src.Length; i++)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(src[i].ToString());
                string str = @"\u" + bytes[1].ToString("X2") + bytes[0].ToString("X2");
                dst += str;
            }
            return dst;
        }

        public static string TrapToUnicode (this string value)
        {
            string dst = "";
            string src = value;
            int len = value.Length / 6;

            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes, 0, 2);
            }
            return dst;
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
                a[i - 1] = k;
                b[j] = b[i - 1];
                b[i - 1] = k1;
            }
        }
    }
}