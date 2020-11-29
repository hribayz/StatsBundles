﻿using Stats.Lib.Histogram;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Models
{
    public class SemEvolStatsBundle : AStatsBundle
    {
        public double StandardDeviation { get; set; }
        public double Mean { get; set; }
        public IHistogram Histogram { get; set; }
    }
}
