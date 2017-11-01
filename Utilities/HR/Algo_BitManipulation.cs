using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.HR
{
    public static class Algo_BitManipulation
    {
        public static void Test()
        {
            //LonelyInteger();
            MaximizingXOR();
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
