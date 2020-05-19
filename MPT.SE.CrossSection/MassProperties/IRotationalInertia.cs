
namespace MPT.SE.CrossSection.MassProperties
{
    public interface IRotationalInertia
    {
        public double I33 { get; }
        public double I22 { get; }
        public double I23 { get; }
        public double Imajor { get; }
        public double Iminor { get; }
    }
}
