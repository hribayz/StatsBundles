using Stats.Lib.Histogram;
using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    public class HistogramCalculator : IBundleStatisticsCalculator<HistogramDataBundle>
    {
        private IHistogramFactory HistogramFactory;
        public HistogramCalculator(IHistogramFactory histogramFactory)
        {
            HistogramFactory = histogramFactory;
        }
        public HistogramDataBundle Run(IEnumerable<double> input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            IHistogram histogram = HistogramFactory.CreateHistogram(MapInputToBin);

            foreach (double value in input)
            {
                histogram.AddInput(value, 1);
            }

            return new HistogramDataBundle
            {
                Histogram = histogram
            };
        }
        private double MapInputToBin(double input)
        {
            int floor = (int)Math.Floor(input);
            return floor - floor % 10;
        }
    }
}
