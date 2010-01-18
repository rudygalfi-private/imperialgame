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
        /// A cache of the entry Region for Fleets produced in this HomeProvince.
        /// </summary>
        private readonly string cachedFleetEntry;

        /// <summary>
        /// The entry Region for Fleets produced in this HomeProvince.
        /// </summary>
        private Region fleetEntry;

        /// <summary>
        /// Initializes a new instance of the Shipyard class according to the specified definition.
        /// </summary>
        /// <param name="definition">The XML definition of this Shipyard.</param>
        public Shipyard(System.Xml.XmlNode definition) : base(definition)
        {
            if (((System.Xml.XmlElement)definition).HasAttribute(Shipyard.XmlFleetEntryAttribute))
            {
                this.cachedFleetEntry = ((System.Xml.XmlElement)definition).GetAttribute(Shipyard.XmlFleetEntryAttribute);
            }
            else
            {
                //// throw UnspecifiedShipEntranceException
            }
        }

        public override string ToString()
        {
            string result = base.ToString() + " [Shipyard] ";

            result += "Fleet Entry: " + this.fleetEntry;

            return result;
        }

        /// <summary>
        /// Link to the fleet entry of this Shipyard.
        /// </summary>
        /// <param name="regionNameAssociations">A lookup that associates a Region's name with the Region.</param>
        /// <remarks>To be used after constructing this Shipyard to establish a link to the fleet entry of this Shipyard.</remarks>
        public void EstablishLinkToFleetEntry(System.Collections.Generic.Dictionary<string, Region> regionNameAssociations)
        {
            this.fleetEntry = regionNameAssociations[this.cachedFleetEntry];
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
