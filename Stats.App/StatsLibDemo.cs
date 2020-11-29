using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Stats.Lib.Calculations;
using Stats.Lib.Histogram;
using Stats.Lib.Models;

namespace Stats.App
{
    public class StatsLibDemo
    {
        public void Demo()
        {
            // load input
            var sampleData = File.ReadAllText("SampleData.csv");

            // parse input
            var rawInput = sampleData.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var sampleInput = rawInput.Select(x => double.Parse(x));

            // TODO : use the Core built-in dependency injection service for this
            var histogramFactory = new HistogramFactory();

            // run demo calculator
            var sampleDataBundle = new SemEvolStatsCalculator(histogramFactory).Run(sampleInput);

            // format output
            PrettyPrint(sampleDataBundle);
        }
        private void PrettyPrint(SemEvolStatsBundle dataBundle)
        {
            Console.WindowWidth = 150;
            Console.WriteLine("Mean: ".PadLeft(22) + dataBundle.Mean);
            Console.WriteLine("Standard Deviation: ".PadLeft(22) + dataBundle.StandardDeviation);
            Console.WriteLine("Frequencies: ".PadLeft(22));
            foreach (var bucket in dataBundle.Histogram.GetBarHeights())
            {
                Console.Write($"{bucket.x} to <{bucket.x + 10}: ".PadLeft(22));
                Console.Write($"{bucket.y}".PadRight(4));
                Console.Write(new string('*', (int)bucket.y));
                Console.WriteLine();
            }
        }
    }
}
