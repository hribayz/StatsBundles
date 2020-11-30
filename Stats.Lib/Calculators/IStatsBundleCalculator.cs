using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{

    /// <summary>
    /// Calculator that uses some efficient algorithm to produce more values at one go.
    /// </summary>
    public interface IStatsBundleCalculator<T> where T : AStatsBundle
    {
        /// <summary>
        /// Run the calculator on the input. Run multiple inputs on the same instance for additive results.
        /// </summary>
        /// <param name="input">input data</param>
        /// <returns>Data bundle of provided Type suitable to the algorithm.</returns>
        T Run(IEnumerable<double> input);
    }
}
