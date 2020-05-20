// ***********************************************************************
// Assembly         : 
// Author           : Mark P Thomas
// Created          : 05-18-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="IBendingElastic.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MPT.SE.CrossSection.StressProperties

{
    /// <summary>
    /// Interface IBendingElastic
    /// </summary>
    public interface IBendingElastic 
    {
        /// <summary>
        /// Elastic section modulus about the major-axis under positive bending. [L^3]
        /// </summary>
        /// <value>The s major positive.</value>
        public double S_majorPositive { get; }

        /// <summary>
        /// Elastic section modulus about the major-axis under negative bending. [L^3]
        /// </summary>
        /// <value>The s major negative.</value>
        public double S_majorNegative { get; }

        /// <summary>
        /// Elastic section modulus about the minor-axis under positive bending. [L^3]
        /// </summary>
        /// <value>The s minor positive.</value>
        public double S_minorPositive { get; }

        /// <summary>
        /// Elastic section modulus about the minor-axis under negative bending. [L^3]
        /// </summary>
        /// <value>The s minor negative.</value>
        public double S_minorNegative { get; }
    }
}
