using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Histogram
{
    interface IHistogramFactory
    {
        public IHistogram CreateHistogram(Func<double, double> barMap);
        public ABarHeight CreateBarHeight();
        public ABarHeight CreateBarHeight(double bar, double height);
    }
}
