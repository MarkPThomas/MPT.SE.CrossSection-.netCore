// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="BasicBendingShearSection.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MPT.Math.Coordinates;
using MPT.SE.CrossSection.StressProperties;
using System;

namespace MPT.SE.CrossSection.BasicSections
{
    /// <summary>
    /// Cross section with properties related to bending and shear resistance.
    /// Implements the <see cref="MPT.SE.CrossSection.BasicSections.BasicBendingSection" />
    /// Implements the <see cref="MPT.SE.CrossSection.StressProperties.IShear" />
    /// </summary>
    /// <seealso cref="MPT.SE.CrossSection.BasicSections.BasicBendingSection" />
    /// <seealso cref="MPT.SE.CrossSection.StressProperties.IShear" />
    public abstract class BasicBendingShearSection : BasicBendingSection, IShear
    {
        /// <summary>
        /// The shear properties.
        /// </summary>
        protected Lazy<ShearProperties> _shearProperties;

        /// <summary>
        /// Shear area along the major-axis. [L^2]
        /// </summary>
        /// <value>a v major.</value>
        public double A_vMajor => _shearProperties.Value.A_v22;

        /// <summary>
        /// Shear area along the minor-axis. [L^2]
        /// </summary>
        /// <value>a v minor.</value>
        public double A_vMinor => _shearProperties.Value.A_v33;

        /// <summary>
        /// Coordinates of the shear center offset from the elastic centroid (elastic neutral axis) used for major-axis shear. [L]
        /// </summary>
        /// <value>The shear center offset major.</value>
        public double ShearCenterOffset_major => _shearProperties.Value.ShearCenter.X;

        /// <summary>
        /// Coordinates of the shear center offset from the elastic centroid (elastic neutral axis) used for minor-axis shear. [L]
        /// </summary>
        /// <value>The shear center offset minor.</value>
        public double ShearCenterOffset_minor => _shearProperties.Value.ShearCenter.Y;

        /// <summary>
        /// Polar radius of gyration about the shear center. [L]
        /// </summary>
        /// <value>The r o.</value>
        public double r_o => _shearProperties.Value.r_o;

        /// <summary>
        /// Gets the h.
        /// </summary>
        /// <value>The h.</value>
        public double H => _shearProperties.Value.H;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicBendingShearSection"/> class.
        /// </summary>
        protected BasicBendingShearSection()
        {
            _shearProperties = new Lazy<ShearProperties>(() => GetShearProperties());
        }

        /// <summary>
        /// Gets the shear properties.
        /// </summary>
        /// <returns>ShearProperties.</returns>
        /// <summary>
        /// Gets the shear properties.
        /// </summary>
        /// <returns>ShearProperties.</returns>
        protected ShearProperties GetShearProperties()
        {
            return new ShearProperties(
                Get22ShearArea(),
                Get33ShearArea(),
                GetShearCenterCoordinate(),
                _areaGross.Value,
                _rotationalInertia.Value.J);
        }

        /// <summary>
        /// Gets the shear area along the 2-2 axis.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected abstract double Get22ShearArea();

        /// <summary>
        /// Gets the shear area along the 3-3 axis.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected abstract double Get33ShearArea();

        /// <summary>
        /// Gets the shear center coordinate.
        /// </summary>
        /// <returns>CartesianCoordinate.</returns>
        protected abstract CartesianCoordinate GetShearCenterCoordinate();
    }
}
