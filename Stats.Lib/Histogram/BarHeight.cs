using System;

namespace Stats.Lib.Histogram
{
    public class BarHeight : ABarHeight
    {
        public BarHeight(double bar, double height) : base(bar, height)
        {

        }
        public static BarHeight Empty { get => new BarHeight(0, 0); }
    }
}
