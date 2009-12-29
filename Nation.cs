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
                System.Console.WriteLine("\tName: {0}", this.name);
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
    }
}
