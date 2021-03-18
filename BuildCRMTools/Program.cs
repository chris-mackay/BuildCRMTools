using System;
using System.Diagnostics;
using System.IO;

namespace BuildCRMTools
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Revit Version: ");
            string version = Console.ReadLine();

            string head = @"C:\Programming\CRMRevitTools-v" + version;

            string path = head + @"\Visual Studio\";
            string dest = head + @"\Inno Setup\CRMRevitTools\Commands";
            string ribn = head + @"\Inno Setup\CRMRevitTools\MenuCreator";

            string[] dirs = Directory.GetDirectories(path, "*",SearchOption.AllDirectories);

            foreach (string dir in dirs)
            {
                if (dir.Contains(@"bin\x64\Release"))
                {
                    string[] files = Directory.GetFiles(dir, "*.dll");
                    foreach (string file in files)
                    {
                        string name = Path.GetFileName(file);

                        if (!file.Contains("CRMTools.dll"))
                        {
                            File.Copy(file, dest + "\\" + name, true);
                        }
                        else
                        {
                            File.Copy(file, ribn + "\\" + name, true);
                        }
                        
                        Console.WriteLine(dest + "\\" + name + " - COMPLETED");
                    }
                }
            }

            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
