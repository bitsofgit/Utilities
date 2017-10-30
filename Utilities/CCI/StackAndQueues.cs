using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.CCI
{
    public static class StackAndQueues
    {
        public static void Test()
        {
            Test1();
        }

        private static void Test1()
        {
            // Add a min method to stack that returns the min item in o(n) time
            Stack<int> stack = new Stack<int>();
            stack.Push(3);
            stack.Push(35);
            stack.Push(34);
            stack.Push(39);
            stack.Push(31);
            stack.Push(2);

            Console.WriteLine(stack.StackMin());
        }

        private static T StackMin<T>(this Stack<T> stack) where T: struct
        {
            // return stack.Min(); // already available in c#
            T min = (T) typeof(T).GetField("MaxValue").GetValue(null);
            foreach(T item in stack)
            {
               if (Comparer<T>.Default.Compare(min, item) > 0)
                    min = item;
            }

            return min;
        }
    }
}
