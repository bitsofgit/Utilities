using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Anagram
    {
        private static Dictionary<char, long> dict = new Dictionary<char, long>();
        /// A word, phrase, or name formed by rearranging the letters of another, such as cinema, formed from iceman.
        public static void Menu()
        {
            Console.WriteLine("Enter string 1...");
            var str1 = Console.ReadLine();

            Console.WriteLine("Enter string 2...");
            var str2 = Console.ReadLine();

            PopulatePrimeDict();
            if(AreStringsAnagram(str1, str2))
                Console.WriteLine(string.Format("{0} and {1} are anagrams.", str1, str2));
            else
                Console.WriteLine(string.Format("{0} and {1} are not anagrams.", str1, str2));
        }

        private static void PopulatePrimeDict()
        {
            // add first 26 primes
            List<long> primes = new List<long>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 };
            
            // Ascii codes for a-z is 97-122
            for (int i=0;i<26;i++)
            {
                dict.Add(Convert.ToChar(i + 97), primes[i]);
            }
        }

        private static bool AreStringsAnagram(string str1, string str2)
        {
            if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2))
                return false;

            var left = str1.ToLower();
            var right = str2.ToLower();
            long leftProduct = 1;
            long rightProduct = 1;
            foreach(char c in left)
            {
                leftProduct = dict[c] * leftProduct;
            }

            foreach(char c in right)
            {
                rightProduct = dict[c] * rightProduct;
            }

            return leftProduct == rightProduct;
        }
    }
}
