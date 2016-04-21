using System;

namespace After037_NewVirtualOverride
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var baseClass = new BaseClass();
            var derivedOverride = new DerivedOverride();
            var derivedNew = new DerivedNew();
            var derivedOverWrite = new DerivedOverwrite();

            baseClass.Name();
            derivedOverride.Name();
            derivedNew.Name();
            derivedOverWrite.Name();

            Console.ReadLine();
            baseClass.Name();
            derivedOverride.Name();
            ((BaseClass) derivedNew).Name();
            ((BaseClass) derivedOverWrite).Name();
            Console.ReadLine();

            var t1 = typeof (BaseClass);
            Console.WriteLine(t1.Name);
            Console.WriteLine(t1.Assembly);
        }
    }


    internal class BaseClass
    {
        internal virtual void Name()
        {
            Console.WriteLine("BaseClass");
        }
    }

    internal class DerivedOverride : BaseClass
    {
        internal override void Name()
        {
            Console.WriteLine("DerivedOverride");
        }
    }

    internal class DerivedNew : BaseClass
    {
        internal new void Name()
        {
            Console.WriteLine("New");
        }
    }

    internal class DerivedOverwrite : BaseClass
    {
        internal void Name()
        {
            Console.WriteLine("Overwrite");
        }
    }
}