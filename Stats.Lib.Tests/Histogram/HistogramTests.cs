using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stats.Lib.Histogram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stats.Lib.Histogram.Tests
{
    [TestClass()]
    public class HistogramTests
    {

        // TODO : create test file or add more datarows
        [TestMethod()]
        [DataRow(new[] { 0d, 1.1, 2.2, 3.3, 4.4, 5.5, 5.5 }, new[] { 0, 1, 2, 3, 4, 5 }, new[] { 0d, 1.1, 2.2, 3.3, 4.4, 11 })]
        public void TestIntegerHistogram(double[] inputs, int[] keys, double[] heights)
        {

            var histogram = HistogramFactory.CreateHistogram();
            histogram.SetMapping(d => (int)d);

            foreach (var input in inputs)
            {
                histogram.AddInput(input, input);
            }

            var actualHistKeys = histogram.GetBarHeights().ToList();

            Assert.AreEqual(keys.Length, actualHistKeys.Count);

            for (int i = 0; i < keys.Length; i++)
            {
                Assert.AreEqual(keys[i], actualHistKeys[i].x);
                Assert.AreEqual(heights[i], actualHistKeys[i].y);
            }
        }

    }
}