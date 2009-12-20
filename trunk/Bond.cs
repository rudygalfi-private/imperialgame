// <copyright file="Bond.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines a bond.
    /// </summary>
    public struct Bond
    {
        /// <summary>
        /// The name of the nation that issued the bond.
        /// </summary>
        public Nation IssuingNation;

        /// <summary>
        /// The face value of the bond when bought.
        /// </summary>
        public uint FaceValue;

        /// <summary>
        /// The interest paid to the holder of the bond during the Investor phase.
        /// </summary>
        public uint InterestPayment;
    }
}
