// ***********************************************************************
// Assembly         : 
// Author           : Mark P Thomas
// Created          : 05-18-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="ITorsionStress.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace MPT.SE.CrossSection.StressProperties
{
    /// <summary>
    /// Interface ITorsionStress
    /// </summary>
    public interface ITorsion
    {
        /// <summary>
        /// Torsional stiffness. [L^4]
        /// </summary>
        /// <value>The j.</value>
        double J { get; }

        /// <summary>
        /// Warping constant. [L^6]
        /// </summary>
        /// <value>The c w.</value>
        double C_w { get; }
    }
}
