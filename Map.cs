// <copyright file="Map.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a Map.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// The XML element for a Map.
        /// </summary>
        public const string XmlElement = "Map";

        /// <summary>
        /// The Nations for this Map.
        /// </summary>
        /// <remarks>The Nations are ordered by their playing order.</remarks>
        private readonly System.Collections.Generic.List<Nation> nations = new System.Collections.Generic.List<Nation>();

        /// <summary>
        /// The TaxableRegions for this Map.
        /// </summary>
        private readonly System.Collections.Generic.HashSet<TaxableRegion> taxableRegions = new System.Collections.Generic.HashSet<TaxableRegion>();

        /// <summary>
        /// Initializes a new instance of the Map class according to the specified definition.
        /// </summary>
        /// <param name="mapDefinition">The XML definition of this Map.</param>
        public Map(System.Xml.XmlNode mapDefinition)
        {
            // Keep a listing of associations between Region names and the actual Region.
            // This will be used during a second pass to link Regions' neighbors together.
            System.Collections.Generic.Dictionary<string, Region> regionNameAssociations = new System.Collections.Generic.Dictionary<string, Region>();

            // Retrieve the Map-level nodes: Nations and TaxableRegions (split into Sea and Land).
            System.Xml.XmlNodeList nationDefinitions = ((System.Xml.XmlElement)mapDefinition).GetElementsByTagName(Nation.XmlElement);
            System.Xml.XmlNodeList taxableSeaRegionDefinitions = ((System.Xml.XmlElement)mapDefinition).GetElementsByTagName(TaxableSeaRegion.XmlElement);
            System.Xml.XmlNodeList taxableLandRegionDefinitions = ((System.Xml.XmlElement)mapDefinition).GetElementsByTagName(TaxableLandRegion.XmlElement);

            // Load the Nations.
            foreach (System.Xml.XmlNode nationDefinition in nationDefinitions)
            {
                Nation loadedNation = new Nation(nationDefinition);
                this.nations.Add(loadedNation);

                foreach (HomeProvince homeProvince in loadedNation.HomeProvinces)
                {
                    regionNameAssociations.Add(homeProvince.Name, homeProvince);
                }
            }

            // Load the TaxableRegions: first the Sea ones.
            foreach (System.Xml.XmlNode taxableSeaRegionDefinition in taxableSeaRegionDefinitions)
            {
                TaxableSeaRegion loadedTaxableSeaRegion = new TaxableSeaRegion(taxableSeaRegionDefinition);
                this.taxableRegions.Add(loadedTaxableSeaRegion);

                regionNameAssociations.Add(loadedTaxableSeaRegion.Name, loadedTaxableSeaRegion);
            }
            
            // Load the TaxableRegions: next the Land ones.
            foreach (System.Xml.XmlNode taxableLandRegionDefinition in taxableLandRegionDefinitions)
            {
                TaxableLandRegion loadedTaxableLandRegion = new TaxableLandRegion(taxableLandRegionDefinition);
                this.taxableRegions.Add(loadedTaxableLandRegion);

                regionNameAssociations.Add(loadedTaxableLandRegion.Name, loadedTaxableLandRegion);
            }

            // Now that we've loaded every Region we can have,
            // iterate through them all again and link the neighbors.
            foreach (System.Collections.Generic.KeyValuePair<string, Region> regionNameAssociation in regionNameAssociations)
            {
                regionNameAssociation.Value.ConnectToNeighbors(regionNameAssociations);
            }
        }

        /// <summary>
        /// Gets the Nations of this Map.
        /// </summary>
        public System.Collections.Generic.List<Nation> Nations
        {
            get
            {
                return this.nations;
            }
        }

        /// <summary>
        /// Gets the TaxableRegions of this Map.
        /// </summary>
        public System.Collections.Generic.HashSet<TaxableRegion> TaxableRegions
        {
            get
            {
                return this.taxableRegions;
            }
        }
    }
}
