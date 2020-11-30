using Stats.Lib.Histogram;
using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    /// <summary>
    /// Calculates a histogram of input data.
    /// Provides an option to set the bucket mapping to new function. This will corrupt results if done in between multiple runs.
    /// </summary>
    public class HistogramCalculator : IHistogramCalculator
    {
        private IHistogram histogram;
        public HistogramCalculator()
        {
            histogram = HistogramFactory.CreateHistogram();
        }
        /// <summary>
        /// Run the calculator on the input
        /// </summary>
        /// <param name="input">input data</param>
        public HistogramStatsBundle Run(IEnumerable<double> input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            foreach (double value in input)
            {
                histogram.AddInput(value, 1);
            }

            return new HistogramStatsBundle
            {
                Histogram = histogram
            };
        }

        public void SetHistogramMap(Func<double, double> BucketMap)
        {
            histogram.SetMapping(BucketMap);
        }
    }
}
