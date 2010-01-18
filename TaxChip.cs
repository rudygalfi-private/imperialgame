// <copyright file="TaxChip.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a tax ship.
    /// </summary>
    public sealed class TaxChip
    {
        /// <summary>
        /// The allegiance of the tax chip.
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

        /// <summary>
        /// The owner of this Nation.
        /// </summary>
        public Nation Owner
        {
            get
            {
                return this.owner;
            }
        }
    }
}
