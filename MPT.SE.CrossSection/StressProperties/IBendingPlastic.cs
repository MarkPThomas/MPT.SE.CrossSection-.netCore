// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-18-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="IBendingPlastic.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MPT.Math.Coordinates;

namespace MPT.SE.CrossSection.StressProperties
{
    /// <summary>
    /// Interface IBendingPlastic
    /// </summary>
    public interface IBendingPlastic
    {
        /// <summary>
        /// Coordinates of the plastic centroid (plastic neutral axis) offset from the elastic centroid (elastic neutral axis) used for major-axis bending. [L]
        /// </summary>
        /// <value>The plastic centroid.</value>
        double PlasticCentroidOffset_major { get; }

        /// <summary>
        /// Coordinates of the plastic centroid (plastic neutral axes) offset from the elastic centroid (elastic neutral axis) used for minor-axis bending. [L]
        /// </summary>
        /// <value>The plastic centroid.</value>
        double PlasticCentroidOffset_minor { get; }

        /// <summary>
        /// Plastic section modulus about the major-axis. [L^3]
        /// </summary>
        /// <value>The z major.</value>
        double Z_major { get; }

        /// <summary>
        /// Plastic section modulus about the minor-axis. [L^3]
        /// </summary>
        /// <value>The z minor.</value>
        double Z_minor { get; }
    }
}
