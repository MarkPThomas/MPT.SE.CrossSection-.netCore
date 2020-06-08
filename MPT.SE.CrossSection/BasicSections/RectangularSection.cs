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

        #region Methods: Basic Section
        /// <summary>
        /// Gets the boundary coordinates based on the cross-section geometry.
        /// </summary>
        /// <returns>PointBoundary.</returns>
        protected override PointBoundary GetBoundary()
        {
            return new PointBoundary(
                new List<CartesianCoordinate>() {
                    new CartesianCoordinate(b/2, d/2),
                    new CartesianCoordinate(-b/2, d/2),
                    new CartesianCoordinate(-b/2, -d/2),
                    new CartesianCoordinate(b/2, -d/2)
                });
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
        /// Get the rotational inertia about the 2-2 axis.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected override double Get22RotationalInertia()
        {
            return d * b.Cubed() / 12;
        }

        /// <summary>
        /// Get the rotational inertia about the 3-3 axis.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected override double Get33RotationalInertia()
        {
            return b * d.Cubed() / 12;
        }

        /// <summary>
        /// Get the product rotational inertia about the 2-3 axis
        /// </summary>
        /// <returns>System.Double.</returns>
        protected override double Get23RotationalInertia()
        {
            return 0;
        }
        #endregion

        #region Methods: Plastic Bending                
        /// <summary>
        /// Gets the plastic section modulus about the 2-2 axis.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected override double Get22PlasticSectionModulus()
        {
            return d * b.Squared() / 4;
        }

        /// <summary>
        /// Gets the plastic section modulus about the 3-3 axis.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected override double Get33PlasticSectionModulus()
        {
            return b * d.Squared() / 4;
        }

        /// <summary>
        /// Gets the plastic neutral axis coordinate.
        /// </summary>
        /// <returns>CartesianCoordinate.</returns>
        protected override CartesianCoordinate GetPlasticNeutralAxisCoordinate()
        {
            return new CartesianCoordinate(0, 0);
        }
        #endregion

        #region Methods: Shear                
        /// <summary>
        /// Gets the shear area along the 2-2 axis.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected override double Get22ShearArea()
        {
            return _areaGross.Value;
        }

        /// <summary>
        /// Gets the shear area along the 3-3 axis.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected override double Get33ShearArea()
        {
            return _areaGross.Value;
        }

        /// <summary>
        /// Gets the shear center coordinate.
        /// </summary>
        /// <returns>CartesianCoordinate.</returns>
        protected override CartesianCoordinate GetShearCenterCoordinate()
        {
            return new CartesianCoordinate(0, 0);
        }
        #endregion

        #region Methods: Torsional        
        /// <summary>
        /// Gets the warping constant.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected override double GetWarpingConstant()
        {
            return 0;
        }

        /// <summary>
        /// Gets the torsional stiffness.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected override double GetTorsionalStiffness()
        {
            double a1 = 0.5 * NMath.Max(b, d);
            double a2 = 0.5 * NMath.Min(b, d);

            return a1 * a2.Cubed() * ((16d / 3) - 3.36 * (a2 / a1) * (1 - (a2 / a1).Pow(4) / 12));
        }
        #endregion
    }
}
