using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Histogram
{
    public interface IHistogram
    {
        public void SetMapping(Func<double, double> barMap);
        public void Load(double x, double y);
        public IEnumerable<ABarHeight> GetBarHeights();
        public ABarHeight GetBarHeightMappedBy(double input);
    }
}
