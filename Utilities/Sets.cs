using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Sets
    {
        public static void Menu()
        {
            HashSet<int> evenItems = new HashSet<int>();

            for (int i = 0; i < 10; i++)
            {
                evenItems.Add(i*2);
            }
            Print(evenItems);

            HashSet<int> oddItems = new HashSet<int>();
            for (int i = 0; i < 10; i++)
            {
                oddItems.Add((i*2) + 1);
            }
            Print(oddItems);

            // union
            var allItems = evenItems.Union(oddItems);
            Print(allItems);

            // add duplicate
            if(evenItems.Add(2) == false)
                Console.WriteLine("2 already exists");
            Print(evenItems);

            // intersect
            HashSet<int> something = new HashSet<int>() {2,3,4,99};
            var intersectItems = allItems.Intersect(something);
            Print(intersectItems);
        }

        private static void Print(IEnumerable<int> items)
        {
            Console.WriteLine();
            foreach(var item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
