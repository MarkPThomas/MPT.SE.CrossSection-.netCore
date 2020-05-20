// ***********************************************************************
// Assembly         : MPT.SE.CrossSection
// Author           : Mark P Thomas
// Created          : 05-19-2020
//
// Last Modified By : Mark P Thomas
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="BendingProperties.cs" company="Mark P Thomas, Inc.">
//     Copyright (c) 2020. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace MPT.SE.CrossSection.StressProperties
{
    /// <summary>
    /// Class containing paired properties corresponding to positive/negative orientations about various axes, with some constraint relationship to major/minor axes.
    /// </summary>
    public class ConstrainedPropertiesByAxesSigned
    {
        /// <summary>
        /// Available constraints to the class for automatic assignment of numerical axes properties to major axes.
        /// Minor axes have a similar orthogonal response.
        /// </summary>
        public enum MajorAxisConstraint
        {
            /// <summary>
            /// Major axis is to be manually assigned to as it has no direct relationship to either 22- or 33-axes.
            /// </summary>
            None = 0,
            /// <summary>
            /// The positive 33-axis is the same as the positive major axis.
            /// </summary>
            Positive33 = 1,
            /// <summary>
            /// The positive 22-axis is the same as the positive major axis.
            /// </summary>
            Positive22 = 2,
            /// <summary>
            /// The negative 33-axis is the same as the positive major axis.
            /// </summary>
            Negative33 = 3,
            /// <summary>
            /// The negative 22-axis is the same as the positive major axis.
            /// </summary>
            Negative22 = 4
        }

        /// <summary>
        /// The constraint as to which axis corresponds to the major axis.
        /// Orthogonality of the other axis and axis signs determine the remaining assigments.
        /// If <see cref="Constraint"/> = <see cref="MajorAxisConstraint.None" />, Major/Minor axes are not automatically populated and may be assiged to directly.
        /// </summary>
        /// <value>The constraint.</value>
        public MajorAxisConstraint Constraint { get; internal set; } = MajorAxisConstraint.Positive33;

        /// <summary>
        /// About the 3-3 axis for positive bending.
        /// </summary>
        /// <value>The value for positive 33-axis bending.</value>
        public double Positive33 
        { 
            get { return Positive33; }
            internal set 
            {
                Positive33 = value;
                switch (Constraint)
                {
                    case MajorAxisConstraint.Positive33:
                        positiveMajor = value;
                        break;
                    case MajorAxisConstraint.Negative33:
                        negativeMajor = value;
                        break;
                    case MajorAxisConstraint.Positive22:
                        negativeMinor = value;
                        break;
                    case MajorAxisConstraint.Negative22:
                        positiveMinor = value;
                        break;
                }
                ; 
            } 
        }
        /// <summary>
        /// About the 3-3 axis for negative bending.
        /// </summary>
        /// <value>The value for negative 33-axis bending..</value>
        public double Negative33
        {
            get { return Negative33; }
            internal set
            {
                Negative33 = value;
                switch (Constraint)
                {
                    case MajorAxisConstraint.Positive33:
                        negativeMajor = value;
                        break;
                    case MajorAxisConstraint.Negative33:
                        positiveMajor = value;
                        break;
                    case MajorAxisConstraint.Positive22:
                        negativeMinor = value;
                        break;
                    case MajorAxisConstraint.Negative22:
                        positiveMinor = value;
                        break;
                }
                ;
            }
        }


        /// <summary>
        /// About the 2-2 axis for positive bending.
        /// </summary>
        /// <value>The value for positive 22-axis bending.</value>
        public double Positive22
        {
            get { return Positive22; }
            internal set
            {
                Positive22 = value;
                switch (Constraint)
                {
                    case MajorAxisConstraint.Positive33:
                        positiveMinor = value;
                        break;
                    case MajorAxisConstraint.Negative33:
                        negativeMinor = value;
                        break;
                    case MajorAxisConstraint.Positive22:
                        positiveMajor = value;
                        break;
                    case MajorAxisConstraint.Negative22:
                        negativeMajor = value;
                        break;
                }
                ;
            }
        }
        /// <summary>
        /// About the 2-2 axis for negative bending.
        /// </summary>
        /// <value>The value for negative 22-axis bending.</value>
        public double Negative22
        {
            get { return Negative22; }
            internal set
            {
                Negative22 = value;
                switch (Constraint)
                {
                    case MajorAxisConstraint.Positive33:
                        negativeMinor = value;
                        break;
                    case MajorAxisConstraint.Negative33:
                        positiveMinor = value;
                        break;
                    case MajorAxisConstraint.Positive22:
                        negativeMajor = value;
                        break;
                    case MajorAxisConstraint.Negative22:
                        positiveMajor = value;
                        break;
                }
                ;
            }
        }


        /// <summary>
        /// About the major axis for positive bending.
        /// </summary>
        private double positiveMajor;
        /// <summary>
        /// About the major axis for positive bending.
        /// Can only be assigned to directly if <see cref="Constraint" /> = <see cref="MajorAxisConstraint.None" />.
        /// Otherwise, value is automatically assigned from other axes based on <see cref="Constraint" />.
        /// </summary>
        /// <value>The value for positive major-axis bending.</value>
        public double PositiveMajor
        {
            get { return positiveMajor; }
            internal set
            {
                switch (Constraint)
                {
                    case MajorAxisConstraint.None:
                        positiveMajor = value;
                        break;
                    default:
                        break;
                }
                ;
            }
        }
        /// <summary>
        /// About the major axis for negative bending.
        /// </summary>
        private double negativeMajor;
        /// <summary>
        /// About the major axis for negative bending.
        /// Can only be assigned to directly if <see cref="Constraint" /> = <see cref="MajorAxisConstraint.None" />.
        /// Otherwise, value is automatically assigned from other axes based on <see cref="Constraint" />.
        /// </summary>
        /// <value>The value for negative major-axis bending.</value>
        public double NegativeMajor
        {
            get { return negativeMajor; }
            internal set
            {
                switch (Constraint)
                {
                    case MajorAxisConstraint.None:
                        negativeMajor = value;
                        break;
                    default:
                        break;
                }
                ;
            }
        }

        /// <summary>
        /// About the minor axis for positive bending.
        /// </summary>
        private double positiveMinor;
        /// <summary>
        /// About the minor axis for positive bending.
        /// Can only be assigned to directly if <see cref="Constraint" /> = <see cref="MajorAxisConstraint.None" />.
        /// Otherwise, value is automatically assigned from other axes based on <see cref="Constraint" />.
        /// </summary>
        /// <value>The value for positive minor-axis bending.</value>
        public double PositiveMinor
        {
            get { return positiveMinor; }
            internal set
            {
                switch (Constraint)
                {
                    case MajorAxisConstraint.None:
                        positiveMinor = value;
                        break;
                    default:
                        break;
                }
                ;
            }
        }
        /// <summary>
        /// About the minor axis for negative bending.
        /// </summary>
        private double negativeMinor;
        /// <summary>
        /// About the minor axis for negative bending.
        /// Can only be assigned to directly if <see cref="Constraint" /> = <see cref="MajorAxisConstraint.None" />.
        /// Otherwise, value is automatically assigned from other axes based on <see cref="Constraint" />.
        /// </summary>
        /// <value>The value for negative minor-axis bending.</value>
        public double NegativeMinor
        {
            get { return negativeMinor; }
            internal set
            {
                switch (Constraint)
                {
                    case MajorAxisConstraint.None:
                        negativeMinor = value;
                        break;
                    default:
                        break;
                }
                ;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstrainedPropertiesByAxesSigned"/> class.
        /// </summary>
        /// <param name="constraint">The constraint.</param>
        public ConstrainedPropertiesByAxesSigned(MajorAxisConstraint constraint = MajorAxisConstraint.Positive33)
        {
            Constraint = constraint;
        }
    }
}
