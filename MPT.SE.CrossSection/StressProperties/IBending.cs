// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="IBending.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace MPT.SE.CrossSection.StressProperties
{
    /// <summary>
    /// Interface IBending
    /// Implements the <see cref="MPT.SE.CrossSection.StressProperties.IBendingElastic" />
    /// Implements the <see cref="MPT.SE.CrossSection.StressProperties.IBendingPlastic" />
    /// </summary>
    /// <seealso cref="MPT.SE.CrossSection.StressProperties.IBendingElastic" />
    /// <seealso cref="MPT.SE.CrossSection.StressProperties.IBendingPlastic" />
    public interface IBending : IBendingElastic, IBendingPlastic
    {
    }
}
