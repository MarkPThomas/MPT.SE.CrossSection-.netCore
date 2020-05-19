
namespace MPT.SE.CrossSection.StressProperties
{
    public interface IShearStress
    {
        public double Av33 { get; }
        public double Av22 { get; }
        public double Xo { get; }
        public double Yo { get; }
        public double ro { get; }
        public double H { get; }
    }
}
