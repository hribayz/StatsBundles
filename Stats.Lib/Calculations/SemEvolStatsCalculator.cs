using Stats.Lib.Histogram;
using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    public class SemEvolStatsCalculator : IBundleStatisticsCalculator<SemEvolStatsBundle>
    {
        /// <summary>
        /// Calculates standard deviation and variance, calculates arithmetic mean and populates histogram buckets. All in one pass using modified Welfords Algorithm.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="emptyContainer"></param>
        /// <returns></returns>
        public SemEvolStatsBundle GetStatsBundle(IEnumerable<double> input)
        {
            // Welfords algorithm explained:
            // https://jonisalonen.com/2013/deriving-welfords-method-for-computing-variance/

            // Stack Overflow discussion thread to this implementation
            // https://stackoverflow.com/a/897463/3091898

            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            IHistogram histogram = HistogramFactory.CreateHistogram(MapInputToBin);

            double mean = 0d;
            double varSquaresSum = 0d;
            int step = 1;

            foreach (double value in input)
            {
                histogram.Load(value, 1);

                // update variance, mean
                double tmpM = mean;
                mean += (value - tmpM) / step;
                varSquaresSum += (value - tmpM) * (value - mean);
                step++;
            }

            var variance = varSquaresSum / (step - 2);
            var standardDeviation = Math.Sqrt(variance);

            return new SemEvolStatsBundle
            {
                Histogram = histogram,
                Mean = mean,
                StandardDeviation = standardDeviation,
                Variance = variance
            };
        }
        private double MapInputToBin(double input)
        {
            int floor = (int)Math.Floor(input);
            return floor - floor % 10;
        }
    }
}
