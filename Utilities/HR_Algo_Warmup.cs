using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class HR_Algo_Warmup
    {
        public static void Test()
        {
            //Test1();
            //Test2();
            //PrintStairCase();
            //MinMaxSum();
            //BirthdayCandles();
            MillitaryTime();

        }

        private static void MillitaryTime()
        {
            string s = Console.ReadLine();
            string result = TimeConversion(s);
            Console.WriteLine(result);
        }

        private static string TimeConversion(string s)
        {
            DateTime dt = new DateTime();
            if (!DateTime.TryParse(s, out dt))
                throw new Exception("Invalid date time passed.");

            return dt.ToString("HH:mm:ss"); // using capital HH makes it 24 hour format
        }

        private static void BirthdayCandles()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n < 1 || n > 100000)
                throw new Exception("Invalid argument.");

            string[] ar_temp = Console.ReadLine().Split(' ');
            int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
            if (ar.Length != n)
                throw new Exception("Array length doesnt match the value provided.");

            foreach (var i in ar)
            {
                if (i < 1 || i > 10000000)
                    throw new Exception("Invalid argument.");
            }

            int max = ar.Max();
            int result = ar.Count(i => i == max);

            Console.WriteLine(result);
        }

        private static void MinMaxSum()
        {
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

            long sum = 0;
            int min = Int32.MaxValue;
            int max = 0;
            foreach (var i in arr)
            {
                sum = sum + i;
                if (i < min)
                    min = i;

                if (i > max)
                    max = i;
            }
            long first = sum - max;
            long second = sum - min;
            Console.WriteLine(first + " " + second);
        }

        private static void PrintStairCase()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (var i = 1; i <= n; i++)
            {
                Console.WriteLine(GetString(n - i, ' ') + GetString(i, '#'));
            }
        }

        private static string GetString(int count, char c)
        {
            string str = string.Empty;
            for (var i = 0; i < count; i++)
            {
                str = str + c.ToString();
            }
            return str;
        }

        private static void Test1()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0)
                throw new Exception("Invalid value");

            int[,] a = new int[n, n];
            for (int a_i = 0; a_i < n; a_i++)
            {
                string[] a_temp = Console.ReadLine().Split(' ');
                for (int col = 0; col < n; col++)
                {
                    int i = Int32.Parse(a_temp[col]);
                    if (i < -100 || i > 100)
                        throw new Exception("Invalid input value");

                    a[a_i, col] = i;
                }
            }

            int result = GetAbsDiffForDiagonals(n, a);
            Console.WriteLine(result);
        }

        private static int GetAbsDiffForDiagonals(int n, int[,] a)
        {
            int leftSum = 0;
            int rightSum = 0;
            for (int row = 0; row < n; row++)
            {
                leftSum = leftSum + a[row, row];
                rightSum = rightSum + a[row, n - 1 - row];
            }

            return Math.Abs(leftSum - rightSum);

        }

        private static void Test2()
        {
            // HR: Algorithms, Warmup, Plus Minus
            int n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0)
                throw new Exception("Invalid array provided.");

            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

            if (n != arr.Length)
                throw new Exception("Length doesnt match the count provided.");

            double pos = 0;
            double neg = 0;
            double zeroes = 0;

            foreach (var i in arr)
            {
                if (i == 0)
                {
                    zeroes++;
                    continue;
                }

                if (i > 0)
                {
                    pos++;
                    continue;
                }

                if (i < 0)
                {
                    neg++;
                }
            }

            double posFraction = pos / n;
            double negFraction = neg / n;
            double zeroFraction = zeroes / n;
            Console.WriteLine(posFraction);
            Console.WriteLine(negFraction);
            Console.WriteLine(zeroFraction);
        }
    }
}
