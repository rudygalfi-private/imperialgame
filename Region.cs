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
        /// The XML attribute for a Region's name.
        /// </summary>
        public const string XmlNameAttribute = "name";

        /// <summary>
        /// The XML element for a Region's neighbor.
        /// </summary>
        public const string XmlNeighborElement = "Neighbor";

        /// <summary>
        /// The XML attribute for a Region's neighbor's name.
        /// </summary>
        public const string XmlNeighborNameAttribute = "name";

        /// <summary>
        /// The Name of the Region.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// A cache of the neighbors of this Region collected during the constructor load sequence.
        /// </summary>
        private readonly System.Collections.Generic.HashSet<string> cachedNeighborNames = new System.Collections.Generic.HashSet<string>();

        /// <summary>
        /// The neighbors of this Region.
        /// </summary>
        private readonly System.Collections.Generic.HashSet<Region> neighbors = new System.Collections.Generic.HashSet<Region>();

        /// <summary>
        /// The Militaries currently located in this Region.
        /// </summary>
        private readonly System.Collections.Generic.Dictionary<Nation, Military> militaries = new System.Collections.Generic.Dictionary<Nation, Military>();

        /// <summary>
        /// Initializes a new instance of the Region class according to the specified definition.
        /// </summary>
        /// <param name="definition">The XML definition of this Region.</param>
        public Region(System.Xml.XmlNode definition)
        {
            if (((System.Xml.XmlElement)definition).HasAttribute(Region.XmlNameAttribute))
            {
                this.name = ((System.Xml.XmlElement)definition).GetAttribute(Region.XmlNameAttribute);
            }
            else
            {
                //// throw UnspecifiedRegionNameException
            }

            System.Xml.XmlNodeList neighborDefinitions = ((System.Xml.XmlElement)definition).GetElementsByTagName(Region.XmlNeighborElement);
            foreach (System.Xml.XmlNode neighborDefinition in neighborDefinitions)
            {
                if (((System.Xml.XmlElement)neighborDefinition).HasAttribute(Region.XmlNeighborNameAttribute))
                {
                    string neighborName = ((System.Xml.XmlElement)neighborDefinition).GetAttribute(Region.XmlNeighborNameAttribute);
                    this.cachedNeighborNames.Add(neighborName);
                }
                else
                {
                    //// throw UnspecifiedNeighborNameException
                }
            }
        }

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

        public System.Collections.Generic.HashSet<Region> Neighbors
        {
            get
            {
                return this.neighbors;
            }
        }

        /// <summary>
        /// Gets the Militaries in this Region.
        /// </summary>
        public System.Collections.Generic.Dictionary<Nation, Military> Militaries
        {
            get
            {
                return this.militaries;
            }
        }

        public override string ToString()
        {
            string result = "[Region] ";

            result += "Name: " + this.name + ", ";

            result += "Neighbors: " + "{ ";
            bool first = true;
            foreach (Region neighbor in this.neighbors)
            {
                result += (first ? string.Empty : ", ") + neighbor.Name;
                first = false;
            }
            result += " }";

            return result;
        }

        /// <summary>
        /// Links to the neighbors of this Region.
        /// </summary>
        /// <param name="regionNameAssociations">A lookup that associates a Region's name with the Region.</param>
        /// <remarks>To be used after constructing this Region to establish links to the neighbors of this Region.</remarks>
        public void EstablishLinkToNeighbors(System.Collections.Generic.Dictionary<string, Region> regionNameAssociations)
        {
            foreach (string cachedNeighborName in this.cachedNeighborNames)
            {
                Region neighbor = regionNameAssociations[cachedNeighborName];
                this.neighbors.Add(neighbor);
            }
        }
    }
}
