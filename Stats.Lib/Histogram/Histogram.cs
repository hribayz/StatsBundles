﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stats.Lib.Histogram
{
    /// <summary>
    /// Implementation using <see cref="SortedList{TKey, TValue}"> internally.
    /// Expect good performance for the <see cref="IHistogram.GetBarHeights"> operation.
    /// Expect bad performance for looping the <see cref="IHistogram.GetBarHeightMappedBy(double)"> operation.
    /// Thread unsafe.
    /// </summary>
    public class Histogram : IHistogram
    {
        // value (x), height (y)
        private SortedList<double, double> BarHeights;
        private Func<double, double> MapValueToBar;

        public Histogram(Func<double, double> barMap)
        {
            if (barMap is null)
            {
                throw new ArgumentNullException(nameof(barMap));
            }

            BarHeights = new SortedList<double, double>();
            SetMapping(barMap);
        }
        public void SetMapping(Func<double, double> barMap)
        {
            MapValueToBar = barMap ?? throw new ArgumentNullException(nameof(barMap));
        }
        public void Load(double x, double y)
        {
            var bar = MapValueToBar(x);
            if (!BarHeights.ContainsKey(bar))
            {
                BarHeights.Add(bar, 0);
            }
            BarHeights[bar] += y;
        }
        public ABarHeight GetBarHeightMappedBy(double input)
        {
            var bar = MapValueToBar(input);
            return
                BarHeights.ContainsKey(bar) ?
                HistogramFactory.CreateBarHeight(bar, BarHeights[bar]) :
                HistogramFactory.CreateBarHeight(bar, 0);
        }
        public IEnumerable<ABarHeight> GetBarHeights()
        {
            return BarHeights.Select(x => HistogramFactory.CreateBarHeight(x.Key, x.Value));
        }

    }
}
