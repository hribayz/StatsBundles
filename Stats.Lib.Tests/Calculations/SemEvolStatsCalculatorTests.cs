using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stats.Lib.Calculations;
using Stats.Lib.Histogram;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Calculations.Tests
{
    [TestClass()]
    public class SemEvolStatsCalculatorTests
    {
        // TODO : create test file or add more edge cases datarows
        [TestMethod()]
        [DataRow(new[] { 0d, 1d, 2d, 3d, 4d, 5d }, 2.5, 1.870829)]
        public void RunTest(double[] input, double mean, double sd)
        {
            var dataBundle = new SemEvolStatsCalculator(new HistogramFactory()).Run(input);
            Assert.IsTrue(dataBundle.Mean >= mean * 0.999);
            Assert.IsTrue(dataBundle.Mean <= mean * 1.001);
            Assert.IsTrue(dataBundle.StandardDeviation >= sd * 0.999);
            Assert.IsTrue(dataBundle.StandardDeviation <= sd * 1.001);
        }
        [TestMethod()]
        public void TestRunVarianceOverflow()
        {
            Assert.ThrowsException<OverflowException>(() =>
            {
                new SemEvolStatsCalculator(new HistogramFactory()).Run(new[] { double.MaxValue, double.MinValue });
            });
        }
    }
}