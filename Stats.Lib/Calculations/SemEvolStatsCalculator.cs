using Stats.Lib.Histogram;
using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    public class SemEvolStatsCalculator : IBundleStatisticsCalculator<SemEvolStatsBundle>
    {
        private IHistogramFactory HistogramFactory;
        public SemEvolStatsCalculator(IHistogramFactory histogramFactory)
        {
            HistogramFactory = histogramFactory ?? throw new ArgumentNullException(nameof(histogramFactory));
        }
        /// <summary>
        /// Calculates standard deviation and arithmetic mean and populates histogram buckets.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public SemEvolStatsBundle Run(IEnumerable<double> input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var welAlgoDataBundle = new WelfordsAlgoCalculator().Run(input);
            var histDataBundle = new HistogramCalculator(HistogramFactory).Run(input);

            var standardDeviation = Math.Sqrt(welAlgoDataBundle.Variance);

            return new SemEvolStatsBundle
            {
                Histogram = histDataBundle.Histogram,
                Mean = welAlgoDataBundle.Mean,
                StandardDeviation = standardDeviation,
            };
        }
    }
}
