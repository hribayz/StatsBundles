using Stats.Lib.Histogram;
using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    /// <summary>
    /// Composes a data bundle as requested by assignment.
    /// </summary>
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
        /// <param name="input">Input data sample.</param>
        /// <returns></returns>
        public SemEvolStatsBundle Run(IEnumerable<double> input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            // better to keep the following two calculations decoupled
            // as bundling them together into one algorithm would have no performance benefits
            // 

            var welAlgoDataBundle = new WelfordsAlgoCalculator().Run(input);
            var histDataBundle = new HistogramCalculator(SemEvolBinMap, HistogramFactory).Run(input);

            var standardDeviation = Math.Sqrt(welAlgoDataBundle.Variance);

            return new SemEvolStatsBundle
            {
                Histogram = histDataBundle.Histogram,
                Mean = welAlgoDataBundle.Mean,
                StandardDeviation = standardDeviation,
            };
        }
        /// <summary>
        /// Specific bucket map requested by assignment.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private double SemEvolBinMap(double input)
        {
            int floor = (int)Math.Floor(input);
            return floor - floor % 10;
        }
    }
}
