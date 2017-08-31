using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class YieldExample
    {
        public static void Menu()
        {
            foreach (int i in Integers())
            {
                Console.WriteLine(i.ToString());
            }

            
        }

        public static IEnumerable<int> Integers()
        {
            // The advantage of using yield is that if the function consuming your data simply needs 
            // the first item of the collection, the rest of the items won't be created.
            // The yield operator allows the creation of items as it is demanded.
            yield return 1;
            yield return 2;
            yield return 4;
            yield return 8;
            yield return 16;
            yield return 16777216;
        }
    }
}
