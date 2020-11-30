using Stats.Lib.Histogram;
using Stats.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations
{
    /// <summary>
    /// Provides implementations to consumers of the <see cref="IStatsBundleCalculator{T}"/> interface.
    /// Single point in the library that is open to modification.
    /// Note that constructors are parameterless (i.e. calculators are stateless transient services).
    /// This should make it easy to configure DI using hosting framework like 
    /// Microsoft.Extensions.Hosting + Microsoft.Extensions.DependencyInjection
    /// </summary>
    public static class CalculatorFactory
    {
        public static IStatsBundleCalculator<HistogramStatsBundle> CreateHistogramCalculator() => new HistogramCalculator();
        public static IHistogramCalculator CreateHistogramCalculatorWithConfigurableBuckets() => new HistogramCalculator();
        public static IStatsBundleCalculator<SemEvolStatsBundle> CreateSemEvolStatsCalculator() => new SemEvolStatsCalculator();
        public static IStatsBundleCalculator<WelfordsAlgoStatsBundle> CreateWelfordAlgoCalculator() => new WelfordsAlgoCalculator();
    }
}