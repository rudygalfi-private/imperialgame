// <copyright file="NeutralRegion.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines a NeutralRegion, which is a type of Region.
    /// </summary>
    public abstract class NeutralRegion : Region
    {
        /// <summary>
        /// The controller of the region.
        /// </summary>
        private TaxChip controller;
    }
}
