using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class CustomIteration
    {
        public static void Menu()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };

            using (IEnumerator<int> iterator = list.GetEnumerator())
            {
                int element;
                while (iterator.MoveNext())
                {
                    element = iterator.Current;
                    element.LogToConsole(string.Empty);
                }
            }
        }
    }
}
