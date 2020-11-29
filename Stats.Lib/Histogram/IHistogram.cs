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
        /// <param name="bucketMap">Tells histogram how to map data to discrete buckets.</param>
        public void SetMapping(Func<double, double> bucketMap);
        /// <summary>
        /// Add value to bucket mapped by key
        /// </summary>
        /// <param name="x">Key that maps onto histogram bucket.</param>
        /// <param name="y">Value that will be added to mapped bucket.</param>
        public void AddInput(double x, double y);
        /// <summary>
        /// Gets histogram bars. Consumer knows the domain mapping, so returning bars based on mapped values (as opposed to the lower and upper bounds of the bar) is sufficient.
        /// </summary>
        /// <returns>
        /// <para IEnumerable> of Bar heights by their bucket keys as defined by <see cref="IHistogram.SetMapping(Func{double, double})"/> barMap.</para>
        /// <para x>A discrete bucket key as projected by <see cref="IHistogram.SetMapping(Func{double, double})"/> </para>
        /// <para y>Value of mapped bucket.</para>
        /// </returns>
        public IEnumerable<(double x, double y)> GetBarHeights();
        /// <summary>
        /// Gets key and value of histogram bucket mapped by input.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// <para x>A discrete bucket key as projected by <see cref="IHistogram.SetMapping(Func{double, double})"/> </para>
        /// <para y>Value of mapped bucket.</para>
        /// </returns>
        public (double x, double y) GetBarHeightMappedBy(double input);
    }
}
