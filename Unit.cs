﻿// <copyright file="Unit.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines a Unit.
    /// </summary>
    public abstract class Unit
    {
        /// <summary>
        /// The allegiance of this Unit.
        /// </summary>
        private readonly Nation allegiance;

        /// <summary>
        /// Whether this unit has used its move for the turn.
        /// </summary>
        private bool hasMovedDuringTurn = false;

        /// <summary>
        /// Initializes a new instance of the Unit class with the specified allegiance.
        /// </summary>
        /// <param name="allegiance">The allegiance of this Unit.</param>
        protected Unit(Nation allegiance)
        {
            this.allegiance = allegiance;
        }

        /// <summary>
        /// Gets a value indicating whether this Unit has moved during a turn.
        /// </summary>
        protected bool HasMovedDuringTurn
        {
            get
            {
                return this.hasMovedDuringTurn;
            }
        }

        /// <summary>
        /// Moves this Unit to the specified Region.
        /// </summary>
        /// <param name="region">The Region to which to move this Unit.</param>
        public abstract void MoveToRegion(Region region);
    }
}