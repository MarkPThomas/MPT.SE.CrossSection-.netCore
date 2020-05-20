// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="TorsionProperties.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MPT.SE.CrossSection.StressProperties
{
    /// <summary>
    /// Represents torsional properties of a cross section.
    /// </summary>
    public class TorsionProperties
    {
        /// <summary>
        /// Torsional stiffness. [L^4]
        /// </summary>
        /// <value>The j.</value>
        public double J { get; } 

        /// <summary>
        /// Warping constant. [L^6]
        /// </summary>
        /// <value>The c w.</value>
        public double C_w { get; } 

        /// <summary>
        /// Initializes a new instance of the <see cref="TorsionProperties" /> class.
        /// </summary>
        /// <param name="j">Torsional stiffness.</param>
        /// <param name="cw">Warping constant.</param>
        public TorsionProperties(double j, double cw)
        {
            J = j;
            C_w = cw;
        }
    }
}
