using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Utilities
{
    public static class FileComparer
    {
        public static void Run()
        {
            string dir1, dir2, dir1hn, dir2hn;

            Console.WriteLine("Enter First Directory :");
            dir1 = Console.ReadLine();
            Console.WriteLine("Enter helpful name for first directory:");
            dir1hn = Console.ReadLine();
            Console.WriteLine("Enter Second Directory :");
            dir2 = Console.ReadLine();
            Console.WriteLine("Enter helpful name for second directory:");
            dir2hn = Console.ReadLine();

            var di1 = new DirectoryInfo(dir1);
            var di2 = new DirectoryInfo(dir2);

            var sb = new StringBuilder();

            foreach (var fi1 in di1.GetFiles("*.dll"))
            {
                var str = Path.Combine(dir2, fi1.Name);
                if (File.Exists(str))
                {
                    var fi2 = new FileInfo(str);
                    if (fi1.LastWriteTime != fi2.LastWriteTime)
                    {
                        Console.WriteLine("Diff Last Write Time : " + fi1.Name);
                        Console.WriteLine(dir1hn + " : " + fi1.LastWriteTime);
                        Console.WriteLine(dir2hn + " : " + fi2.LastWriteTime);
                        Console.WriteLine();

                    }
                    if (fi1.Length != fi2.Length)
                    {
                        Console.WriteLine("Different size : " + fi1.Name);
                        Console.WriteLine(dir1hn + " : " + fi1.Length);
                        Console.WriteLine(dir2hn + " : " + fi2.Length);
                        Console.WriteLine();
                    }
                    

                }
                else
                {
                    sb.AppendLine(fi1.Name);
                    //Console.WriteLine("File Missing: " + fi1.Name);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            //Console.WriteLine("Missing Files (Exist in " + dir1hn + " but not in " + dir2hn + ")");
            //Console.WriteLine(sb);

        }
    }
}
