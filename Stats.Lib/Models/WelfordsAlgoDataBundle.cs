using System;
using System.Collections.Generic;
using System.Text;
using Stats.Lib.Calculations;

namespace Stats.Lib.Models
{
    /// <summary>
    /// Data bundle for output of algorithms that yield Mean as by-product of Variance, such as Welfords Algorithm.
    /// </summary>
    public class WelfordsAlgoDataBundle : AStatsBundle
    {
        public double Mean { get; set; }
        public double Variance { get; set; }

    }
}
