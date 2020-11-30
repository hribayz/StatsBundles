using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    public class WelfordsAlgoCalculator : IStatsBundleCalculator<WelfordsAlgoStatsBundle>
    {
        /// <summary>
        /// Classic Welfords algorithm to produce Variance and Mean in one pass.
        /// </summary>
        /// <param name="input">Input data sample.</param>
        /// <returns></returns>
        public WelfordsAlgoStatsBundle Run(IEnumerable<double> input)
        {
            // Welfords algorithm explained:
            // https://jonisalonen.com/2013/deriving-welfords-method-for-computing-variance/

            // Stack Overflow discussion thread to this implementation
            // https://stackoverflow.com/a/897463/3091898

            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            double mean = 0d;
            double sumOfSquares = 0d;
            int step = 1;

            foreach (double value in input)
            {
                // update variance, mean
                double tmpM = mean;
                mean += (value - tmpM) / step;
                sumOfSquares += (value - tmpM) * (value - mean);

                // also triggers if mean is infinity. No need to check both.
                if (double.IsInfinity(sumOfSquares))
                {
                    throw new OverflowException("The variance in the data was more than double.MaxValue");
                }

                step++;
            }

            var variance = sumOfSquares / (step - 2);

            return new WelfordsAlgoStatsBundle
            {
                Mean = mean,
                Variance = variance
            };
        }
    }
}
