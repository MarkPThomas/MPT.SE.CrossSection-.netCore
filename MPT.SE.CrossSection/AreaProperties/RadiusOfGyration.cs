// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="RadiusOfGyration.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MPT.Math;

namespace MPT.SE.CrossSection.AreaProperties
{
    /// <summary>
    /// Represents radius of gyration properties of a cross section.
    /// </summary>
    public class RadiusOfGyration
    {
        /// <summary>
        /// Radius of gyration about the 22-axis. [L]
        /// </summary>
        /// <value>The R22.</value>
        public double r22 { get; }
        /// <summary>
        /// Radius of gyration about the 33-axis. [L]
        /// </summary>
        /// <value>The R33.</value>
        public double r33 { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RadiusOfGyration"/> class.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <param name="i22">Moment of inertia about the 22-axis.</param>
        /// <param name="i33">Moment of inertia about the 33-axis.</param>
        public RadiusOfGyration(double area, double i22, double i33)
        {
            r22 = Calculate(i22, area);
            r33 = Calculate(i33, area);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="AreaProperties.RadiusOfGyration" /> class.
        /// </summary>
        /// <param name="rotationalInertia">The rotational inertia considered.</param>
        /// <param name="areaGross">The gross area of the cross section.</param>
        /// <returns>System.Double.</returns>
        public static double Calculate(
            double rotationalInertia,
            double areaGross)
        {
            return Numbers.Sqrt(rotationalInertia / areaGross);
        }
    }
}
