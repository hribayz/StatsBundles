using Stats.Lib.Histogram;
using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    /// <summary>
    /// Runs algorithm that produces a Histogram of input data.
    /// </summary>
    public class HistogramCalculator : IBundleStatisticsCalculator<HistogramDataBundle>
    {
        private IHistogramFactory HistogramFactory;
        private Func<double, double> BucketMap;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bucketMap">Tells histogram how to map data to discrete buckets.</param>
        /// <param name="histogramFactory">Histogram implementation service.</param>
        public HistogramCalculator(Func<double, double> bucketMap, IHistogramFactory histogramFactory)
        {
            HistogramFactory = histogramFactory;
            BucketMap = bucketMap;
        }
        public HistogramDataBundle Run(IEnumerable<double> input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            IHistogram histogram = HistogramFactory.CreateHistogram(BucketMap);

            foreach (double value in input)
            {
                histogram.AddInput(value, 1);
            }

            return new HistogramDataBundle
            {
                Histogram = histogram
            };
        }
    }
}
