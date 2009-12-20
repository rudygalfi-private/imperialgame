// <copyright file="Factory.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines the types of Factory.
    /// </summary>
    public enum FactoryType
    {
        /// <summary>
        /// A Shipyard that produces Fleets.
        /// </summary>
        Shipyard,

        /// <summary>
        /// An ArmamentFacility that produces Armies.
        /// </summary>
        ArmamentFacility
    }

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
