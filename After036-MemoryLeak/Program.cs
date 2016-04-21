using System;
using System.Linq;

namespace After036_MemoryLeak
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parent = new Parent();

            CreateChildren(parent);
            Console.ReadLine();

            // kids are out of scope, yet...
            Console.WriteLine("Collecting garbage");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("Poking children again");
            parent.RaisePokeChildren();
            Console.ReadLine();
        }

        private static void CreateChildren(Parent parent)
        {
            var kids = Enumerable.Range(0, 10)
                                 .Select(n => new Child(parent))
                                 .ToArray();

            Console.WriteLine("Parent poke children");

            parent.RaisePokeChildren();

            Console.WriteLine("Kids going out of scope now");
        }
    }

    internal class Parent
    {
        public event EventHandler PokeChildren;

        public void RaisePokeChildren()
        {
            if (PokeChildren != null)
            {
                PokeChildren(this, EventArgs.Empty);
            }
        }
    }

    internal class Child
    {
        private readonly Parent _parent;

        public Child(Parent parent)
        {
            _parent = parent;
            _parent.PokeChildren += ParentPokedMe;
        }

        private void ParentPokedMe(object sender, EventArgs e)
        {
            Console.WriteLine("Ow!");
        }
    }
}