// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="PlasticBendingProperties.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MPT.Math.Coordinates;

namespace MPT.SE.CrossSection.StressProperties
{
    /// <summary>
    /// Represents plastic bending properties of a cross section.
    /// </summary>
    public class PlasticBendingProperties
    {
        /// <summary>
        /// Coordinates of the plastic neutral axis relative to the centroid. [L]
        /// </summary>
        /// <value>The plastic neutral axis.</value>
        public CartesianCoordinate PlasticCentroid { get; }

        /// <summary>
        /// Plastic section modulus about the 22-axis. [L^3]
        /// </summary>
        /// <value>The z 22.</value>
        public double Z_22 { get; } 

        /// <summary>
        /// Plastic section modulus about the 33-axis. [L^3]
        /// </summary>
        /// <value>The z 33.</value>
        public double Z_33 { get; } 

        /// <summary>
        /// Initializes a new instance of the <see cref="PlasticBendingProperties"/> class.
        /// </summary>
        /// <param name="pna">The pna.</param>
        /// <param name="z22">The Z22.</param>
        /// <param name="z33">The Z33.</param>
        public PlasticBendingProperties(CartesianCoordinate pna, double z22, double z33)
        {
            PlasticCentroid = pna;
            Z_22 = z22;
            Z_33 = z33;
        }
    }
}
