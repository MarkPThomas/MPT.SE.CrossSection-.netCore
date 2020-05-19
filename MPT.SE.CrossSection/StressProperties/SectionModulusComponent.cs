

namespace MPT.SE.CrossSection.StressProperties
{
    internal class SectionModulusComponent
    {
        #region Properties
        public double y_positive { get; }
        public double y_negative { get; }
        public double S_positive { get; }
        public double S_negative { get; }
        #endregion


        public SectionModulusComponent (
            double rotationalInertia, 
            double axesExtents, 
            double centroidFromExtentsMidPoint = 0)
        {
            y_positive = axesExtents / 2 - centroidFromExtentsMidPoint;
            y_negative = axesExtents / 2 + centroidFromExtentsMidPoint;

            S_positive = rotationalInertia / y_positive;
            S_positive = rotationalInertia / y_negative;
        }
    }
}
