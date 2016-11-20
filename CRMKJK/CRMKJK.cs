using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMKJK
{
    public class CRMKJK
    {
        static Random rand = new Random();
        public static string Encode(string src)
        {
            return Encode(src, rand);
        }
        public static string Encode(string src, int seed)
        {
            return Encode(src, new Random(seed));
        }
        public static string Encode(string src, Random rand)
        {
            if (string.IsNullOrWhiteSpace(src)) return "";
            bool unicode = false;
            HashSet<char> set = new HashSet<char>();
            if (!src.IsASCII())
            {
                src = src.EscapeToUnicode();
                unicode = true;
            }
            char[] chars = src.ToCharArray();
            foreach (var item in chars)
            {
                set.Add(item);
            }
            int encodeRequired = set.Count;
            HashSet<byte> kjk = new HashSet<byte>();
            while (kjk.Count < encodeRequired)
            {
                kjk.Add((byte)rand.Next(32, 96));
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
            return (unicode ? "u" : "") + string.Format("{0:000}", encodeRequired) + "=" + Encoding.Unicode.GetString(borigin, 0, borigin.Length) + Encoding.Unicode.GetString(bencoded, 0 ,bencoded.Length) + Encoding.Unicode.GetString(benchant, 0, benchant.Length);
        }

        public static string Decode(string src)
        {
            if (string.IsNullOrWhiteSpace(src)) return "";
            var match = System.Text.RegularExpressions.Regex.Match(src, "(u)?(\\d{3}(?==))");
            if (!match.Success)
            {
                throw new UnexpectedCRMKJKEncodeException();
            }
            bool unicode = match.Groups[1].Success;
            int encodeRequired = Convert.ToInt32(match.Groups[2].Value);
            src = System.Text.RegularExpressions.Regex.Replace(src, "(u)?(\\d{3}=)", "");
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
            string result = Encoding.Unicode.GetString(benchant, 0 ,benchant.Length);
            if (unicode) result = result.TrapToUnicode();
            return result;
        }
    }
    static class Helper
    {
        /**
         * source: http://snipplr.com/view/35806/
         */
        public static bool IsASCII(this string value)
        {
            // ASCII encoding replaces non-ascii with question marks, so we use UTF8 to see if multi-byte sequences are there
            return Encoding.UTF8.GetByteCount(value) == value.Length;
        }

        public static string EscapeToUnicode(this string value)
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

        public static string TrapToUnicode(this string value)
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

        public static void Shuffle<T>(ref T[] a, ref T[] b)
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