using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Histogram
{
    public interface IHistogram
    {
        public void SetMapping(Func<double, double> barMap);
        public void Add(double x, double y);
        public IEnumerable<(double x, double y)> GetBarHeights();
        public (double x, double y) GetBarHeightMappedBy(double input);
    }
}
