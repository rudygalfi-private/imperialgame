// <copyright file="Player.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a Player.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The name of the Player.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The money held by this Player.
        /// </summary>
        private readonly BankAccount money;

        /// <summary>
        /// The bonds held by this Player.
        /// </summary>
        private System.Collections.Generic.List<Bond> bonds;

        /// <summary>
        /// Gets the name of this player.
        /// </summary>
        public string Name
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Gets the money of this Player.
        /// </summary>
        public BankAccount Money
        {
            get
            {
                return this.money;
            }
        }

        /// <summary>
        /// Calculates this player's score.
        /// </summary>
        /// <returns>The calculated score.</returns>
        public uint CalculateScore()
        {
            uint score = 0;

            foreach (Bond b in this.bonds)
            {
                score += b.IssuingNation.PowerFactor * b.InterestPayment;
            }

            return score;
        }
    }
}
