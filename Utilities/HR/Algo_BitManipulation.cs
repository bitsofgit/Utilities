using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Utilities.HR
{
    public static class Algo_BitManipulation
    {
        public static void Test()
        {
            //LonelyInteger();
            //MaximizingXOR();
            CounterGame();
        }

        private static void CounterGame()
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            if (testCases < 1 || testCases > 10)
                throw new Exception("Invalid argument");

            long[] ns = new long[testCases];
            for (int i = 0; i < testCases; i++)
            {
                long val = Convert.ToInt64(Console.ReadLine());
                if (val < 1 || val > Math.Pow(2, 64) - 1)
                    throw new Exception("Invalid argument");

                ns[i] = val;
            }

            long[] vals = new long[64];
            for(int i = 1; i <= 64; i++)
            {
                vals[i-1] = (long)Math.Pow(2, i);
            }

            foreach (var n in ns)
            {
                long tempn = n;
                int counter = 1;
                while (tempn != 1)
                {
                    counter++;
                    if (IsPowerOf2(tempn))
                    {
                        tempn = tempn / 2;
                    }
                    else
                    {
                        tempn = tempn - HighestPowerof2(tempn, vals);
                    }
                }

                if (counter % 2 == 0)
                    Console.WriteLine("Louise");
                else
                    Console.WriteLine("Richard");
            }
        }

        private static long HighestPowerof2(long tempn, long[] vals)
        {
            return vals.Where(n => n < tempn).Max();
            
        }

        private static bool IsPowerOf2(long tempn)
        {
            return (tempn & (tempn - 1)) == 0;
        }

        private static void MaximizingXOR()
        {
            int res = 0;
            int _l;
            _l = Convert.ToInt32(Console.ReadLine());

            int _r;
            _r = Convert.ToInt32(Console.ReadLine());

            for (int i = _l; i <= _r; i++)
            {
                for(int j = _l + 1; j <= _r; j++)
                {
                    int xor = i ^ j;
                    if (xor > res)
                        res = xor;
                }
            }
            Console.WriteLine(res);
        }

        private static void LonelyInteger()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            //int res = 0;
            //foreach(var i in a)
            //{
            //    res = res ^ i; // idea is that XOR will result in all matching bits cancelling each othe out and only the unique one will remain
            //}
            //Console.WriteLine(res);

            Array.Sort(a);
            int result = -1;
            for (int i = 0; i < n; i = i + 2)
            {
                if (i == n - 1 || a[i] != a[i + 1])
                {
                    result = a[i];
                    break;
                }
            }

            if (result != -1)
                Console.WriteLine(result);
            else
                Console.WriteLine("Wrong data");

        }
    }
}
