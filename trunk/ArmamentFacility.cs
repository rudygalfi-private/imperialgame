// <copyright file="ArmamentFacility.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements an ArmamentFacility, which is a type of Factory.
    /// </summary>
    public sealed class ArmamentFacility : Factory
    {
        /// <summary>
        /// Produces an Army.
        /// </summary>
        /// <returns>The produced Army.</returns>
        public override Unit Produce()
        {
            //// Will produce Armies.

            return new Army();
        }
    }
}
