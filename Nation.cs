// <copyright file="Nation.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// The range of the total possible payout from the Investor action.
    /// </summary>
    /// <remarks>
    /// The minimum is defined as paying each Investor who is not the leader;
    /// the maximum is defined as paying each Investor (including the leader) fully.
    /// </remarks>
    public struct NationInvestorPayoutRange
    {
        /// <summary>
        /// The Minimum is the amount that must be paid to each Investor who is not the leader of the Nation.
        /// If the minimum cannot be paid, the Investor action cannot be taken.
        /// </summary>
        public uint Minimum;

        /// <summary>
        /// The Maximum is the amount that would be paid to meet the obligation to each Investor including the leader.
        /// If the maximum cannot be paid, the Investor action must result in the Nation's entire treasury being depleted.
        /// </summary>
        public uint Maximum;
    }

    /// <summary>
    /// Implements a nation.
    /// </summary>
    public sealed class Nation
    {
        /// <summary>
        /// The XML element for a Nation.
        /// </summary>
        public const string XmlElement = "Nation";

        /// <summary>
        /// The XML element for a Nation's name.
        /// </summary>
        private const string XmlNameAttribute = "name";

        /// <summary>
        /// The name of this Nation.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The HomeProvinces of this Nation.
        /// </summary>
        private readonly System.Collections.Generic.HashSet<HomeProvince> homeProvinces = new System.Collections.Generic.HashSet<HomeProvince>();

        /// <summary>
        /// The treasury (funds) possessed by this nation.
        /// </summary>
        private readonly BankAccount treasury = new BankAccount();

        /// <summary>
        /// The current leader of this Nation.
        /// </summary>
        private Player leader = null;

        private readonly uint taxChipQuantity = 15;

        private readonly System.Collections.Generic.Stack<TaxChip> taxChips = new System.Collections.Generic.Stack<TaxChip>();

        /// <summary>
        /// The power factor of this Nation.
        /// </summary>
        private uint powerFactor = 0;

        /// <summary>
        /// Initializes a new instance of the Nation class according to the specified definition.
        /// </summary>
        /// <param name="definition">The XML definition of this Nation.</param>
        public Nation(System.Xml.XmlNode definition)
        {
            if (((System.Xml.XmlElement)definition).HasAttribute(Nation.XmlNameAttribute))
            {
                this.name = ((System.Xml.XmlElement)definition).GetAttribute(Nation.XmlNameAttribute);
            }
            else
            {
                //// throw UnspecifiedRegionNameException
            }

            System.Xml.XmlNodeList shipyardDefinitions = ((System.Xml.XmlElement)definition).GetElementsByTagName(Shipyard.XmlElement);
            foreach (System.Xml.XmlNode shipyardDefinition in shipyardDefinitions)
            {
                Shipyard loadedShipyard = new Shipyard(shipyardDefinition);
                this.homeProvinces.Add(loadedShipyard);
            }

            System.Xml.XmlNodeList armamentsFacilityDefinitions = ((System.Xml.XmlElement)definition).GetElementsByTagName(ArmamentsFacility.XmlElement);
            foreach (System.Xml.XmlNode armamentsFacilityDefinition in armamentsFacilityDefinitions)
            {
                ArmamentsFacility loadedArmamentsFacility = new ArmamentsFacility(armamentsFacilityDefinition);
                this.homeProvinces.Add(loadedArmamentsFacility);
            }

            for (uint count = 0; count < this.taxChipQuantity; ++count)
            {
                this.taxChips.Push(new TaxChip(this));
            }
        }

        /// <summary>
        /// Gets the Name of this Nation.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the HomeProvinces of this Nation.
        /// </summary>
        public System.Collections.Generic.HashSet<HomeProvince> HomeProvinces
        {
            get
            {
                return this.homeProvinces;
            }
        }

        /// <summary>
        /// Gets the current leader of this country.
        /// </summary>
        public Player Leader
        {
            get
            {
                return this.leader;
            }
        }

        /// <summary>
        /// Gets the treasury of this Nation.
        /// </summary>
        public BankAccount Treasury
        {
            get
            {
                return this.treasury;
            }
        }

        /// <summary>
        /// Gets the power factor of this nation.
        /// </summary>
        public uint PowerFactor
        {
            get
            {
                return this.powerFactor;
            }
        }

        public override string ToString()
        {
            string result = "[Nation] ";

            result += "Name: " + this.Name + ", ";

            result += "Home Provinces: { ";
            bool first = true;
            foreach (HomeProvince homeProvince in this.HomeProvinces)
            {
                result += (first ? string.Empty : ", ") + homeProvince;
                first = false;
            }
            result += " }, ";

            result += "Treasury: " + this.Treasury.Balance;

            return result;
        }

        /// <summary>
        /// Permits the Nation to select a RondelSpace.
        /// </summary>
        /// <returns>The selected RondelSpace.</returns>
        public RondelSpace SelectRondelSpace()
        {
            // To be implemented.
            return RondelSpace.Factory;
        }

        /// <summary>
        /// Executes the action associated with the specified RondelSpace.
        /// </summary>
        /// <param name="space">The RondelSpace to have its action executed.</param>
        public void ExecuteRondelSpaceAction(RondelSpace space)
        {
            switch (space)
            {
                case RondelSpace.Factory:
                    this.BuildFactory();
                    break;

                case RondelSpace.Import:
                    this.ImportUnits();
                    break;

                case RondelSpace.EarlyProduction:
                case RondelSpace.LateProduction:
                    this.ProduceUnits();
                    break;

                case RondelSpace.EarlyManeuver:
                case RondelSpace.LateManeuver:
                    this.ManeuverUnits();
                    break;

                case RondelSpace.Investor:
                    this.PayInvestors();
                    break;

                case RondelSpace.Taxation:
                    this.CollectTaxes();
                    break;

                default:
                    // UnknownRondelSpaceException
                    break;
            }
        }

        /// <summary>
        /// Builds a Factory in this Nation.
        /// </summary>
        public void BuildFactory()
        {
            // Ask where to build the Factory
        }

        /// <summary>
        /// Imports Units into this Nation.
        /// </summary>
        public void ImportUnits()
        {
            // Ask where to import.
        }

        /// <summary>
        /// Produces Units in this Nation.
        /// </summary>
        public void ProduceUnits()
        {
            // In the future, we need to allow the user to specify where Units will be built.
            // For now, just do it everywhere we can.
            foreach (HomeProvince homeProvince in this.homeProvinces)
            {
                homeProvince.ProduceUnit(this);
            }
        }

        /// <summary>
        /// Maneuvers Units of this Nation.
        /// </summary>
        public void ManeuverUnits()
        {
            // Ask which Units to move.
        }

        /// <summary>
        /// Pays all of the investors of this Nation using the Nation's treasury.
        /// </summary>
        public void PayInvestors()
        {
            NationInvestorPayoutRange investorPayoutRange = this.CalculateInvestorPayoutRange();
        }

        /// <summary>
        /// Collects the taxes of this Nation.
        /// </summary>
        public void CollectTaxes()
        {
            // Collect taxes
        }

        public System.Collections.Generic.HashSet<Region> GetRegionsReachableFromRegion(Region origin)
        {
            System.Collections.Generic.HashSet<Region> reachableRegions = new System.Collections.Generic.HashSet<Region>();

            // Can stay put in current region.
            reachableRegions.Add(origin);

            // Check if we're starting in a HomeProvince within this Nation.
            if (origin is HomeProvince && this.HomeProvinces.Contains((HomeProvince)origin))
            {
                // We're starting within this Nation.
                // All unoccupied HomeProvinces are reachable via railroad.
                System.Collections.Generic.HashSet<Region> railroadReachableRegions = new System.Collections.Generic.HashSet<Region>();
                railroadReachableRegions.Add(origin);
                foreach (HomeProvince homeProvince in this.HomeProvinces)
                {
                    if (this.AllowsTravelViaRailroadBetweenRegions((HomeProvince)origin, homeProvince))
                    {
                        railroadReachableRegions.Add(homeProvince);
                        reachableRegions.Add(homeProvince);
                    }
                }

                // Collect together all of the Regions that are reachable in a single move.
                foreach (Region railroadReachableRegion in railroadReachableRegions)
                {
                    foreach (Region neighbor in railroadReachableRegion.Neighbors)
                    {
                        reachableRegions.Add(neighbor);
                    }
                }
            }
            else
            {
                // We're starting outside of this Nation.
                // Collect together all of the Regions that are reachable because they neighbor our starting location.
                System.Collections.Generic.HashSet<Region> neighboringReachableRegions = this.GetNeighboringReachableRegions(origin);
                neighboringReachableRegions.Add(origin);

                // Collect together all of the regions that reachable via railroad from a HomeProvince.
                foreach (Region neighboringReachableRegion in neighboringReachableRegions)
                {
                    if (this.RegionIsMyHomeProvince(neighboringReachableRegion))
                    {
                        foreach (HomeProvince homeProvince in this.HomeProvinces)
                        {
                            if (this.AllowsTravelViaRailroadBetweenRegions((HomeProvince)neighboringReachableRegion, homeProvince))
                            {
                                reachableRegions.Add(homeProvince);
                            }
                        }
                    }
                }
            }

            return reachableRegions;
        }

        private bool RegionIsMyHomeProvince(Region region)
        {
            return region is HomeProvince && this.HomeProvinces.Contains((HomeProvince)region);
        }

        private System.Collections.Generic.HashSet<Region> GetNeighboringReachableRegions(Region origin)
        {
            System.Collections.Generic.HashSet<Region> neighboringReachableRegions = new System.Collections.Generic.HashSet<Region>();

            foreach (Region neighbor in origin.Neighbors)
            {
                neighboringReachableRegions.Add(neighbor);
            }

            return neighboringReachableRegions;
        }

        private System.Collections.Generic.HashSet<Region> GetRailroadReachableRegions(HomeProvince origin)
        {
            System.Collections.Generic.HashSet<Region> railroadReachableRegions = new System.Collections.Generic.HashSet<Region>();

            foreach (HomeProvince homeProvince in this.HomeProvinces)
            {
                if (this.AllowsTravelViaRailroadBetweenRegions(origin, homeProvince))
                {
                    railroadReachableRegions.Add(homeProvince);
                }
            }

            return railroadReachableRegions;
        }

        private bool AllowsTravelViaRailroadBetweenRegions(HomeProvince origin, HomeProvince destination)
        {
            System.Collections.Generic.HashSet<HomeProvince> unoccupiedHomeProvinces = new System.Collections.Generic.HashSet<HomeProvince>(this.HomeProvinces);
            unoccupiedHomeProvinces.RemoveWhere(this.HomeProvinceIsOccupiedByHostileUnit);

            // If the origin or destination is occupied, we can't get there by railroad.
            if (unoccupiedHomeProvinces.Contains(origin) && unoccupiedHomeProvinces.Contains(destination))
            {
                // Verify that there is at least one unoccupied path joining the origin and destination.
                System.Collections.Generic.Queue<HomeProvince> homeProvinces = new System.Collections.Generic.Queue<HomeProvince>();
                System.Collections.Generic.HashSet<HomeProvince> visitedHomeProvinces = new System.Collections.Generic.HashSet<HomeProvince>();

                homeProvinces.Enqueue(origin);
                while (0 < homeProvinces.Count)
                {
                    HomeProvince currentHomeProvince = homeProvinces.Dequeue();

                    if (currentHomeProvince == destination)
                    {
                        return true;
                    }
                    else
                    {
                        visitedHomeProvinces.Add(currentHomeProvince);

                        foreach (Region neighbor in currentHomeProvince.Neighbors)
                        {
                            if (neighbor is HomeProvince && !visitedHomeProvinces.Contains((HomeProvince)neighbor))
                            {
                                homeProvinces.Enqueue((HomeProvince)neighbor);
                            }
                        }
                    }
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        private bool HomeProvinceIsOccupiedByHostileUnit(HomeProvince homeProvince)
        {
            foreach (System.Collections.Generic.KeyValuePair<Nation, Military> military in homeProvince.Militaries)
            {
                if (military.Value.IsHostileToNation(this))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Calculates the payout range for an Investor action.
        /// </summary>
        /// <returns>The payout range.</returns>
        private NationInvestorPayoutRange CalculateInvestorPayoutRange()
        {
            NationInvestorPayoutRange result;
            result.Minimum = 0;
            result.Maximum = 0;

            return result;
        }

        public TaxChip DispenseTaxChip()
        {
            if (this.taxChips.Count > 0)
            {
                return this.taxChips.Pop();
            }
            else
            {
                return null;
            }
        }

        public void CollectTaxChip(TaxChip taxChip)
        {
            if (null != taxChip)
            {
                this.taxChips.Push(taxChip);
            }
            else
            {
                //// throw NullTaxChipException
            }
        }
    }
}
