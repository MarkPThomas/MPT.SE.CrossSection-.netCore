// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="MomentOfInertia.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace MPT.SE.CrossSection.AreaProperties
{
    /// <summary>
    /// Represents moment of inertia (2nd moment of area) properties of a cross section.
    /// </summary>
    public struct MomentOfInertia
    {  

        /// <summary>
        /// Moment of inertia about the 33-axis. [L^4]
        /// </summary>
        /// <value>The i 33.</value>
        public double I_33 { get; }

        /// <summary>
        /// Moment of inertia about the 22-axis. [L^4]
        /// </summary>
        /// <value>The i 22.</value>
        public double I_22 { get; }

        /// <summary>
        /// Product of inertia. [L^4]
        /// If an area has at least one axis of symmetry, the product of inertia is zero.
        /// </summary>
        /// <value>The i 23.</value>
        public double I_23 { get; }

        /// <summary>
        /// Polar moment of inertia. [L^4]
        /// </summary>
        /// <value>The j.</value>
        public double J { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentOfInertia"/> struct.
        /// </summary>
        /// <param name="i22">Moment of inertia about the 22-axis.</param>
        /// <param name="i33">Moment of inertia about the 33-axis.</param>
        /// <param name="i23">Product of inertia. If an area has at least one axis of symmetry, the product of inertia is zero.</param>
        public MomentOfInertia(double i22, double i33, double i23)
        {
            I_22 = i22;
            I_33 = i33;
            I_23 = i23;
            J = i22 + i33;
        }
    }
}
