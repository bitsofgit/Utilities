using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class FileUtilities
    {
        public static void SearchFiles()
        {
            Console.WriteLine("Enter Directory Location: ");
            string dir = Console.ReadLine();

            Console.WriteLine("Enter text to search:");
            string txt = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(dir) || string.IsNullOrWhiteSpace(txt))
            {
                Console.WriteLine("Wrong input parameter");
                return;
            }

            //DirectoryInfo di = new DirectoryInfo(dir);
            StringBuilder sb = new StringBuilder();

            DirSearch(dir, sb, txt);

            Console.WriteLine();
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(sb.ToString()))
                Console.WriteLine("Text not found");
            else
                sb.ToString().WriteToFile();
        }

        private static void DirSearch(string sDir, StringBuilder sb, string txt)
        {
            try
            {
                foreach (var d in Directory.GetDirectories(sDir))
                {
                    foreach (var fi in Directory.GetFiles(d))
                    {
                        Console.WriteLine(fi);
                        var str = File.ReadAllText(fi);
                        if (str.ToUpper().Contains(txt))
                            sb.AppendLine(fi);
                    }
                    DirSearch(d, sb, txt);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        public static void FileInfoProvider()
        {
            Console.WriteLine("Enter Directory Location: ");
            string dir = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(dir))
            {
                Console.WriteLine("Wrong input parameter");
                return;
            }

            DirectoryInfo di = new DirectoryInfo(dir);
            StringBuilder sb = new StringBuilder();
            foreach (var fi in di.GetFiles())
            {
                Console.WriteLine("Processing " + fi.FullName + "...");
                var allLines = File.ReadAllLines(fi.FullName);
                if (allLines.Length > 0)
                {
                    string first = allLines[0];
                    if (first.Length > 50)
                        first = first.Substring(0, 50);

                    string str = allLines.Length + ", " + fi.LastWriteTime + ", " +
                                 fi.CreationTime + ", " + fi.Length;
                    sb.AppendLine(str);
                }
            }


            if (string.IsNullOrWhiteSpace(sb.ToString()))
                Console.WriteLine("Text not found");
            else
                sb.ToString().WriteToFile();

        }
    }
}
