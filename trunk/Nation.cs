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
        /// The name of this nation.
        /// </summary>
        private readonly NationName name;
        
        /// <summary>
        /// The treasury (funds) possessed by this nation.
        /// </summary>
        private BankAccount treasury = null;

        /// <summary>
        /// The HomeProvinces of this Nation.
        /// </summary>
        private System.Collections.Generic.List<HomeProvince> homeProvinces = new System.Collections.Generic.List<HomeProvince>();

        /// <summary>
        /// Moves this nation to the designated space on the rondel.
        /// </summary>
        /// <param name="space">The rondel space to move to.</param>
        /// <returns>Whether the move to the space was successful.</returns>
        public bool MoveRondelMarker(RondelSpace space)
        {
            // Check to make sure that the nation can pay out when moving to Investor.
            return false;
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
