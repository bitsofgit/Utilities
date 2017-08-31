using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace Utilities
{
    internal class AsyncAwaitExample
    {
        internal static async void Example1()
        {
            Console.WriteLine("start Run() : Thread Id:" + Thread.CurrentThread.ManagedThreadId);

            // call async method
            // because we didnt put await in front of this async call - execution of current method will continue
            // even before this call is finished. If we put await, the end Run() will not print however rest of the code 
            // will go ahead and control will go to program.cs class
            MyMethodAsync();

            Console.WriteLine("end Run() : Thread Id:" + Thread.CurrentThread.ManagedThreadId);

        }

        internal static async Task MyMethodAsync()
        {
            Console.WriteLine("calling long running task : Thread Id:" + Thread.CurrentThread.ManagedThreadId);

            Task<int> longRunningTask = LongRunningOperationAsync();
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here
            Console.WriteLine("long running task has been called : Thread Id:" + Thread.CurrentThread.ManagedThreadId);

            //and now we call await on the task 
            int result = await longRunningTask;
            //use the result 
            Console.WriteLine("Result : " + result + " : Thread Id : " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("This is also part of await");

            await Task.Delay(1000);
            Console.WriteLine("This will print 1 sec after the first await");

        }

        internal static async Task<int> LongRunningOperationAsync() // assume we return an int from this long running operation 
        {
            Console.WriteLine("Inside long running task : Thread Id:" + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(5000);  //5 seconds delay
            return 1;
        }

        internal static async void Example2()
        {
            // In an async method, tasks are started when they’re created. The await operator is applied 
            // to the task at the point in the method where processing can’t continue until the task finishes. 
            // Often a task is awaited as soon as it’s created, as the following example shows.
            // Run parallel tasks that dont depend on each other
            var t1 = GetHTTPContentLength("http://www.google.com");
            var t2 = GetHTTPContentLength("http://www.cnn.com");
            var t3 = GetHTTPContentLength("http://www.msnbc.com");

            Console.WriteLine("This will print right away.");

            // execute the below code only when all tasks are done
            int[] lengths = await Task.WhenAll(t1, t2, t3);
            int sum = 0;
            foreach (var len in lengths)
                sum += len;

            Console.WriteLine(string.Format($"Total Length : {sum}"));

        }

        private async static Task<int> GetHTTPContentLength(string url)
        {
            Console.WriteLine(string.Format($"Fetching {url}. This will still run in main thread. Thread ID: {Thread.CurrentThread.ManagedThreadId}"));
            HttpClient client = new HttpClient();
            var data = await client.GetStringAsync(url);
            Console.WriteLine(string.Format($"{url} length is {data.Length}. Thread ID: {Thread.CurrentThread.ManagedThreadId}"));
            return data.Length;
        }
    }
}