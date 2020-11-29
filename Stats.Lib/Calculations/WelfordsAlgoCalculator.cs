using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    public class WelfordsAlgoCalculator : IBundleStatisticsCalculator<WelfordsAlgoDataBundle>
    {
        /// <summary>
        /// Classic Welfords algorithm to produce Variance and Mean in one pass.
        /// </summary>
        /// <param name="input">Input data sample.</param>
        /// <returns></returns>
        public WelfordsAlgoDataBundle GetStatsBundle(IEnumerable<double> input)
        {
            // This is to show how IBundleStatisticsCalculator Typed by a specific StatisticsBundle forces (and enables) the implementation to use 
            // some efficient way to produce all results at once.

            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            throw new NotImplementedException();
        }
    }
}
