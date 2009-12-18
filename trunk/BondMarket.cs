// <copyright file="BondMarket.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements the BondMarket.
    /// </summary>
    /// <remarks>
    /// There is only one BondMarket allowed at a time.
    /// </remarks>
    public class BondMarket
    {
        /// <summary>
        /// The instance of the BondMarket.
        /// </summary>
        private static readonly BondMarket instance;

        /// <summary>
        /// The Bonds in the BondMarket.
        /// </summary>
        private System.Collections.Generic.List<Bond> bonds = new System.Collections.Generic.List<Bond>();

        /// <summary>
        /// Initializes static members of the BondMarket class.
        /// </summary>
        static BondMarket()
        {
            instance = new BondMarket();
        }

        /// <summary>
        /// Gets the instance of the BondMarket.
        /// </summary>
        public static BondMarket Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
