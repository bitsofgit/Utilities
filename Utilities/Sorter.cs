using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Utilities
{
    public static class Sorter
    {
        static Random random = new Random();
        public static void Menu()
        {
            //int[] list = new int[] {5,6,7,1,2,3};
            //QuickSort(list,0,5);
            //foreach(var i in list)
            //    Console.Write(i + " ");
            //return;

            bool toContinue = true;
            while (toContinue)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Enter comma separated values...");

                var str = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(str))
                {
                    Console.WriteLine("Nothing to sort!!");
                }
                else
                {
                    // convert to array
                    string[] items =
                        str.Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => s.Trim())
                            .ToArray();

                    Print(items, "Unsorted");

                    //QuickSort(items, 0, items.Length - 1);
                    var sortedItems = QuickSortEasy(items.ToList());

                    Print(sortedItems.ToArray(), "Sorted");

                    Console.WriteLine("Press any key to continue or x to exit");
                    var exit = Console.ReadLine();
                    if (exit.ToUpper() == "X")
                        toContinue = false;
                }
            }
        }

        private static void TestPerformance()
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            for (int i = 0; i < 1000000; i++)
            {
                var j = new Random().Next(0, 1000000);
                list1.Add(j);
                list2.Add(j);
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            // normal sort
            list1.Sort();
            sw.Stop();
            Console.WriteLine("Normal sort : " + sw.ElapsedMilliseconds);

            var arr = list2.ToArray();
            sw.Restart();
            QuickSort(arr,0,list2.Count-1);
            sw.Stop();
            Console.WriteLine("Quick sort : " + sw.ElapsedMilliseconds);

        }

        private static void Print(string[] items, string title)
        {
            Console.WriteLine(title);
            foreach (var item in items)
                Console.Write(item + " ");

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void QuickSort<T>(T[] items, int left, int right) where T: IComparable<T>
        {
            /*
                Divide and Conquer
		        pick the pivot value and partition the array
		        move all smaller values to left and larger to right
		        after 1 pass we know pivot value is at the right position and there are 2 partitions
		        repeat until all partitions are sorted
		        performance - worst case O(n*n), average and best case O(n logn)   
            */
            if (items == null)
                return;

            if (items.Length == 1)
                return;

            int i = left;
            int j = right;

            var pivot = (T) items[(i + j)/2];

            while (i <= j)
            {
                while (items[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (items[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    var tmp = items[i];
                    items[i] = items[j];
                    items[j] = tmp;

                    i++;
                    j--;
                }
            }

            if(left < j)
                QuickSort(items,left,j);

            if(i < right)
                QuickSort(items,i,right);
        }

        public static List<T> QuickSortEasy<T>(List<T> elements) where T: IComparable
        {
            if (elements.Count <= 1) return elements;

            // divide phase: pick a random pivot and split into smaller and larger collection
            var pivotPosition = random.Next(elements.Count);
            var smaller = new List<T>();
            var larger = new List<T>();

            for(var i=0;i<elements.Count;i++)
            {
                if (i == pivotPosition)
                    continue;
                if (elements[i].CompareTo(elements[pivotPosition]) < 0)
                    smaller.Add(elements[i]);
                else
                    larger.Add(elements[i]);
            }

            var mergedSolution = QuickSortEasy(smaller);
            mergedSolution.Add(elements[pivotPosition]);
            mergedSolution.AddRange(QuickSortEasy(larger));

            return mergedSolution;
        }

        public static void QuicksortOld(IComparable[] elements, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuicksortOld(elements, left, j);
            }

            if (i < right)
            {
                QuicksortOld(elements, i, right);
            }
        }
    }
}
