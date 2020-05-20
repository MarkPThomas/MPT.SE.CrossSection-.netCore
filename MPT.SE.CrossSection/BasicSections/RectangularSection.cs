// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="Bar.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using MPT.Geometry.Tools;
using MPT.Math.Coordinates;
using MPT.Math.NumberTypeExtensions;
using MPT.SE.CrossSection.AreaProperties;
using MPT.SE.CrossSection.StressProperties;
using System.Collections.Generic;
using NMath = System.Math;

namespace MPT.SE.CrossSection.BasicSections
{
    /// <summary>
    /// Rectangular cross section.
    /// Implements the <see cref="MPT.SE.CrossSection.BasicSections.BasicBendingShearTorsionSection" />
    /// </summary>
    /// <seealso cref="MPT.SE.CrossSection.BasicSections.BasicBendingShearTorsionSection" />
    public class RectangularSection : BasicBendingShearTorsionSection
    {
        #region Properties
        /// <summary>
        /// Width.
        /// </summary>
        /// <value>The b.</value>
        public double b { get; private set; }
        /// <summary>
        /// Depth.
        /// </summary>
        /// <value>The d.</value>
        public double d { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="RectangularSection"/> class.
        /// </summary>
        /// <param name="b">Width.</param>
        /// <param name="d">Height.</param>
        public RectangularSection(double b, double d)
        {
            this.b = b;
            this.d = d;
        }
        #endregion

        #region Methods: Protected Virtual
        /// <summary>
        /// Gets the torsional stiffness.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected virtual double GetTorsionalStiffness()
        {
            double a1 = 0.5 * NMath.Max(b, d);
            double a2 = 0.5 * NMath.Min(b, d);

            return a1 * a2.Cubed() * ((16d / 3) - 3.36 * (a2 / a1) * (1 - (a2 / a1).Pow(4) / 12));
        }
        #endregion

        #region Methods: Protected Override
        /// <summary>
        /// Sets the extents based on the cross section geometry.
        /// </summary>
        protected override PointExtents GetExtents()
        {
            return new PointExtents(
                new List<CartesianCoordinate>() {
                    new CartesianCoordinate(b/2, d/2),
                    new CartesianCoordinate(-b/2, -d/2)
                }
                );
        }

        /// <summary>
        /// Gets the gross area.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected override double GetAreaGross()
        {
            return b * d;
        }

        /// <summary>
        /// Gets the center of gravity.
        /// </summary>
        /// <returns>CartesianCoordinate.</returns>
        protected override CartesianCoordinate GetCenterOfGravity()
        {
            return new CartesianCoordinate(0, 0);
        }

        /// <summary>
        /// Gets the rotational inertia.
        /// </summary>
        /// <returns>MomentOfInertia.</returns>
        protected override MomentOfInertia GetRotationalInertia()
        {
            double i22 = d * b.Cubed() / 12;
            double i33 = b * d.Cubed() / 12;
            double i23 = 0;
            return new MomentOfInertia(i22, i33, i23);
        }

        /// <summary>
        /// Gets the plastic bending properties.
        /// </summary>
        /// <returns>PlasticBendingProperties.</returns>
        protected override PlasticBendingProperties GetPlasticBendingProperties()
        {
            CartesianCoordinate pna = new CartesianCoordinate(0, 0);
            double z22 = d * b.Squared() / 4;
            double z33 = b * d.Squared() / 4;

            return new PlasticBendingProperties(pna, z22, z33);
        }

        /// <summary>
        /// Gets the shear properties.
        /// </summary>
        /// <returns>ShearProperties.</returns>
        protected override ShearProperties GetShearProperties()
        {
            double av22 = _areaGross.Value;
            double av33 = _areaGross.Value;
            CartesianCoordinate shearCenter = new CartesianCoordinate(0, 0);
            return new ShearProperties(av22, av33, shearCenter, _areaGross.Value, _rotationalInertia.Value.J);
        }

        /// <summary>
        /// Gets the torsional properties.
        /// </summary>
        /// <returns>TorsionProperties.</returns>
        protected override TorsionProperties GetTorsionProperties()
        {
            double cw = 0;
            return new TorsionProperties(GetTorsionalStiffness(), cw);
        }
        #endregion
    }
}
