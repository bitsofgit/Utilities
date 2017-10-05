using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Encodings
    {
        public static void Run()
        {
            //string str = "水";
            string str = "cat";

            Console.WriteLine("STRING: " + str);

            byte[] bytesAscii = ConvertStrToAscii(str);
            string strAscii = ConvertAsciiToStr(bytesAscii);

            byte[] bytesUTF8 = ConvertStrToUTF8(str);
            string strUTF8 = ConvertUTF8ToStr(bytesUTF8);

            byte[] bytesUnicode = ConvertStrToUnicode(str);
            string strUnicode = ConvertUnicodeToStr(bytesUnicode);

            byte[] bytesUTF32 = ConvertStrToUTF32(str);
            string strUTF32 = ConvertUTF32ToStr(bytesUTF32);

            string base64string = ConvertStrToBase64EncodedString(str);
            string s = ConvertBase64EncodedStringToStr(base64string);
        }

        /* ASCII */
        public static byte[] ConvertStrToAscii(string str)
        {
            Console.WriteLine();
            Console.WriteLine("CONVERT STRING TO ASCII");
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            PrintBytes(bytes);
            return bytes;
        }

        public static string ConvertAsciiToStr(byte[] bytes)
        {
            Console.WriteLine();
            Console.WriteLine("CONVERT ASCII TO STRING");
            string str = Encoding.ASCII.GetString(bytes);
            Console.WriteLine(str);
            return str;
        }

        /* UTF-8 */
        private static byte[] ConvertStrToUTF8(string str)
        {
            Console.WriteLine();
            Console.WriteLine("CONVERT STRING TO UTF-8");
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            PrintBytes(bytes);
            return bytes;
        }

        private static string ConvertUTF8ToStr(byte[] bytes)
        {
            Console.WriteLine();
            Console.WriteLine("CONVERT UTF-8 TO STRING");
            string str = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(str);
            return str;
        }

        /* UNICODE = UTF-16 */
        private static byte[] ConvertStrToUnicode(string str)
        {
            Console.WriteLine();
            Console.WriteLine("CONVERT STRING TO UNICODE=UTF-16");
            byte[] bytes = Encoding.Unicode.GetBytes(str);
            PrintBytes(bytes);
            return bytes;
        }

        private static string ConvertUnicodeToStr(byte[] bytes)
        {
            Console.WriteLine();
            Console.WriteLine("CONVERT UNICODE=UTF-16 TO STRING");
            string str = Encoding.Unicode.GetString(bytes);
            Console.WriteLine(str);
            return str;
        }

        /* UTF-32 */
        private static byte[] ConvertStrToUTF32(string str)
        {
            Console.WriteLine();
            Console.WriteLine("CONVERT STRING TO UTF-32");
            byte[] bytes = Encoding.UTF32.GetBytes(str);
            PrintBytes(bytes);
            return bytes;
        }

        private static string ConvertUTF32ToStr(byte[] bytes)
        {
            Console.WriteLine();
            Console.WriteLine("CONVERT UTF-32 TO STRING");
            string str = Encoding.UTF32.GetString(bytes);
            Console.WriteLine(str);
            return str;
        }

        /* Base 64 Encoding */
        private static string ConvertStrToBase64EncodedString(string str)
        {
            Console.WriteLine();
            Console.WriteLine("CONVERT STRING TO BASE-64 ENCODING");
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            string base64str = Convert.ToBase64String(bytes);
            Console.WriteLine(base64str);
            return base64str;
        }

        private static string ConvertBase64EncodedStringToStr(string str)
        {
            Console.WriteLine();
            Console.WriteLine("CONVERT STRING TO BASE-64 ENCODING");
            byte[] bytes = System.Convert.FromBase64String(str);
            string s = Encoding.ASCII.GetString(bytes);
            Console.WriteLine(s);
            return s;
        }

        /* HELPERS */
        private static void PrintBytes(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                Console.Write(b);
                Console.Write("  ");
            }
            Console.WriteLine();
            Console.WriteLine("LENGTH: " + bytes.Length);
        }
    }
}
