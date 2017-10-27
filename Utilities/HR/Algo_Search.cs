using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.HR
{
    public static class Algo_Search
    {
        public static void Test()
        {
            while (true)
            {
                HackerlandRadioTransmitters();
                Console.WriteLine("-----------------");
            }
        }

        private static void HackerlandRadioTransmitters()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);

            if (n < 1 || n > 100000 || k < 1 || k > 100000)
                throw new Exception("Invalid argument");

            string[] x_temp = Console.ReadLine().Split(' ');
            int[] x = Array.ConvertAll(x_temp, Int32.Parse);
            if (x.Length != n)
                throw new Exception("Invalid argument");

            Array.Sort(x);

            int t = 0;
            int i = 0;
            while (i < n)
            {
                t++;
                int loc = x[i] + k;
                while (i < n && x[i] <= loc) i++;
                loc = x[--i] + k;
                while (i < n && x[i] <= loc) i++;
            }

            Console.WriteLine(t);

        }
    }
}
