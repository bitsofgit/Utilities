using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Utilities
{
    public static class FastArraySearch
    {
        public static void Run()
        {
            var data = new List<int>();
           
            for (int i = 0; i < 100000; i++)
            {
                data.Add(new Random().Next(1, 1000));
            }

            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(HasPairWithSum(data, 20));
            sw.Stop();
            Console.WriteLine("Fast Approach : " + sw.ElapsedMilliseconds + "(ms)" );

            sw.Restart();
            Console.WriteLine(HasPairWithSumConventional(data, 20));
            sw.Stop();
            Console.WriteLine("Conventional Approach : " + sw.ElapsedMilliseconds + "(ms)");
        }

        public static bool HasPairWithSum(List<int> data, int sum)
        {
            if (data == null || data.Count == 0)
                return false;

            var comp = new HashSet<int>();
            for(int i=0;i<data.Count;i++)
            {
                if(comp.Contains(data[i])) 
                 return true;

                comp.Add(sum - data[i]);
            }
            return false;
        }

        public static bool HasPairWithSumConventional(List<int> data, int sum)
        {
            if (data == null || data.Count == 0)
                return false;

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data.Count; j++)
                {
                    if (i != j)
                    {
                        if (data[i] + data[j] == sum)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}