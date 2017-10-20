using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class HR_Algo_Strings
    {
        static string result = string.Empty;
        public static void Test()
        {
            SuperReducedString();
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
