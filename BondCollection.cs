// <copyright file="BondCollection.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a BondCollection.
    /// </summary>
    public class BondCollection
    {
        /// <summary>
        /// The Bonds in the BondCollection.
        /// </summary>
        /// <remarks>
        /// Bonds are arranged in a Dictionary by Nation and then as a SortedList according to the InterestPayment.
        /// </remarks>
        private readonly System.Collections.Generic.Dictionary<Nation, System.Collections.Generic.SortedList<uint, Bond>> bonds
            = new System.Collections.Generic.Dictionary<Nation, System.Collections.Generic.SortedList<uint, Bond>>();

        /// <summary>
        /// Calculates the value of the BondCollection using the Nations' current PowerFactors.
        /// </summary>
        /// <returns>The calculated total value of the BondCollection.</returns>
        public uint CalculateValue()
        {
            uint value = 0;
            foreach (System.Collections.Generic.KeyValuePair<Nation, System.Collections.Generic.SortedList<uint, Bond>> nationBonds in this.bonds)
            {
                foreach (System.Collections.Generic.KeyValuePair<uint, Bond> bond in nationBonds.Value)
                {
                    value += nationBonds.Key.PowerFactor * bond.Value.InterestPayment;
                }
            }

            return value;
        }
    }
}
