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
        public WelfordsAlgoDataBundle Run(IEnumerable<double> input)
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
            double squaresSum = 0d;
            int step = 1;

            foreach (double value in input)
            {
                // update variance, mean
                double tmpM = mean;
                mean += (value - tmpM) / step;
                squaresSum += (value - tmpM) * (value - mean);

                // also triggers if mean is infinity. No need to check both.
                if (double.IsInfinity(squaresSum))
                {
                    throw new OverflowException("The variance in the data was more than double.MaxValue");
                }

                step++;
            }

            var variance = squaresSum / (step - 2);

            return new WelfordsAlgoDataBundle
            {
                Mean = mean,
                Variance = variance
            };
        }
    }
}
