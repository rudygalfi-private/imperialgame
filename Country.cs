// <copyright file="Country.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines the country names.
    /// </summary>
    public enum CountryName : short
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
    /// Implements a country.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// The name of this country.
        /// </summary>
        private CountryName name;
        
        /// <summary>
        /// The treasury (funds) possessed by this country.
        /// </summary>
        private BankAccount treasury;

        /// <summary>
        /// The unsold bonds held by this country.
        /// </summary>
        private BondCollection bonds;

        /// <summary>
        /// Moves this country to the designated space on the rondel.
        /// </summary>
        /// <param name="space">The rondel space to move to.</param>
        /// <returns>Whether the move to the space was successful.</returns>
        public bool MoveRondelMarker(RondelSpace space)
        {
            // Check to make sure that the country can pay out when moving to Investor.
            return false;
        }

        /// <summary>
        /// Pays all of the investors of this country using the country's treasury.
        /// </summary>
        /// <returns>Whether the payout to investors succeeded.</returns>
        public bool PayInvestors()
        {
            return false;
        }
    }
}
