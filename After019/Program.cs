using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace After019
{
    class Program
    {
        static void Main(string[] args)
        {

            


            Action action = async () =>
            {
                // without
                var without = new WithoutAsync();
                without.Completed += (s, e) =>
                {
                    Console.WriteLine("Without Completed");
                    Console.WriteLine(" > {0}", e.Result);
                };
                try
                {
                    without.Start();
                    Console.WriteLine("After without.Start();");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("After without.Start();");
                    Console.WriteLine(" ! {0}", ex.Message);
                }

                // with
                var with = new WithAsync();
                try
                {
                    var result = await with.Start();
                    Console.WriteLine("With completed");
                    Console.WriteLine(" > {0}", result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("With completed");
                    Console.WriteLine(" ! {0}", ex.Message);
                }
            };

            Console.WriteLine("Begin ALL");
            action.Invoke();
            Console.WriteLine("End ALL");
            Console.Read();
        }

        private static void Process(int number)
        {
            throw new NotImplementedException();
        }

        class WithoutAsync
        {
            public event RunWorkerCompletedEventHandler Completed;
            public void Start()
            {
                var background = new BackgroundWorker();
                background.RunWorkerCompleted += (s, e) => Completed(this, e);
                background.DoWork += (s, e) =>
                {
                    Thread.Sleep(new Random().Next(3, 100));
                    e.Result = DateTime.Now;
                };
                background.RunWorkerAsync();
            }
        }

        class WithAsync
        {
            public async Task<DateTime> Start()
            {
                await Task.Delay(new Random().Next(3, 100));
                return DateTime.Now;
            }
        }
    }
}
