// <copyright file="ArmamentsFacility.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements an ArmamentsFacility, which is a type of Factory.
    /// </summary>
    public sealed class ArmamentsFacility : HomeProvince
    {
        /// <summary>
        /// The XML element for an ArmamentsFacility.
        /// </summary>
        public const string XmlElement = "ArmamentsFacility";

        /// <summary>
        /// Initializes a new instance of the ArmamentsFacility class according to the specified definition.
        /// </summary>
        /// <param name="definition">The XML definition of this ArmamentsFacility.</param>
        public ArmamentsFacility(System.Xml.XmlNode definition) : base(definition)
        {
            System.Console.WriteLine(ArmamentsFacility.XmlElement);
        }

        /// <summary>
        /// Produces an Army.
        /// </summary>
        /// <param name="allegiance">The allegiance of the produced Unit.</param>
        public override void ProduceUnit(Nation allegiance)
        {
            this.Militaries[allegiance].Add(new Army(allegiance));
        }
    }
}
