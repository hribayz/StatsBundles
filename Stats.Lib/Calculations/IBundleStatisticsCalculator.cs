using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    /// <summary>
    /// Calculator that uses some efficient algorithm to produce more values at one go.
    /// </summary>
    interface IBundleStatisticsCalculator<T> where T : AStatsBundle
    {
        T GetStatsBundle(IEnumerable<double> input);
    }
}
