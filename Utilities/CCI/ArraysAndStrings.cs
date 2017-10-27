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
            //Test5();
            //Test6();
            //Test7();
            Test8();
        }

        private static void Test8()
        {
            // given 2 strings s1 and s2 write code to check if s2 is a rotation of s1 using only one call to contains method
            // rotation: erbottlewat is a rotation of waterbottle
            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();

            if (s1.Length != s2.Length)
                Console.WriteLine("Is not a rotation");

            var temp = s1 + s1; // s1 + s1 will always include s2 if it is a rotation
            if(temp.Contains(s2))
                Console.WriteLine("Is rotation");
            else
                Console.WriteLine("Is not a rotation");

        }

        private static void Test6()
        {
            // given an image in an NxN matrix, where each pixel is 4 bytes, write a method to rotate the image by 90deg (in place is better)
            int n = Int32.Parse(Console.ReadLine());
            var arr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = Int32.Parse(Console.ReadLine());
                }
            }
            PrintArray(arr);
            
            var newArr = Rotate90DegClockwise(arr);
            Console.WriteLine();
            PrintArray(newArr);
        }

        private static int[,] Rotate90DegClockwise(int[,] arr)
        {
            // first row becomes last column and so on

            int n = arr.GetLength(0);
            var newArr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    newArr[j, n - 1 - i] = arr[i, j];
                }
            }

            return newArr;
        }

        private static void Test7()
        {
            // write an algorithm such that if an element in a mxn matrix is 0 entire row and column are set to 0
            int m = Int32.Parse(Console.ReadLine());
            int n = Int32.Parse(Console.ReadLine());
            var arr = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = Int32.Parse(Console.ReadLine());
                }
            }
            PrintArray(arr);

            var newArr = FindAndReplace0(arr);

            PrintArray(newArr);

        }

        private static int[,] FindAndReplace0(int[,] arr)
        {
            var rows = new List<int>();
            var cols = new List<int>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (rows.Contains(i) || cols.Contains(j))
                    {
                        arr[i, j] = 0;
                    }
                }
            }

            return arr;
        }

        private static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "    ");
                }
                Console.WriteLine();
            }
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
                for (j = i + 1; j < length; j++)
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
