// <copyright file="Player.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a Player.
    /// </summary>
    public sealed class Player
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
        private readonly BondCollection bonds = new BondCollection();

        /// <summary>
        /// Initializes a new instance of the Player class with the specified amount of money.
        /// </summary>
        /// <param name="name">The name of this Player.</param>
        /// <param name="initialMoney">The initial amount of money for this Player.</param>
        public Player(string name, uint initialMoney)
        {
            this.name = name;
            this.money = new BankAccount(initialMoney);
        }

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
            return this.bonds.CalculateValue() + this.money.Balance;
        }
    }
}
