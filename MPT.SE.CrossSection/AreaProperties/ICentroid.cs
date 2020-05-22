// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="IArea.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MPT.Math.Coordinates;

namespace MPT.SE.CrossSection.AreaProperties
{
    /// <summary>
    /// Interface ICentroid
    /// </summary>
    public interface ICentroid
    {
        /// <summary>
        /// The center of gravity (elastic neutral axis) offset from the geometric center of the extents along the 22-axis.  [L]
        /// </summary>
        /// <value>The center of gravity.</value>
        double CentroidOffset_22 { get; }
        /// <summary>
        /// The center of gravity (elastic neutral axis) offset from the geometric center of the extents along the 22-axis.  [L]
        /// </summary>
        /// <value>The center of gravity.</value>
        double CentroidOffset_33 { get; }
    }
}
