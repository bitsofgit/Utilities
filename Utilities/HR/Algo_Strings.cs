using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.HR
{
    public static class Algo_Strings
    {
        static string result = string.Empty;
        public static void Test()
        {
            //SuperReducedString();
            //camelCase();
            //TwoCharacters(); --not completed yet
        }

        private static void TwoCharacters()
        {
            int len = Convert.ToInt32(Console.ReadLine());
            string s = Console.ReadLine();
            if (len != s.Length)
                throw new Exception("invalid argument");


        }

        private static List<string> UniqueCharacters(string s)
        {
            if (string.IsNullOrEmpty(s))
                return new List<string>();

            List<string> uniques = new List<string>();
            for(int i = 0; i < s.Length; i++)
            {
                string c = s[i].ToString();
                if (!uniques.Contains(c))
                    uniques.Add(c);
            }
            return uniques;
        }

        private static bool IsValidString(string s)
        {
            var list = UniqueCharacters(s);
            if (list.Count != 2)
                return false;

            var first = list[0];
            var second = list[1];
            if (first == second)
                return false;

            return true;
        }

        private static void camelCase()
        {
            string s = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(s) || s.Length > 100000)
                throw new Exception("Invalid argument");

            int countOfWords = 1;

            var arr = s.ToCharArray();
            foreach(var c in arr)
            {
                if (char.IsUpper(c))
                    countOfWords++;
            }

            Console.WriteLine(countOfWords);
        }

        private static void SuperReducedString()
        {
            string s = Console.ReadLine();
            super_reduced_string(s);

            if (string.IsNullOrWhiteSpace(result))
                Console.WriteLine("Empty String");
            else
                Console.WriteLine(result);
        }

        private static void super_reduced_string(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                result = string.Empty;
                return;
            }

            if (str.Length < 1 || str.Length > 100)
                throw new Exception("Invalid Argument");

            bool f = true;
            result = str;
            while (f)
            {
                f = FindAndReplaceAdjacentChars();
            }
        }

        private static bool FindAndReplaceAdjacentChars()
        {
            if (string.IsNullOrWhiteSpace(result))
            {
                return false;
            }

            char[] arr = result.ToCharArray();
            if (arr.Length == 1)
            {
                return false;
            }

            bool found = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    result = result.Remove(i, 2);
                    found = true;
                    break;
                }
            }

            return found;
        }
    }
}
