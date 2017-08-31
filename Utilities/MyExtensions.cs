using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class MyExtensions
    {
        public static void Menu()
        {
            var str = "Hello, How are you doing? I am doing ok.";
            str.LogToConsole("Input value");
            str.WordCount().ToString().LogToConsole("Word count");

            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            list.LogToConsole();
        }

        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static void LogToConsole<T>(this IEnumerable<T> list)
        {
            foreach (T val in list)
            {
                Console.WriteLine(val);
            }
        }

        public static void LogToConsole<T>(this T item, string preceedingText)
        {
            Console.WriteLine(preceedingText + ": " + item);
        }

        /// <summary>
        /// Creates a new file and writes to it and returns the path of the generated file.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string WriteToFile(this string str)
        {
            string guid = Guid.NewGuid().ToString().Substring(0, 5);
            string filename = "Results_" + guid + "_0.txt";
            FileInfo fi = new FileInfo(filename);
            File.WriteAllText(filename, str);
            return fi.FullName;
        }
    }
}
