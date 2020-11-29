using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Histogram
{
    public interface IHistogram
    {
        /// <summary>
        /// Sets discrete projection that defines the histogram buckets. A simple integer cast will map inputs onto their integer part; e.g. 2.5 -> 2.
        /// </summary>
        /// <param name="barMap"></param>
        public void SetMapping(Func<double, double> barMap);
        public void AddInput(double x, double y);
        /// <summary>
        /// Gets histogram bars. Consumer knows the domain mapping, so returning bars based on mapped values (as opposed to the lower and upper bounds of the bar) is sufficient.
        /// </summary>
        /// <returns>
        /// <para IEnumerable> of Bar heights by their bucket keys as defined by <see cref="IHistogram.SetMapping(Func{double, double})"/> barMap.</para>
        /// <para x>Bar key. A discrete value projected by <see cref="IHistogram.SetMapping(Func{double, double})"/> </para>
        /// <para y>Bar height.</para>
        /// </returns>
        public IEnumerable<(double x, double y)> GetBarHeights();

        public (double x, double y) GetBarHeightMappedBy(double input);
    }
}
