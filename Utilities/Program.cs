using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Action> list = new List<Action> {
                    AsyncAwaitExample.Example2,
                    FastArraySearch.Run,
                    Sorter.Menu,
                    FileComparer.Run,
                    FileUtilities.FileInfoProvider,
                    FileUtilities.SearchFiles,
                    Sets.Menu,
                    SingletonPatternExample.Menu,
                    Fibonacci.Menu,
                    SongShuffle.Menu,
                    Anagram.Menu,
                    ProcessorBitness.Menu,
                    Emailer.SendEMail,
                    PerfCounters.Menu,
                    YieldExample.Menu,
                    MyExtensions.Menu,
                    CustomIteration.Menu,
                    TupleExample.Menu,
                    Encodings.Run
                };

                Dictionary<int, Action> dict = BuildMenu(list);

                DisplayMenu(dict);

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Exit();
            }
        }

        private static Dictionary<int, Action> BuildMenu(List<Action> list)
        {
            Dictionary<int, Action> dict = new Dictionary<int, Action>();
            for (int i = 0; i < list.Count; i++)
            {
                dict.Add(i + 1, list[i]);
            }

            return dict;
        }

        private static void DisplayMenu(Dictionary<int, Action> dict)
        {
            Console.WriteLine("---------------------------");
            foreach (var kvp in dict)
            {
                Console.WriteLine(kvp.Key + ". " + kvp.Value.Method.DeclaringType.Name + "." + kvp.Value.Method.Name);
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("Please select an option");

            var str = Console.ReadLine();
            int choice = 0;
            if (Int32.TryParse(str, out choice))
            {
                if (dict.ContainsKey(choice))
                    dict[choice].Invoke();
                else
                    Console.WriteLine("Invalid choice");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        private static void Exit()
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
