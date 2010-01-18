// <copyright file="TaxableSeaRegion.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a TaxableSeaRegion, which is a type of TaxableRegion.
    /// </summary>
    public sealed class TaxableSeaRegion : TaxableRegion
    {
        /// <summary>
        /// The XML element for a TaxableSeaRegion.
        /// </summary>
        public const string XmlElement = "TaxableSeaRegion";

        /// <summary>
        /// Initializes a new instance of the TaxableSeaRegion class according to the specified definition.
        /// </summary>
        /// <param name="definition">The XML definition of this TaxableSeaRegion.</param>
        public TaxableSeaRegion(System.Xml.XmlNode definition) : base(definition)
        {
        }
    }
}
