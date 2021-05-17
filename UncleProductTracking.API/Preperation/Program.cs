using System;
using System.IO;
using System.Text;

namespace Preperation
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin"));
            var exePath = Path.Combine(path, "Electron");
            var deletePath = exePath + @"\node_modules\selenium-webdriver\lib\test\data";
            var bld = new StringBuilder();

            Console.WriteLine("NPM paket kontrolü yapılsın mı? (E/H): ");
            string sonuc = Console.ReadLine();

            if (sonuc == "E" || sonuc == "e")
            {
                bld.Append("npm install&");
            }
            bld.Append($"RD /S /Q {deletePath} &");
            bld.Append("code .&");
            bld.Append("npm run start:electron");

            var cmd = new System.Diagnostics.Process
            {
                StartInfo =
                {
                    UseShellExecute=false,
                    FileName="cmd.exe",
                    WorkingDirectory=exePath,
                    Arguments=@"/c "+bld
                }
            };
            cmd.Start();
            Console.ReadLine();
            cmd.WaitForExit();
        }
    }
}
