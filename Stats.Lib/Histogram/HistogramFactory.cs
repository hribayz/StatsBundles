using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Histogram
{
    public static class HistogramFactory
    {
        public static IHistogram CreateHistogram()
        {
            return new Histogram();
        }
    }
}
