// <copyright file="TaxableLandRegion.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a TaxableLandRegion, which is a type of TaxableRegion.
    /// </summary>
    public sealed class TaxableLandRegion : TaxableRegion
    {
        /// <summary>
        /// The XML element for a TaxableLandRegion.
        /// </summary>
        public const string XmlElement = "TaxableLandRegion";

        /// <summary>
        /// Initializes a new instance of the TaxableLandRegion class according to the specified definition.
        /// </summary>
        /// <param name="definition">The XML definition of this TaxableLandRegion.</param>
        public TaxableLandRegion(System.Xml.XmlNode definition) : base(definition)
        {
        }
    }
}
