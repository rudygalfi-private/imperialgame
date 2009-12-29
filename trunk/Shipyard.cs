// <copyright file="Shipyard.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a Shipyard, which is a type of Factory.
    /// </summary>
    public sealed class Shipyard : HomeProvince
    {
        /// <summary>
        /// The XML element for a Shipyard.
        /// </summary>
        public const string XmlElement = "Shipyard";

        /// <summary>
        /// The XML attribute for a Shipyard's fleet entry.
        /// </summary>
        public const string XmlFleetEntryAttribute = "port";

        /// <summary>
        /// The entry Region for Fleets produced in this HomeProvince.
        /// </summary>
        private readonly string fleetEntry;

        /// <summary>
        /// Initializes a new instance of the Shipyard class according to the specified definition.
        /// </summary>
        /// <param name="definition">The XML definition of this Shipyard.</param>
        public Shipyard(System.Xml.XmlNode definition) : base(definition)
        {
            System.Console.WriteLine("Shipyard");

            if (((System.Xml.XmlElement)definition).HasAttribute(Shipyard.XmlFleetEntryAttribute))
            {
                this.fleetEntry = ((System.Xml.XmlElement)definition).GetAttribute(Shipyard.XmlFleetEntryAttribute);
                System.Console.WriteLine("\tFleet entry: {0}", this.fleetEntry);
            }
            else
            {
                //// throw UnspecifiedShipEntranceException
            }
        }

        /// <summary>
        /// Produces a Fleet.
        /// </summary>
        /// <param name="allegiance">The allegiance of the produced Unit.</param>
        public override void ProduceUnit(Nation allegiance)
        {
            this.Militaries[allegiance].Add(new Fleet(allegiance));
        }
    }
}
