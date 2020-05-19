using System;
using System.Collections.Generic;
using System.Text;

namespace MPT.SE.CrossSection.StressProperties.Bending
{
    public interface ISectionModulus
    {
        public double y33positive { get; }
        public double S33positive { get; }
        public double S33negative { get; }

        public double y22negative { get; }
        public double S22positive { get; }
        public double S22negative { get; }



        public double ymajorPositive { get; }
        public double S_majorPositive { get; }
        public double S_majorNegative { get; }

        public double yminorPositive { get; }
        public double S_minorPositive { get; }
        public double S_minorNegative { get; }
    }
}
