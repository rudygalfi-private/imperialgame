// <copyright file="TaxableRegion.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines a TaxableRegion, which is a type of Region.
    /// </summary>
    public abstract class TaxableRegion : Region
    {
        /// <summary>
        /// The controller of the region.
        /// </summary>
        private TaxChip controller = null;

        /// <summary>
        /// Initializes a new instance of the TaxableRegion class according to the specified definition.
        /// </summary>
        /// <param name="definition">The XML definition of this TaxableRegion.</param>
        protected TaxableRegion(System.Xml.XmlNode definition) : base(definition)
        {
        }
    }
}
