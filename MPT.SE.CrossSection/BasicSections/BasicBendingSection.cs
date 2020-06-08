// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="BasicBendingSection.cs" company="Mark P Thomas, Inc.">
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
    /// Cross section with properties related to bending resistance.
    /// Implements the <see cref="MPT.SE.CrossSection.BasicSections.BasicSection" />
    /// Implements the <see cref="MPT.SE.CrossSection.StressProperties.IBending" />
    /// </summary>
    /// <seealso cref="MPT.SE.CrossSection.BasicSections.BasicSection" />
    /// <seealso cref="MPT.SE.CrossSection.StressProperties.IBending" />
    public abstract class BasicBendingSection : BasicSection, IBending
    {
        #region Elastic Bending Properties
        /// <summary>
        /// The elastic bending properties.
        /// </summary>
        protected Lazy<ElasticBendingProperties> _elasticBendingProperties;

        /// <summary>
        /// Elastic section modulus about the major-axis under positive bending. [L^3]
        /// </summary>
        /// <value>The s major positive.</value>
        public double S_majorPositive => _elasticBendingProperties.Value.S_33positive;

        /// <summary>
        /// Elastic section modulus about the major-axis under negative bending. [L^3]
        /// </summary>
        /// <value>The s major negative.</value>
        public double S_majorNegative => _elasticBendingProperties.Value.S_33negative;

        /// <summary>
        /// Elastic section modulus about the minor-axis under positive bending. [L^3]
        /// </summary>
        /// <value>The s minor positive.</value>
        public double S_minorPositive => _elasticBendingProperties.Value.S_22positive;

        /// <summary>
        /// Elastic section modulus about the minor-axis under negative bending. [L^3]
        /// </summary>
        /// <value>The s minor negative.</value>
        public double S_minorNegative => _elasticBendingProperties.Value.S_22negative;
        #endregion

        #region Plastic Bending Properties
        /// <summary>
        /// The plastic bending properties.
        /// </summary>
        protected Lazy<PlasticBendingProperties> _plasticBendingProperties;

        /// <summary>
        /// Coordinates of the plastic centroid (plastic neutral axis) offset from the elastic centroid (elastic neutral axis) used for major-axis bending. [L]
        /// </summary>
        /// <value>The plastic centroid.</value>
        public double PlasticCentroidOffset_major => _plasticBendingProperties.Value.PlasticCentroid.Y;

        /// <summary>
        /// Coordinates of the plastic centroid (plastic neutral axes) offset from the elastic centroid (elastic neutral axis) used for minor-axis bending. [L]
        /// </summary>
        /// <value>The plastic centroid.</value>
        public double PlasticCentroidOffset_minor => _plasticBendingProperties.Value.PlasticCentroid.X;

        /// <summary>
        /// Plastic section modulus about the major-axis. [L^3]
        /// </summary>
        /// <value>The z major.</value>
        public double Z_major => _plasticBendingProperties.Value.Z_33;

        /// <summary>
        /// Plastic section modulus about the minor-axis. [L^3]
        /// </summary>
        /// <value>The z minor.</value>
        public double Z_minor => _plasticBendingProperties.Value.Z_22;
        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="BasicBendingSection"/> class.
        /// </summary>
        protected BasicBendingSection()
        {
            _elasticBendingProperties = new Lazy<ElasticBendingProperties>(() => GetElasticBendingProperties());
            _plasticBendingProperties = new Lazy<PlasticBendingProperties>(() => GetPlasticBendingProperties());
        }


        /// <summary>
        /// Gets the elastic bending properties.
        /// </summary>
        /// <returns>ElasticBendingProperties.</returns>
        protected virtual ElasticBendingProperties GetElasticBendingProperties()
        {
            return new ElasticBendingProperties(Extents, _centroid.Value, _rotationalInertia.Value);
        }
        /// <summary>
        /// Gets the plastic bending properties.
        /// </summary>
        /// <returns>PlasticBendingProperties.</returns>
        protected PlasticBendingProperties GetPlasticBendingProperties()
        {
            return new PlasticBendingProperties(
                GetPlasticNeutralAxisCoordinate(),
                Get22PlasticSectionModulus(),
                Get33PlasticSectionModulus());
        }

        /// <summary>
        /// Gets the plastic section modulus about the 2-2 axis.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected abstract double Get22PlasticSectionModulus();

        /// <summary>
        /// Gets the plastic section modulus about the 3-3 axis.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected abstract double Get33PlasticSectionModulus();

        /// <summary>
        /// Gets the plastic neutral axis coordinate.
        /// </summary>
        /// <returns>CartesianCoordinate.</returns>
        protected abstract CartesianCoordinate GetPlasticNeutralAxisCoordinate();
    }
}
