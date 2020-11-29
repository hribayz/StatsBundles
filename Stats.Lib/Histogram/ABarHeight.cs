using System;
using System.Collections.Generic;
using System.Text;

namespace Stats.Lib.Histogram
{
    public abstract class ABarHeight
    {
        public virtual double Bar { get; set; }
        public virtual double Height { get; set; }
        public ABarHeight(double bar, double height)
        {
            this.Bar = bar;
            this.Height = height;
        }
    }

}
