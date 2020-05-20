// ***********************************************************************
// Assembly         : 
// Author           : Mark P Thomas
// Created          : 05-18-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="IRadiusOfGyration.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace MPT.SE.CrossSection.AreaProperties
{
    /// <summary>
    /// Interface IRadiusOfGyration
    /// </summary>
    public interface IRadiusOfGyration
    {
        /// <summary>
        /// Radius of gyration about the major-axis. [L]
        /// </summary>
        /// <value>The r major.</value>
        public double r_major { get; }

        /// <summary>
        /// Radius of gyration about the minor-axis. [L]
        /// </summary>
        /// <value>The r minor.</value>
        public double r_minor { get; }
    }
}
