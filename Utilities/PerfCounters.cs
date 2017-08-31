using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities
{
    public static class PerfCounters
    {
        public static void Menu()
        {
            Console.WriteLine(string.Format($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}"));

            // We want to run these in parallel and not in sequence so we are not using await
            GetLastRebootTimeAsync();
            GetMemoryForProcessAsync();
            GetCPUForProcessAsync();

            //Console.WriteLine();
            //Console.WriteLine("Counter Categories");
            //PrintPerfCounterCategories();

        }

        private static void PrintPerfCounterCategories()
        {
            var categories = PerformanceCounterCategory.GetCategories();
            foreach (var category in categories)
            {
                Console.WriteLine(string.Format("Name {0}, Type {1}", category.CategoryName, category.CategoryName));

                //var instances = category.GetInstanceNames();
                //if (instances == null || instances.Count() == 0)
                //{
                //    foreach (var counter in category.GetCounters())
                //    {
                //        Console.WriteLine(string.Format("     Counter {0}", counter.CounterName));
                //    }
                //}
                //else
                //{
                //    foreach(var instance in instances)
                //    {
                //        Console.WriteLine(string.Format("     Instance {0}", instance));
                //        foreach (var counter in category.GetCounters(instance))
                //        {
                //            Console.WriteLine(string.Format("          Counter {0}", counter.CounterName));
                //        }
                //    }
                //}

                Console.WriteLine();
            }
        }

        public static async Task GetLastRebootTimeAsync()
        {
            // This is still main thread
            Console.WriteLine(string.Format($"Last Reboot Task Thread Id: {Thread.CurrentThread.ManagedThreadId}, {DateTime.Now}"));

            // last reboot time
            using (var uptime = new PerformanceCounter("System", "System Up Time"))
            {
                uptime.NextValue();       //Call this an extra time before reading its value
                var ts = await Task.Run(() =>
                {
                    return TimeSpan.FromSeconds(uptime.NextValue());
                });

                // this continuation will run in a different thread
                Console.WriteLine(string.Format($"Last Reboot Task Thread Id: {Thread.CurrentThread.ManagedThreadId}"));

                Console.WriteLine(string.Format("Last Reboot Time : Days {0}, Hours {1}, Mins {2}", ts.Days, ts.Hours, ts.Minutes));
            }
        }

        public static async Task GetMemoryForProcessAsync()
        {
            Console.WriteLine(string.Format($"Memory Task Thread Id: {Thread.CurrentThread.ManagedThreadId}"));

            using (var pc = new PerformanceCounter("Process", "Working Set", Process.GetCurrentProcess().ProcessName))
            {
                double ram = await Task.Run(() =>
                {
                    return pc.NextValue();
                });
                Console.WriteLine(string.Format($"Memory Task Thread Id: {Thread.CurrentThread.ManagedThreadId}"));

                Console.WriteLine(string.Format("Memory for current process: {0} MB", ram / 1024 / 1024));
            }
        }

        public static async Task GetCPUForProcessAsync()
        {
            Console.WriteLine(string.Format($"CPU Task Thread Id: {Thread.CurrentThread.ManagedThreadId}"));

            using (var pc = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName))
            {
                pc.NextValue();
                Thread.Sleep(500);
                double cpu = await Task.Run(() =>
                {
                    return pc.NextValue();
                });
                Console.WriteLine(string.Format($"CPU Task Thread Id: {Thread.CurrentThread.ManagedThreadId}"));

                Console.WriteLine(string.Format("CPU for current process: {0}% ", cpu));
            }
        }
    }
}
