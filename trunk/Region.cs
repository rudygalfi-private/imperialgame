// <copyright file="Region.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines a region.
    /// </summary>
    public abstract class Region
    {
        /// <summary>
        /// The Name of the Region.
        /// </summary>
        private string name = null;

        /// <summary>
        /// Gets the Name of the Region.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }
    }
}
