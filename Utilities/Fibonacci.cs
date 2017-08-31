using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Fibonacci
    {
        private static Dictionary<ulong, ulong> cache = new Dictionary<ulong, ulong>();
        public static void Menu()
        {
            Console.WriteLine("Enter integer value");
            var str = Console.ReadLine();

            ulong num = 0;
            if (ulong.TryParse(str, out num))
            {
                Stopwatch sw = new Stopwatch();
                //sw.Start();
                //Console.WriteLine("Fibonacci of " + num + " is :" + CalculateFibWithoutStoring(num).ToString());
                //sw.Stop();
                //Console.WriteLine("Total time without optimization : " + sw.ElapsedMilliseconds);

                sw.Restart();
                Console.WriteLine("Fibonacci of " + num + " is :" + CalculateFib(num).ToString());
                sw.Stop();
                Console.WriteLine("Total time with optimization : " + sw.ElapsedMilliseconds);
            }
            else
                Console.WriteLine("Invalid choice");
        }

        private static ulong CalculateFib(ulong num)
        {
            if (cache.ContainsKey(num))
                return cache[num];

            if (num == 0)
            {
                cache[num] = 0;
                return cache[num];
            }

            if (num == 1)
            {
                cache[num] = 1;
                return cache[num];
            }

            cache[num] = CalculateFib(num - 1) + CalculateFib(num - 2);
            
            return cache[num];
        }

        private static ulong CalculateFibWithoutStoring(ulong num)
        {
            if (num == 0)
            {
                return 0;
            }

            if (num == 1)
            {
                return 1;
            }

            return CalculateFibWithoutStoring(num - 1) + CalculateFibWithoutStoring(num - 2);
        }
    }
}
