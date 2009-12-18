// <copyright file="HomeProvince.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines a Home Province, which is a type of Region.
    /// </summary>
    public abstract class HomeProvince : Region
    {
        /// <summary>
        /// The Factory of this HomeProvince.
        /// </summary>
        private Factory factory = null;
    }
}
