using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.HR
{
    public static class Algo_Greedy
    {
        public static void Test()
        {
            //MinAbsDiff();
            MarcsCakewalk();
        }

        private static void MarcsCakewalk()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] calories_temp = Console.ReadLine().Split(' ');
            int[] calories = Array.ConvertAll(calories_temp, Int32.Parse);

            Array.Sort(calories);
            Array.Reverse(calories);

            long miles = 0;
            for(int i=0;i<calories.Length;i++)
            {
                miles = miles + (calories[i] * (long)Math.Pow(2, i));
            }

            Console.WriteLine(miles);
        }

        private static void MinAbsDiff()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n < 2 || n > 100000)
                throw new Exception("Invalid Argument");

            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            int result = minimumAbsoluteDifference(n, arr);
            Console.WriteLine(result);
        }

        private static int minimumAbsoluteDifference(int n, int[] arr)
        {
            if(n != arr.Length)
                throw new Exception("Invalid Argument");

            if (arr.Distinct().Count() != n) return 0;

            // after sorting finding minimum absolute is just checking diff between consecutive pairs
            Array.Sort(arr);
            int minDiff = Int32.MaxValue;
            for (int i = 0; i < n - 1; i++)
            {
                var abs = Math.Abs(arr[i] - arr[i + 1]);
                if (minDiff > abs)
                    minDiff = abs;
            }

            return minDiff;
        }
    }
}
