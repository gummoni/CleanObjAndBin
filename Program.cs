using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanObjAndBin
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirs = Directory.GetDirectories(".\\", "*", SearchOption.AllDirectories).Where(_ => Regex.IsMatch(_, "(bin|obj)")).ToArray();

            foreach (var dir in dirs)
            {
                if (dir.Contains(".git")) continue;
                var files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    try
                    {
                        Console.WriteLine(file);
                        File.Delete(file);
                    }
                    catch
                    {
                    }
                }
            }

            Console.WriteLine("---");
            Console.ReadLine();
        }
    }
}
