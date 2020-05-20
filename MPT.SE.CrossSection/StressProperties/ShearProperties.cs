// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="ShearProperties.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MPT.Math;
using MPT.Math.Coordinates;
using MPT.Math.NumberTypeExtensions;

namespace MPT.SE.CrossSection.StressProperties
{
    /// <summary>
    /// Represents shear properties of a cross section.
    /// </summary>
    public class ShearProperties
    {
        /// <summary>
        /// Shear area along the 22-axis. [L^2]
        /// </summary>
        /// <value>a V22.</value>
        public double A_v22 { get; } 

        /// <summary>
        /// Shear area along the 33-axis. [L^2]
        /// </summary>
        /// <value>a V33.</value>
        public double A_v33 { get; } 

        /// <summary>
        /// Coordinates of the shear center relative to the elastic centroid.
        /// </summary>
        /// <value>The shear center.</value>
        public CartesianCoordinate ShearCenter { get; }

        /// <summary>
        /// Polar radius of gyration about the shear center. [L]
        /// </summary>
        /// <value>The r o.</value>
        public double r_o { get; } 

        /// <summary>
        /// Gets the h.
        /// </summary>
        /// <value>The h.</value>
        public double H { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShearProperties" /> class.
        /// </summary>
        /// <param name="av22">Shear area along the 22-axis.</param>
        /// <param name="av33">Shear area along the 33-axis.</param>
        /// <param name="shearCenter">The shear center.</param>
        /// <param name="area">The area.</param>
        /// <param name="j">Polar moment of inertia.</param>
        public ShearProperties(
            double av22,
            double av33,
            CartesianCoordinate shearCenter, 
            double area, 
            double j)
        {
            A_v22 = av22;
            A_v33 = av33;
            ShearCenter = shearCenter;
            r_o = CalculateR_o(shearCenter, area, j);
            H = CalculateH(shearCenter, r_o);
        }

        /// <summary>
        /// Calculates the polar radius of gyration about the shear center. [L]
        /// </summary>
        /// <param name="shearCenter">The shear center.</param>
        /// <param name="area">The area. [L^2]</param>
        /// <param name="j">Polar moment of inertia. [L^4]</param>
        /// <returns>System.Double.</returns>
        public static double CalculateR_o(CartesianCoordinate shearCenter, double area, double j)
        {
            return Numbers.Sqrt(shearCenter.X.Squared()+ shearCenter.Y.Squared()+j / area);
        }

        /// <summary>
        /// Calculates the h.
        /// </summary>
        /// <param name="shearCenter">The shear center.</param>
        /// <param name="ro">The polar radius of gyration about the shear center.</param>
        /// <returns>System.Double.</returns>
        public static double CalculateH(CartesianCoordinate shearCenter, double ro)
        {
            return 1 - (shearCenter.X.Squared() + shearCenter.Y.Squared()) / ro.Squared();
        }
    }
}
