// <copyright file="Army.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements an Army, a type of Unit.
    /// </summary>
    public sealed class Army : Unit
    {
        /// <summary>
        /// Initializes a new instance of the Army class with the specified allegiance.
        /// </summary>
        /// <param name="allegiance">The allegiance of the Army.</param>
        public Army(Nation allegiance) : base(allegiance)
        {
        }

        /// <summary>
        /// Moves this Army to the specified Region.
        /// </summary>
        /// <param name="region">The Region to which to move this Army.</param>
        public override void MoveToRegion(Region region)
        {
            throw new System.NotImplementedException();
        }
    }
}
