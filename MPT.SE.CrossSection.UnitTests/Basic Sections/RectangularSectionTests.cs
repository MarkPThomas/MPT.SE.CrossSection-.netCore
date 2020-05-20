using System;
using System.Collections.Generic;
using System.Text;
using MPT.SE.CrossSection.BasicSections;
using NUnit.Framework;

namespace MPT.SE.CrossSection.UnitTests.Basic_Sections
{
    [TestFixture]
    public class RectangularSectionTests
    {
        [Test]
        public void RectangularPropertiesCheck()
        {
            RectangularSection section = new RectangularSection(0.375, 1.5);
            Assert.AreEqual(0.5625, section.A_g, 0.0001);
            Assert.AreEqual(0, section.CentroidOffset_22, 0.0001);
            Assert.AreEqual(0, section.CentroidOffset_33, 0.0001);
            Assert.AreEqual(0.1055, section.I_major, 0.0001);
            Assert.AreEqual(0.0066, section.I_minor, 0.0001);
            Assert.AreEqual(0, section.I_product, 0.0001);
            Assert.AreEqual(0.4330, section.r_major, 0.0001);
            Assert.AreEqual(0.1083, section.r_minor, 0.0001);
            Assert.AreEqual(0.1406, section.S_majorPositive, 0.0001);
            Assert.AreEqual(0.1406, section.S_majorNegative, 0.0001);
            Assert.AreEqual(0.0352, section.S_minorPositive, 0.0001);
            Assert.AreEqual(0.0352, section.S_minorNegative, 0.0001);
            Assert.AreEqual(0, section.PlasticCentroidOffset_major, 0.0001);
            Assert.AreEqual(0, section.PlasticCentroidOffset_minor, 0.0001);
            Assert.AreEqual(0.2109, section.Z_major, 0.0001);
            Assert.AreEqual(0.0527, section.Z_minor, 0.0001);
            Assert.AreEqual(0.5625, section.A_vMajor, 0.0001);
            Assert.AreEqual(0.5625, section.A_vMinor, 0.0001);
            Assert.AreEqual(0, section.ShearCenterOffset_major, 0.0001);
            Assert.AreEqual(0, section.ShearCenterOffset_minor, 0.0001);
            Assert.AreEqual(0.4463, section.r_o, 0.0001);
            Assert.AreEqual(1, section.H, 0.0001);
            Assert.AreEqual(0.0222, section.J, 0.0001);
            Assert.AreEqual(0, section.C_w, 0.0001);
        }
    }
}
