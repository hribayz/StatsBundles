﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stats.Lib.Histogram
{
    /// <summary>
    /// Implementation using <see cref="SortedDictionary{TKey, TValue}"> internally
    /// to maximize performance of the <see cref="IHistogram.AddInput(double, double)"> operation.
    /// Thread unsafe.
    /// </summary>
    public class Histogram : IHistogram
    {
        // value (x), height (y)
        private SortedDictionary<double, double> BarHeights;
        private Func<double, double> MapValueToBar;

        public Histogram()
        {
            BarHeights = new SortedDictionary<double, double>();
            MapValueToBar = d => Math.Floor(d);
        }
        public void SetMapping(Func<double, double> barMap)
        {
            MapValueToBar = barMap ?? throw new ArgumentNullException(nameof(barMap));
        }
        public void AddInput(double x, double y)
        {
            var bar = MapValueToBar(x);
            if (!BarHeights.ContainsKey(bar))
            {
                BarHeights.Add(bar, 0);
            }
            BarHeights[bar] += y;
        }
        public (double x, double y) GetBarHeightMappedBy(double input)
        {
            var bar = MapValueToBar(input);
            return BarHeights.ContainsKey(bar) ? (bar, BarHeights[bar]) : (bar, 0);
        }
        public IEnumerable<(double x, double y)> GetBarHeights()
        {
            return BarHeights.Select(x => (x.Key, x.Value));
        }

    }
}
