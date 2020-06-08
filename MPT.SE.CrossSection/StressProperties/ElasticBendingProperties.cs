// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="ElasticBendingProperties.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MPT.Geometry.Tools;
using MPT.Math.Coordinates;
using MPT.SE.CrossSection.AreaProperties;
using NMath = System.Math;

namespace MPT.SE.CrossSection.StressProperties
{
    /// <summary>
    /// Represents elastic bending properties of a cross section.
    /// </summary>
    public class ElasticBendingProperties
    {
        /// <summary>
        /// The distance along the 33-axis to the most distant fiber under positive bending stress about the 22-axis. [L]
        /// </summary>
        /// <value>The x positive.</value>
        public double Extents_33positive { get; }

        /// <summary>
        /// The distance along the 33-axis to the most distant fiber under negative bending stress about the 22-axis. [L]
        /// </summary>
        /// <value>The x negative.</value>
        public double Extents_33negative { get; }

        /// <summary>
        /// Elastic section modulus about the 22-axis under positive bending. [L^3]
        /// </summary>
        /// <value>The s 22positive.</value>
        public double S_22positive { get; }

        /// <summary>
        /// Elastic section modulus about the 22-axis under negative bending. [L^3]
        /// </summary>
        /// <value>The s 22negative.</value>
        public double S_22negative { get; }


        /// <summary>
        /// The distance along the 22-axis to the most distant fiber under positive bending stress about the 33-axis. [L]
        /// </summary>
        /// <value>The y positive.</value>
        public double Extents_22positive { get; }

        /// <summary>
        /// The distance along the 22-axis to the most distant fiber under negative bending stress about the 33-axis. [L]
        /// </summary>
        /// <value>The y negative.</value>
        public double Extents_22negative { get; }

        /// <summary>
        /// Elastic section modulus about the 33-axis under positive bending. [L^3]
        /// </summary>
        /// <value>The s 33positive.</value>
        public double S_33positive { get; }

        /// <summary>
        /// Elastic section modulus about the 33-axis under negative bending. [L^3]
        /// </summary>
        /// <value>The s 33negative.</value>
        public double S_33negative { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ElasticBendingProperties"/> class.
        /// </summary>
        /// <param name="extents">The extents.</param>
        /// <param name="centroid">The centroid.</param>
        /// <param name="rotationalInertia">The rotational inertia.</param>
        public ElasticBendingProperties(PointExtents extents, CartesianCoordinate centroid, MomentOfInertia rotationalInertia)
        {
            PointExtents extentsAlignedAtCentroid = CalculateExtentsAlignedAtCentroid(extents, centroid);
            Extents_33positive = NMath.Abs(extentsAlignedAtCentroid.MaxX);
            Extents_33negative = NMath.Abs(extentsAlignedAtCentroid.MinX);
            Extents_22positive = NMath.Abs(extentsAlignedAtCentroid.MaxY);
            Extents_22negative = NMath.Abs(extentsAlignedAtCentroid.MinY);

            S_22positive = CalculateElasticModulus(rotationalInertia.I_22, Extents_33positive);
            S_22negative = CalculateElasticModulus(rotationalInertia.I_22, Extents_33negative);
            S_33positive = CalculateElasticModulus(rotationalInertia.I_33, Extents_22positive);
            S_33negative = CalculateElasticModulus(rotationalInertia.I_33, Extents_22negative);
        }


        /// <summary>
        /// Calculates the extents aligned at centroid.
        /// </summary>
        /// <param name="extents">The extents.</param>
        /// <param name="centroid">The centroid.</param>
        /// <returns>PointExtents.</returns>
        public static PointExtents CalculateExtentsAlignedAtCentroid(PointExtents extents, CartesianCoordinate centroid)
        {
            PointExtents extentsAlignedAtCentroid = extents.Translate(-centroid.X, -centroid.Y) as PointExtents;

            return extentsAlignedAtCentroid;
        }

        /// <summary>
        /// Calculates the elastic modulus.
        /// </summary>
        /// <param name="rotationalInertia">The rotational inertia.</param>
        /// <param name="distanceToExtremeFiber">The distance to extreme fiber.</param>
        /// <returns>System.Double.</returns>
        public static double CalculateElasticModulus(double rotationalInertia, double distanceToExtremeFiber)
        {
           return rotationalInertia / distanceToExtremeFiber;
        }
    }
}
