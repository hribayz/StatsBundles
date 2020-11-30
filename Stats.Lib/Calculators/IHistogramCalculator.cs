using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    public interface IHistogramCalculator : IStatsBundleCalculator<HistogramStatsBundle>
    {
        /// <summary>
        /// Histogram with an option to set the bucket mapping to new function.
        /// </summary>
        /// <param name="BucketMap"></param>
        public void SetHistogramMap(Func<double, double> BucketMap);
    }
}
