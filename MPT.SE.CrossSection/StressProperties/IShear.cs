// ***********************************************************************
// Assembly         : 
// Author           : Mark P Thomas
// Created          : 05-18-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="IShearStress.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using MPT.Math.Coordinates;

namespace MPT.SE.CrossSection.StressProperties
{
    /// <summary>
    /// Interface IShearStress
    /// </summary>
    public interface IShear
    {
        /// <summary>
        /// Shear area along the major-axis. [L^2]
        /// </summary>
        /// <value>a v major.</value>
        public double A_vMajor { get; }

        /// <summary>
        /// Shear area along the minor-axis. [L^2]
        /// </summary>
        /// <value>a v minor.</value>
        public double A_vMinor { get; }


        /// <summary>
        /// Coordinates of the shear center offset from the elastic centroid (elastic neutral axis) used for major-axis shear. [L]
        /// </summary>
        /// <value>The shear center offset major.</value>
        public double ShearCenterOffset_major { get; }

        /// <summary>
        /// Coordinates of the shear center offset from the elastic centroid (elastic neutral axis) used for minor-axis shear. [L]
        /// </summary>
        /// <value>The shear center offset minor.</value>
        public double ShearCenterOffset_minor { get; }

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
    }
}
