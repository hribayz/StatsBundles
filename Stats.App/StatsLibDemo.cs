using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Stats.Lib.Calculations;
using Stats.Lib.Models;

namespace Stats.App
{
    public class StatsLibDemo
    {
        public void Demo()
        {
            // load
            var sampleData = File.ReadAllText("SampleData.csv");

            // parse
            var sampleInput = sampleData.Split(',', StringSplitOptions.RemoveEmptyEntries);

            // run calculator
            var sampleDataBundle = new SemEvolStatsCalculator().Run(sampleInput.Select(x => double.Parse(x)));

            // format output
            PrettyPrint(sampleDataBundle);
        }
        private void PrettyPrint(SemEvolStatsBundle dataBundle)
        {
            Console.WindowWidth = 140;
            Console.WriteLine("Mean: ".PadLeft(22) + dataBundle.Mean);
            Console.WriteLine("Standard Deviation: ".PadLeft(22) + dataBundle.StandardDeviation);
            Console.WriteLine("Frequencies: ".PadLeft(22));
            foreach (var bucket in dataBundle.Histogram.GetBarHeights())
            {
                Console.Write($"{bucket.Bar} to <{bucket.Bar + 10}: ".PadLeft(22));
                Console.Write($"{bucket.Height}".PadRight(4));
                Console.Write(new string('*', (int)bucket.Height));
                Console.WriteLine();
            }
        }
    }
}
