using Stats.Lib.Histogram;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Models
{
    public class HistogramDataBundle : AStatsBundle
    {
        public IHistogram Histogram { get; set; }
    }
}
