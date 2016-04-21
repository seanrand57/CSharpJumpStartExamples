using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace After015
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Animal();
            x.OnSpeak += (s, e) => Console.WriteLine("On Speak!");
            x.OnSpeak += (s, e) => Console.WriteLine(e.Cancel ? "Cancel" : "Do not cancel");

            Console.WriteLine("Before");
            Console.WriteLine(string.Empty);

            x.Speak(true);
            x.Speak(false);

            Console.WriteLine(string.Empty);
            Console.WriteLine("After");

            Console.Read();
        }

        public class Animal
        {
            public event CancelEventHandler OnSpeak;
            public void Speak(bool cancel)
            {
                OnSpeak(this, new CancelEventArgs(cancel));
            }
        }
    }
}
