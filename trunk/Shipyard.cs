// <copyright file="Shipyard.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a Shipyard, which is a type of Factory.
    /// </summary>
    public class Shipyard : Factory
    {
        /// <summary>
        /// Produces a Fleet.
        /// </summary>
        /// <returns>The produced Fleet.</returns>
        public override Unit Produce()
        {
            //// Will produce Fleets.

            return new Fleet();
        }
    }
}
