

namespace MPT.SE.CrossSection.StressProperties
{
    internal class SectionModulus
    {
        #region Properties
        public double y33positive { get; }
        public double y33negativee { get; }
        public double S33positive { get; }
        public double S33negative { get; }

        public double y22positive { get; }
        public double y22negative { get; }
        public double S22positive { get; }
        public double S22negative { get; }



        public double ymajorPositive { get; }
        public double ymajorNegative { get; }
        public double S_majorPositive { get; }
        public double S_majorNegative { get; }

        public double yminorPositive { get; }
        public double yminorNegative { get; }
        public double S_minorPositive { get; }
        public double S_minorNegative { get; }
        #endregion
    
        protected SectionModulus()
        {

        }

        public void AddSectionModulus22(double axesExtents, double I22, double yc)
        {

        }
    }
}
