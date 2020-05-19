using System;
using System.Collections.Generic;
using System.Text;

namespace MPT.SE.CrossSection.StressProperties.Bending
{
    public interface IPlasticModulus
    {
        public double Xp { get; }
        public double Yp { get; }
        public double Z33 { get; }
        public double Z22{ get; }
    }
}
