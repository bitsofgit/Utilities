using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.CCI
{
    public static class ArraysAndStrings
    {
        public static void Test()
        {
            Test1();
        }

        private static void Test1()
        {
            // determine if a string has all unique characters without using new data structure
            string s = Console.ReadLine();
            Console.WriteLine(s.HasUniqueASCIIChars());
        }

        private static bool HasUniqueASCIIChars(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            // assume ascii so total 256 chars, unicode allows for more than 1M characters
            // if string length is greater than 256 print false
            if (s.Length > 256) return false;

            bool[] arr = new bool[256];
            for (int i = 0; i < s.Length; i++)
            {
                Int16 val = (Int16)s[i];
                if (arr[val] == true)
                    return false;
                else
                    arr[val] = true;
            }

            return true;
        }
    }
}
