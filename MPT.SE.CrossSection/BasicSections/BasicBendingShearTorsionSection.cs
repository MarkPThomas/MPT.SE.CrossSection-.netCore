// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="BasicBendingShearTorsionSection.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MPT.SE.CrossSection.StressProperties;
using System;

namespace MPT.SE.CrossSection.BasicSections
{
    /// <summary>
    /// Cross section with properties related to bending, shear and torsional resistance.
    /// Implements the <see cref="MPT.SE.CrossSection.BasicSections.BasicBendingShearSection" />
    /// Implements the <see cref="MPT.SE.CrossSection.StressProperties.ITorsion" />
    /// </summary>
    /// <seealso cref="MPT.SE.CrossSection.BasicSections.BasicBendingShearSection" />
    /// <seealso cref="MPT.SE.CrossSection.StressProperties.ITorsion" />
    public abstract class BasicBendingShearTorsionSection : BasicBendingShearSection, ITorsion
    {
        /// <summary>
        /// The torsional properties.
        /// </summary>
        internal Lazy<TorsionProperties> _torsionProperties;
        /// <summary>
        /// Torsional stiffness. [L^4]
        /// </summary>
        /// <value>The j.</value>
        public double J => _torsionProperties.Value.J;
        /// <summary>
        /// Warping constant. [L^6]
        /// </summary>
        /// <value>The c w.</value>
        public double C_w => _torsionProperties.Value.C_w;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicBendingShearTorsionSection"/> class.
        /// </summary>
        protected BasicBendingShearTorsionSection()
        {
            _torsionProperties = new Lazy<TorsionProperties>(() => GetTorsionProperties());
        }
        /// <summary>
        /// Gets the torsional properties.
        /// </summary>
        /// <returns>TorsionProperties.</returns>
        protected abstract TorsionProperties GetTorsionProperties();
    }
}
