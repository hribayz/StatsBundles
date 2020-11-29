using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Histogram
{
    public interface IHistogramFactory
    {
        public IHistogram CreateHistogram(Func<double, double> barMap);

    }
}
