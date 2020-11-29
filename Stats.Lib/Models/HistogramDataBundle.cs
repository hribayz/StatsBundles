using Stats.Lib.Histogram;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Models
{
    /// <summary>
    /// Data container for algorithms with Histogram output.
    /// </summary>
    public class HistogramDataBundle : AStatsBundle
    {
        public IHistogram Histogram { get; set; }
    }
}
