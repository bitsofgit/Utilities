using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.HR
{
    public class CustomComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            // The below commented out code actually performed slower
            //if (x.Length == y.Length) {
            //    return x.CompareTo(y);
            //}

            //if (x.Length < y.Length)
            //    return -1;
            //else
            //    return 1;

            if (x.Length != y.Length) return x.Length - y.Length;

            for (int i = 0; i < x.Length; i++)
            {
                char left = x[i];
                char right = y[i];
                if (left != right)
                    return left - right;
            }

            return 0;
        }
    }

    class Algo_Sorting
    {
        public static void Test()
        {
            BigSorting();
        }

        private static void BigSorting()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n < 1 || n > 200000)
                throw new Exception("Invalid argument");

            string[] unsorted = new string[n];
            for (int unsorted_i = 0; unsorted_i < n; unsorted_i++)
            {
                var str = Console.ReadLine();
                if (str.Length > 1000000)
                    throw new Exception("Invalid argument");

                unsorted[unsorted_i] = str;
            }

            var sorted = unsorted.OrderBy(str => str, new CustomComparer());
           
            foreach(var i in sorted)
            {
                Console.WriteLine(i);
            }
        }
    }
}
