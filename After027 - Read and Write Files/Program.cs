using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace After027
{
    class Program
    {
        static void Main(string[] args)
        {
            // special folders
            var docs = Environment.SpecialFolder.MyDocuments;
            var app = Environment.SpecialFolder.CommonApplicationData;
            var prog = Environment.SpecialFolder.ProgramFiles;
            var desk = Environment.SpecialFolder.Desktop;

            // application folder
            var dir = System.IO.Directory.GetCurrentDirectory();

            // isolated storage folder(s)
            var iso = IsolatedStorageFile
                .GetStore(IsolatedStorageScope.Assembly, "Demo")
                .GetDirectoryNames("*");

            // manual path
            var temp = new System.IO.DirectoryInfo("c:\temp");

            // files
            foreach (var item in System.IO.Directory.GetFiles(dir))
                Console.WriteLine(System.IO.Path.GetFileName(item));

            // rename / move
            var path1 = "c:\temp\file1.txt";
            var path2 = "c:\temp\file2.txt";
            System.IO.File.Move(path1, path2);

            // file info
            var info = new System.IO.FileInfo(path1);
            Console.WriteLine("{0}kb", info.Length / 1000);



            var file = System.IO.Path.Combine(dir, "File.txt");
            var content = "how now brown cow?";

            // write
            System.IO.File.WriteAllText(file, content);

            // read
            var read = System.IO.File.ReadAllText(file);
            Trace.Assert(read.Equals(content));

            Console.Read();

            //  var x = myDocuments + appData + programFiles + desktop;
        }
    }
}
