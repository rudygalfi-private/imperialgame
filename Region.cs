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
        private string name = string.Empty;

        /// <summary>
        /// The domestic Military currently located in this Region.
        /// </summary>
        private Military domesticMilitary = new Military();

        /// <summary>
        /// The foreign Militaries currently located in this Region.
        /// </summary>
        private System.Collections.Generic.List<Military> foreignMilitaries = new System.Collections.Generic.List<Military>();

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

        /// <summary>
        /// Gets the Domestic Military of this Region.
        /// </summary>
        protected Military DomesticMilitary
        {
            get
            {
                return this.domesticMilitary;
            }
        }

        /// <summary>
        /// Gets the ForeignMilitaries of this Region.
        /// </summary>
        protected System.Collections.Generic.List<Military> ForeignMilitaries
        {
            get
            {
                return this.foreignMilitaries;
            }
        }
    }
}
