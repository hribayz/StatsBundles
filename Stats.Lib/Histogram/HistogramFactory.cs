﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Histogram
{
    public class HistogramFactory /*: IHistogramFactory*/
    {
        public static IHistogram CreateHistogram(Func<double, double> barMap)
        {
            if (barMap is null)
            {
                throw new ArgumentNullException(nameof(barMap));
            }

            return new Histogram(barMap);
        }
        public static ABarHeight CreateBarHeight() => BarHeight.Empty;
        public static ABarHeight CreateBarHeight(double bar, double height) => new BarHeight(bar, height);
    }
}