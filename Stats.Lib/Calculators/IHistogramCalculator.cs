using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    public interface IHistogramCalculator : IStatsBundleCalculator<HistogramStatsBundle>
    {
        /// <summary>
        /// Set the histogram bucket mapping to new function. Will corrupt results if done in between multiple runs.
        /// </summary>
        /// <param name="BucketMap"></param>
        public void SetHistogramMap(Func<double, double> BucketMap);
    }
}
