using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Utilities.CCI
{
    public static class ArraysAndStrings
    {
        public static void Test()
        {
            //Test1();
            //Test2();
            //Test3();
            //Test4();
            Test5();
        }

        private static void Test5()
        {
            // compress strings for ex. aabccccaaa would become a2b1c4a3
            // if no compression return original
            string s = Console.ReadLine();
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Empty string.");
                return;
            }

            var compressedString = new StringBuilder();
            int length = s.Length;
            for (int i = 0; i < length; i++)
            {
                char c = s[i];
                int count = 1;
                int j = 0;
                for (j = i+1; j < length; j++)
                {
                    if (c == s[j])
                    {
                        count++;
                        i++;
                    }
                    else
                        break;
                }
                compressedString.Append(c.ToString() + count);
            }

            if (compressedString.ToString().Length >= length)
                Console.WriteLine(s);
            else
                Console.WriteLine(compressedString.ToString());
        }

        private static void Test4()
        {
            // method to replace all space in a string with %20
            string s = Console.ReadLine();
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Empty string.");
                return;
            }

            var replacedStr = s.Replace(" ", "%20");

            Console.WriteLine(replacedStr);
        }

        private static void Test3()
        {
            // Given 2 strings write a method to see if one is a permutation or other
            // assume ascii and character insensitive and spaces are important
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            Console.WriteLine(ArePermutedStrings(s1, s2));
        }

        private static bool ArePermutedStrings(string s1, string s2)
        {
            // permutation: same length, same characters different order
            if (s1.Length != s2.Length)
                return false;

            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return false;

            string sortedS1 = String.Concat(s1.OrderBy(c => c));
            string sortedS2 = String.Concat(s2.OrderBy(c => c));

            return sortedS1.ToUpper() == sortedS2.ToUpper();
        }

        private static void Test2()
        {
            string s = Console.ReadLine();
            Console.WriteLine(s.Reverse());
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
