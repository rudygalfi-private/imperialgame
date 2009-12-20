// <copyright file="Nation.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines the nation names.
    /// </summary>
    public enum NationName
    {
        /// <summary>
        /// Name of Austria-Hungary
        /// </summary>
        AustriaHungary,

        /// <summary>
        /// Name of Italy
        /// </summary>
        Italy,

        /// <summary>
        /// Name of France
        /// </summary>
        France,

        /// <summary>
        /// Name of United Kingdom
        /// </summary>
        UnitedKingdom,

        /// <summary>
        /// Name of Germany
        /// </summary>
        Germany,

        /// <summary>
        /// Name of Russia
        /// </summary>
        Russia
    }

    /// <summary>
    /// Implements a nation.
    /// </summary>
    public class Nation
    {
        /// <summary>
        /// The name of this Nation.
        /// </summary>
        private readonly NationName name;

        /// <summary>
        /// The HomeProvinces of this Nation.
        /// </summary>
        private System.Collections.Generic.List<HomeProvince> homeProvinces = new System.Collections.Generic.List<HomeProvince>();

        /// <summary>
        /// The current leader of this Nation.
        /// </summary>
        private Player leader = null;

        /// <summary>
        /// The treasury (funds) possessed by this nation.
        /// </summary>
        private BankAccount treasury = new BankAccount();

        /// <summary>
        /// The power factor of this Nation.
        /// </summary>
        private uint powerFactor = 0;

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
        /// Build a Factory in the specified HomeProvince.
        /// </summary>
        public void BuildFactory()
        {
            // Ask where to build the Factory
        }

        /// <summary>
        /// Produces Units in this Nation.
        /// </summary>
        public void ProduceUnits()
        {
            // In the future, we need to allow the user to specify where Units will be built.
            // For now, just do it everywhere we can.
            foreach (HomeProvince hp in this.homeProvinces)
            {
                hp.ProduceUnit();
            }
        }

        /// <summary>
        /// Pays all of the investors of this nation using the nation's treasury.
        /// </summary>
        /// <returns>Whether the payout to investors succeeded.</returns>
        public bool PayInvestors()
        {
            return false;
        }
    }
}
