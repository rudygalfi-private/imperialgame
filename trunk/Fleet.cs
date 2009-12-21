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
        /// Moves this Fleet to the specified Region.
        /// </summary>
        /// <param name="region">The Region to which to move this Fleet.</param>
        public override void MoveToRegion(Region region)
        {
            throw new System.NotImplementedException();
        }
    }
}
