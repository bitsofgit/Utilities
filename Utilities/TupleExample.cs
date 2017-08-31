using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class TupleExample
    {
        public static void Menu()
        {
            Console.WriteLine("Enter comma separated integer values...");
            var input = Console.ReadLine();
            var list = new List<int>();
            foreach (var str in input.Split(','))
            {
                int result = 0;
                if (!string.IsNullOrWhiteSpace(str))
                {
                    if (int.TryParse(str.Trim(), out result))
                        list.Add(result);
                }
            }

            if (list.Count() > 0)
            {
                var MinMax = GetMinMax(list);
                Console.WriteLine(string.Format($"Min: {MinMax.min}, Max:{MinMax.max}"));
            }
            else
                Console.WriteLine("No items in the list...");
        }

        private static (int min, int max) GetMinMax(List<int> list)
        {
            // Tuples are bags of variables without encapsulation
            var iterator = list.GetEnumerator();

            var MinMax = (min: iterator.Current, max: iterator.Current);

            while (iterator.MoveNext())
            {
                MinMax = (Math.Min(iterator.Current, MinMax.min), Math.Max(iterator.Current, MinMax.max));
            }

            return MinMax;
        }
    }
}
