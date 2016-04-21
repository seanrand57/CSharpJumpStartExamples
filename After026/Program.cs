using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace After026
{
    class Program
    {
        static void Main(string[] args)
        { // demo profiler
            Console.WriteLine(Run1());
            Console.WriteLine(Run2());
            Console.WriteLine(Run3());
            Console.WriteLine(Run4());
            Console.WriteLine(Run5());
        }

        static Int64 Run1() { return Run(10000); }
        static Int64 Run2() { return Run(30000); }
        static Int64 Run3() { return Run(40000); }
        static Int64 Run4() { return Run(25000); }
        static Int64 Run5() { return Run(35000); }

        static Int64 Run(int num)
        {
            Int64 x = 0;
            for (int i1 = 0; i1 < num; i1++)
                for (int i2 = 0; i2 < num; i2++)
                    x += i2;
            return x;
        }
    }

    public class PerformanceCounterDemo
    {
        void Run()
        {
            GetCounter("DemoCat", "DemoVal").Increment();
        }

        PerformanceCounter GetCounter(string category, string counter,
             PerformanceCounterType type = PerformanceCounterType.AverageCount64,
             string machine = ".", string instance = "_Total")
        {
            if (!PerformanceCounterCategory.Exists(category))
            {
                // create category
                var counterInfos = new CounterCreationDataCollection();
                var counterInfo = new CounterCreationData()
                    {
                        CounterType = type,
                        CounterName = counter,
                    };
                counterInfos.Add(counterInfo);
                PerformanceCounterCategory
                    .Create(category, category, counterInfos);

                // check creation
                var counters
                    = new PerformanceCounterCategory(category, machine);
                if (!counters.CounterExists(counter))
                    Debug.Fail("Counter was not created");
                if (!counters.InstanceExists(instance))
                    Debug.Fail("Instance not found");
            }

            // get counter

            var perfCounter = new PerformanceCounter
            {
                CategoryName = category,
                CounterName = counter,
                MachineName = machine,
                ReadOnly = false,
            };
            perfCounter.IncrementBy(10);

            return perfCounter;
        }

    }

    public class EventLogDemo
    {
        public void Run()
        {
            Write("Demo", "Hello World",
                System.Diagnostics.EventLogEntryType.Information);
        }

        void Write(string app, string message,
            System.Diagnostics.EventLogEntryType type)
        {
            System.Diagnostics.EventLog
                .WriteEntry(app, message, type);
        }
    }
}
