using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class TestConsole
    {
        public static void Test()
        {
            //Test1();
            Test2();
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
