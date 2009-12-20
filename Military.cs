// <copyright file="Military.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a Military.
    /// </summary>
    public class Military
    {
        /// <summary>
        /// Fleets in the Military.
        /// </summary>
        private System.Collections.Generic.List<Fleet> fleets = new System.Collections.Generic.List<Fleet>();

        /// <summary>
        /// Armies in the Military.
        /// </summary>
        private System.Collections.Generic.List<Army> armies = new System.Collections.Generic.List<Army>();

        /// <summary>
        /// Adds the specified Unit to the Military.
        /// </summary>
        /// <param name="unit">The Unit to add.</param>
        public void Add(Unit unit)
        {
            if (unit is Fleet)
            {
                this.fleets.Add((Fleet)unit);
            }
            else if (unit is Army)
            {
                this.armies.Add((Army)unit);
            }
        }

        /// <summary>
        /// Kills the specified Unit, removing it from the Military.
        /// </summary>
        /// <param name="unit">The Unit to kill.</param>
        public void Kill(Unit unit)
        {
            if (unit is Fleet)
            {
                this.fleets.Remove((Fleet)unit);
            }
            else if (unit is Army)
            {
                this.armies.Remove((Army)unit);
            }
        }
    }
}
