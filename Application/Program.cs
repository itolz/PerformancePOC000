using System;
using System.Diagnostics;
using System.Linq;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Starting...");

            Func<string, string> makeASound = sound => { return $"the sound goes for {sound}";};

            var elements = Enumerable.Range(0, 50000000);

            BenchmarkClass bmark = new BenchmarkClass();
            var sw = new Stopwatch();

            sw.Start();
 
            bmark.NotMaterializedQueryTest(elements, makeASound, "TestingSound");

            sw.Stop();

            var timeSpanNotMaterialized = sw.Elapsed;

            string elapsedTimeNotMaterialized = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            timeSpanNotMaterialized.Hours, timeSpanNotMaterialized.Minutes, timeSpanNotMaterialized.Seconds,
            timeSpanNotMaterialized.Milliseconds / 10);

            Console.WriteLine("RunTime for NotMaterializedQueryTest " + elapsedTimeNotMaterialized);

            sw = new Stopwatch();
            sw.Start();

            bmark.MaterializedQueryTest(elements, makeASound, "TestingSound");

            sw.Stop();

            var timeSpanMaterialized = sw.Elapsed;

            string elapsedTimetimeSpanMaterialized = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            timeSpanMaterialized.Hours, timeSpanMaterialized.Minutes, timeSpanMaterialized.Seconds,
            timeSpanMaterialized.Milliseconds / 10);

            Console.WriteLine("RunTime for MaterializedQueryTest " + elapsedTimetimeSpanMaterialized);

        }
    }
}
