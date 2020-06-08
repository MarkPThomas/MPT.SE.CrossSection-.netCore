// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="BasicCrossSection.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MPT.Geometry.Tools;
using MPT.Math.Coordinates;
using MPT.SE.CrossSection.AreaProperties;
using System;
using System.Collections.Generic;

namespace MPT.SE.CrossSection.BasicSections
{
    /// <summary>
    /// Cross section with basic physical properties based on mass/area distribution.
    /// </summary>
    public abstract class BasicSection : IArea
    {
        // TODO: Many Cross section properties of 1 of several types. Work out best way to handle properties:
        // 1. Geometric - i.e. about geometric axes
        // 2. Local - i.e. about local axes, which may be rotated from geometric for specialized purposes.
        // 3. Principal - i.e. local axes rotated to where max/min occur for bending properties. Typically aligned with geometric axes. Special case of Local axes.
        // 4. Major/minor axes - differ for shear vs. bending, as a label applied over Geometric or Principal axes.
        // 
        // Perhaps in all cases, always have geometric, with a wrapper created over for Local/Principal/Major-Minor equivalents with a rotational offset.


        /// <summary>
        /// The boundary
        /// </summary>
        protected Lazy<PointBoundary> _boundary;
        /// <summary>
        /// Gets the boundary.
        /// </summary>
        /// <value>The boundary.</value>
        public IList<CartesianCoordinate> Boundary => _boundary.Value.Coordinates;

        /// <summary>
        /// The extents.
        /// </summary>
        protected Lazy<PointExtents> _extents;
        /// <summary>
        /// Gets or sets the extents.
        /// </summary>
        /// <value>The extents.</value>
        public PointExtents Extents => _extents.Value;

        /// <summary>
        /// Gross area.
        /// </summary>
        protected Lazy<double> _areaGross; 
        /// <summary>
        /// Gross area. [L^2]
        /// </summary>
        /// <value>a g.</value>
        public double A_g => _areaGross.Value;

        /// <summary>
        /// The center of gravity (elastic neutral axis) offset from the geometric center of the extents.
        /// X-axis corresponds to local 33-axis, and Y-axis corresponds to local 22-axis.
        /// </summary>
        protected Lazy<CartesianCoordinate> _centroid;
        /// <summary>
        /// The center of gravity (elastic neutral axis) offset from the geometric center of the extents along the 22-axis.  [L]
        /// </summary>
        /// <value>The center of gravity.</value>
        public double CentroidOffset_22 => _centroid.Value.Y;
        /// <summary>
        /// The center of gravity (elastic neutral axis) offset from the geometric center of the extents along the 33-axis. [L]
        /// </summary>
        /// <value>The center of gravity.</value>
        public double CentroidOffset_33 => _centroid.Value.X;

        /// <summary>
        /// The rotational inertia properties.
        /// </summary>
        protected Lazy<MomentOfInertia> _rotationalInertia; 
        /// <summary>
        /// Moment of inertia about the major-axis. [L^4]
        /// </summary>
        /// <value>The i major.</value>
        public double I_major => _rotationalInertia.Value.I_33;
        /// <summary>
        /// Moment of inertia about the minor-axis. [L^4]
        /// </summary>
        /// <value>The i minor.</value>
        public double I_minor => _rotationalInertia.Value.I_22;
        /// <summary>
        /// Product of inertia. [L^4]
        /// If an area has at least one axis of symmetry, the product of inertia is zero.
        /// </summary>
        /// <value>The i product.</value>
        public double I_product => _rotationalInertia.Value.I_23;

        /// <summary>
        /// The radius of gyration properties.
        /// </summary>
        protected Lazy<RadiusOfGyration> _radiusOfGyration;
        /// <summary>
        /// Radius of gyration about the major-axis. [L]
        /// </summary>
        /// <value>The r major.</value>
        public double r_major => _radiusOfGyration.Value.r33;
        /// <summary>
        /// Radius of gyration about the minor-axis. [L]
        /// </summary>
        /// <value>The r minor.</value>
        public double r_minor => _radiusOfGyration.Value.r22;



        /// <summary>
        /// Initializes a new instance of the <see cref="BasicSection"/> class.
        /// </summary>
        protected BasicSection()
        {
            _boundary = new Lazy<PointBoundary>(() => GetBoundary());
            _extents = new Lazy<PointExtents>(() => GetExtents());
            _areaGross = new Lazy<double>(() => GetAreaGross());
            _centroid = new Lazy<CartesianCoordinate>(() => GetCenterOfGravity());
            _rotationalInertia = new Lazy<MomentOfInertia>(() => GetRotationalInertia());
            _radiusOfGyration = new Lazy<RadiusOfGyration>(() => GetRadiusOfGyration());
        }

        /// <summary>
        /// Sets the extents based on the cross-section geometry.
        /// </summary>
        protected PointExtents GetExtents()
        {
            return new PointExtents(GetBoundary().Coordinates);
        }

        /// <summary>
        /// Gets the boundary coordinates based on the cross-section geometry.
        /// </summary>
        /// <returns>PointBoundary.</returns>
        protected abstract PointBoundary GetBoundary();

        /// <summary>
        /// Gets the gross area.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected abstract double GetAreaGross();

        /// <summary>
        /// Gets the center of gravity.
        /// </summary>
        /// <returns>CartesianCoordinate.</returns>
        protected abstract CartesianCoordinate GetCenterOfGravity();

        /// <summary>
        /// Gets the rotational inertia.
        /// </summary>
        /// <returns>MomentOfInertia.</returns>
        protected MomentOfInertia GetRotationalInertia()
        {
            return new MomentOfInertia(
                Get22RotationalInertia(),
                Get33RotationalInertia(),
                Get23RotationalInertia());
        }

        /// <summary>
        /// Get the rotational inertia about the 2-2 axis.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected abstract double Get22RotationalInertia();

        /// <summary>
        /// Get the rotational inertia about the 3-3 axis.
        /// </summary>
        /// <returns>System.Double.</returns>
        protected abstract double Get33RotationalInertia();

        /// <summary>
        /// Get the product rotational inertia about the 2-3 axis
        /// </summary>
        /// <returns>System.Double.</returns>
        protected abstract double Get23RotationalInertia();


        /// <summary>
        /// Gets the radius of gyration.
        /// </summary>
        /// <returns>RadiusOfGyration.</returns>
        protected virtual RadiusOfGyration GetRadiusOfGyration()
        {
            return new RadiusOfGyration(_areaGross.Value, _rotationalInertia.Value.I_22, _rotationalInertia.Value.I_33);
        }

    }
}
