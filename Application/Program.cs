using System;
using System.Diagnostics;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Starting...");

            Func<string, string> makeASound = sound => { return $"the sound goes for {sound}";};

            BenchmarkClass bmark = new BenchmarkClass();
            var sw = new Stopwatch();

            sw.Start();

            bmark.NotMaterializedQueryTest(makeASound, "TestingSound");

            sw.Stop();

            var timeSpan = sw.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
            timeSpan.Milliseconds / 10);

            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}
