using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Histogram
{
    /// <summary>
    /// Histogram factory service.
    /// </summary>
    public interface IHistogramFactory
    {
        public IHistogram CreateHistogram(Func<double, double> bucketMap);

    }
}
