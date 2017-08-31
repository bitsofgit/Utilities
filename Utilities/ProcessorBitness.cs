using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Utilities
{
    public static class ProcessorBitness
    {
        public static void Menu()
        {
            // Change Platform Target in the build tab in properties from "Any CPU" or x64 to x86 to see the difference

            // 1 way
            if (IntPtr.Size == 4)
            {
                Console.WriteLine("Process is 32 bit");
            }
            else if (IntPtr.Size == 8)
            {
                Console.WriteLine("Process is 64 bit");
            }
            else
            {
                Console.WriteLine("Futuristic");
            }
            Console.WriteLine();

            // second way
            Console.WriteLine("Is OS 64 bit?" + Environment.Is64BitOperatingSystem);
            Console.WriteLine("Is process 64 bit?" + Environment.Is64BitProcess);

            
        }
    }
}
