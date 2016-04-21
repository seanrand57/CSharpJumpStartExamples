using System;
using System.IO;
using System.Linq;

namespace After005
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            One();
            Two();
            Three();
            Console.Read();
        }

        private static void One()
        {
            var path = Environment.CurrentDirectory;
            var files = Directory.GetFiles(path);
            var file = files.First(x => x.EndsWith("manifest"));

            // open the file
            Stream stream1 = File.Open(file, FileMode.Open);
            Console.WriteLine(stream1.Length);

            // open the file again
            Stream stream2 = File.Open(file, FileMode.Open);
            Console.WriteLine(stream2.Length);
        }

        private static void Two()
        {
            var path = Environment.CurrentDirectory;
            var files = Directory.GetFiles(path);
            var file = files.First(x => x.EndsWith("manifest"));

            // open the file
            Stream stream1 = File.Open(file, FileMode.Open);
            Console.WriteLine(stream1.Length);
            stream1.Dispose();

            // open the file again
            Stream stream2 = File.Open(file, FileMode.Open);
            Console.WriteLine(stream2.Length);
            stream2.Dispose();
        }

        private static void Three()
        {
            var path = Environment.CurrentDirectory;
            var files = Directory.GetFiles(path);
            var file = files.First(x => x.EndsWith("manifest"));

            // open the file
            using (Stream stream1 = File.Open(file, FileMode.Open))
            {
                Console.WriteLine(stream1.Length);
            }

            // open the file again
            using (Stream stream2 = File.Open(file, FileMode.Open))
            {
                Console.WriteLine(stream2.Length);
            }
        }
    }
}