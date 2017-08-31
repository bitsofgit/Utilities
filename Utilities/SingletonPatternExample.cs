using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class SingletonPatternExample
    {
        public static void Menu()
        {
            for (int i = 0; i < 20; i++)
            {
                LoadBalancer lb = LoadBalancer.GetLoadBalancer();
                Console.WriteLine("Task " + i + " is assigned to " + lb.Server);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
    public sealed class LoadBalancer
    {
        /* not much difference between static class and singleton
         * singleton can implement interfaces and static class can not
         * This means that you can pass a reference of singleton class if needed
         */
        // static members are lazily initialized
        private static readonly LoadBalancer _instance = new LoadBalancer();

        private List<string> servers = new List<string>();
        private Random random = new Random();

        // private constructor
        private LoadBalancer()
        {
            servers.Add("Server 1");
            servers.Add("Server 2");
            servers.Add("Server 3");
            servers.Add("Server 4");
            servers.Add("Server 5");
            servers.Add("Server 6");
        }

        public static LoadBalancer GetLoadBalancer()
        {
            return _instance;
        }

        public string Server
        {
            get
            {
                int r = random.Next(0,servers.Count-1);
                return servers[r];
            }
        }
    }
}
