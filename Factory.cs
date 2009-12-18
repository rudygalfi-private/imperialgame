// <copyright file="Factory.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines a Home Province, which is a type of Region.
    /// </summary>
    public abstract class Factory
    {
        /// <summary>
        /// Produces a Unit.
        /// </summary>
        /// <returns>The produced Unit.</returns>
        public abstract Unit Produce();
    }
}
