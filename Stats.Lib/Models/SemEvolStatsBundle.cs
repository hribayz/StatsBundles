using Stats.Lib.Histogram;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Models
{
    /// <summary>
    /// Data bundle for algorithms with output as defined by assignment.
    /// </summary>
    public class SemEvolStatsBundle : AStatsBundle
    {
        public double StandardDeviation { get; set; }
        public double Mean { get; set; }
        public IHistogram Histogram { get; set; }
    }
}
