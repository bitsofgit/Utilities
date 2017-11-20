using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.HR
{
    public static class Algo_Recursion
    {
        public static void Test()
        {
            PowerSum();
        }

        private static void PowerSum()
        {
            int x = Int32.Parse(Console.ReadLine());
            if (x < 1 || x > 1000)
                throw new Exception("Invalid argument");
            int n = Int32.Parse(Console.ReadLine());
            if (n < 2 || n > 10)
                throw new Exception("Invalid argument");

            int result = 0;
            result = result + TotalNum(x, n, 1);
            
            Console.WriteLine(result);
        }

        private static int TotalNum(int x, int n, int num)
        {
            if (IntPower(num, n) < x)
                return TotalNum(x, n, num + 1) + TotalNum(x - IntPower(num, n), n, num + 1);
            else if (IntPower(num, n) == x)
                return 1;
            else
                return 0;
        }

        private static int IntPower(int x, int n)
        {
            return Convert.ToInt32(Math.Pow(x, n));
        }
    }
}
