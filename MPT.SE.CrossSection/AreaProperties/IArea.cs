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
namespace MPT.SE.CrossSection.AreaProperties
{
    /// <summary>
    /// Interface IArea
    /// </summary>
    public interface IArea: ICentroid, IRotationalInertia, IRadiusOfGyration
    {
        /// <summary>
        /// Gross area [L^2].
        /// </summary>
        /// <value>a g.</value>
        double A_g { get; }

    }
}
