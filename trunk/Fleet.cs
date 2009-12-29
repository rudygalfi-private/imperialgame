// <copyright file="Fleet.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a Fleet, a type of Unit.
    /// </summary>
    public sealed class Fleet : Unit
    {
        /// <summary>
        /// Initializes a new instance of the Fleet class with the specified allegiance.
        /// </summary>
        /// <param name="allegiance">The allegiance of the Fleet.</param>
        public Fleet(Nation allegiance) : base(allegiance)
        {
        }

        /// <summary>
        /// Moves this Fleet to the specified Region.
        /// </summary>
        /// <param name="region">The Region to which to move this Fleet.</param>
        public override void MoveToRegion(Region region)
        {
            throw new System.NotImplementedException();
        }
    }
}
