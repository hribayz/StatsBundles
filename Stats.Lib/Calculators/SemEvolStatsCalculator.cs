using Stats.Lib.Histogram;
using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    /// <summary>
    /// Composes a data bundle as requested by assignment.
    /// </summary>
    public class SemEvolStatsCalculator : IStatsBundleCalculator<SemEvolStatsBundle>
    {
        /// <summary>
        /// Run the calculator on the input
        /// </summary>
        /// <param name="input">input data</param>
        public SemEvolStatsBundle Run(IEnumerable<double> input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var welAlgoDataBundle = CalculatorFactory.CreateWelfordAlgoCalculator().Run(input);

            var histCalculator = CalculatorFactory.CreateHistogramCalculatorWithConfigurableBuckets();
            histCalculator.SetHistogramMap(SemEvolBinMap);

            var histDataBundle = histCalculator.Run(input);

            var standardDeviation = Math.Sqrt(welAlgoDataBundle.Variance);

            return new SemEvolStatsBundle
            {
                Histogram = histDataBundle.Histogram,
                Mean = welAlgoDataBundle.Mean,
                StandardDeviation = standardDeviation,
            };
        }
        /// <summary>
        /// Specific bucket map requested by assignment.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private double SemEvolBinMap(double input)
        {
            int floor = (int)Math.Floor(input);
            return floor - floor % 10;
        }
    }
}
