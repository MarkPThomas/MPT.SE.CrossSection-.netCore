// ***********************************************************************
// Assembly         : 
// Author           : Mark P Thomas
// Created          : 05-18-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="IRotationalInertia.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace MPT.SE.CrossSection.AreaProperties
{
    /// <summary>
    /// Interface IRotationalInertia
    /// </summary>
    public interface IRotationalInertia
    {
        /// <summary>
        /// Moment of inertia about the major-axis. [L^4]
        /// </summary>
        /// <value>The i major.</value>
        public double I_major { get; }

        /// <summary>
        /// Moment of inertia about the minor-axis. [L^4]
        /// </summary>
        /// <value>The i minor.</value>
        public double I_minor { get; }

        /// <summary>
        /// Product of inertia. [L^4]
        /// If an area has at least one axis of symmetry, the product of inertia is zero.
        /// </summary>
        /// <value>The i product.</value>
        public double I_product { get; }
    }
}
