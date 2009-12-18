// <copyright file="TaxChip.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a tax ship.
    /// </summary>
    public class TaxChip
    {
        /// <summary>
        /// The owner of the tax chip.
        /// </summary>
        private readonly Nation owner;

        /// <summary>
        /// Initializes a new instance of the TaxChip class.
        /// </summary>
        /// <param name="nation">The owning nation of the tax chip.</param>
        public TaxChip(Nation nation)
        {
            this.owner = nation;
        }
    }
}
