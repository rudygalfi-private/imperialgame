// <copyright file="Rondel.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// An ordered listing of all of the rondel spaces.
    /// </summary>
    public enum RondelSpace
    {
        /// <summary>
        /// The Factory space.
        /// </summary>
        Factory = 0,

        /// <summary>
        /// The Production space before Investor.
        /// </summary>
        EarlyProduction,

        /// <summary>
        /// The Maneuver space before Investor.
        /// </summary>
        EarlyManeuver,

        /// <summary>
        /// The Investor space.
        /// </summary>
        Investor,

        /// <summary>
        /// The Import space.
        /// </summary>
        Import,

        /// <summary>
        /// The Production space after Investor.
        /// </summary>
        LateProduction,

        /// <summary>
        /// The Maneuver space after Investor.
        /// </summary>
        LateManeuver,

        /// <summary>
        /// The Taxation space.
        /// </summary>
        Taxation
    }

    /// <summary>
    /// The calculation for determining the cost of moving an additional space on the Rondel.
    /// </summary>
    public enum RondelExtraMovementCost
    {
        /// <summary>
        /// Costs increase at a constant rate:
        /// 2 million per space.
        /// </summary>
        Constant2,

        /// <summary>
        /// Costs increase at a constant rate based on the Nation's PowerFactor (PF):
        /// (1+PF) million per space.
        /// </summary>
        ConstantByPower
    }

    /// <summary>
    /// Implements the rondel.
    /// </summary>
    public class Rondel
    {
        /// <summary>
        /// The RondelPosition of each Nation on the Rondel.
        /// </summary>
        private readonly System.Collections.Generic.Dictionary<Nation, RondelSpace> nationPositions = new System.Collections.Generic.Dictionary<Nation, RondelSpace>();

        /// <summary>
        /// The maximum number of spaces that can be moved for one turn.
        /// </summary>
        private readonly uint maximumMovementSpaces;

        /// <summary>
        /// The number of spaces that can be moved to at no cost.
        /// </summary>
        private readonly uint freeMovementSpaces;

        /// <summary>
        /// The per-space cost of movement on the rondel beyond the number of free movement spaces.
        /// </summary>
        private readonly RondelExtraMovementCost extraMovementCost;

        /// <summary>
        /// Initializes a new instance of the Rondel class with the specified PerSpaceRondelMovementCost specified.
        /// </summary>
        /// <param name="maximumMovementSpaces">The maximum number of spaces that can be moved on the Rondel at once.</param>
        /// <param name="freeMovementSpaces">The maximum number of spaces that can be moved on the Rondel at no cost.</param>
        /// <param name="extraMovementCost">The calculation for determining the cost of moving an additional space on the Rondel.</param>
        private Rondel(uint maximumMovementSpaces, uint freeMovementSpaces, RondelExtraMovementCost extraMovementCost)
        {
            this.maximumMovementSpaces = maximumMovementSpaces;
            this.freeMovementSpaces = freeMovementSpaces;
            this.extraMovementCost = extraMovementCost;
        }

        /// <summary>
        /// Moves the specified Nation to the specified new position.
        /// </summary>
        /// <param name="nation">The Nation that is moving.</param>
        /// <param name="newPosition">The new Rondel space to move to.</param>
        /// <returns>Whether the move was successful.</returns>
        public bool Move(Nation nation, RondelSpace newPosition)
        {
            // Check if we have a position for this Nation on the Rondel.
            if (this.nationPositions.ContainsKey(nation))
            {
                // Get its current position.
                RondelSpace currentPosition = this.nationPositions[nation];

                // See if we're allowed to make a move of this size.
                if (this.IsValidMove(currentPosition, newPosition))
                {
                    uint movementCost = this.CalculateMovementCost(Rondel.CalculateSpaceDistance(currentPosition, newPosition), nation);
                    uint movementPayment = nation.Leader.Money.Withdraw(movementCost, false);

                    // Check that we paid the correct amount.
                    if (movementPayment == movementCost)
                    {
                        // If so, we can move to the new space.
                        this.nationPositions[nation] = newPosition;
                        return true;
                    }
                    else
                    {
                        // If not, ensure that we didn't pay anything.
                        if (0 == movementPayment)
                        {
                            // We don't have enough money to move to this space.
                            return false;
                        }
                        else
                        {
                            // We paid some money but not the amount we were supposed to.
                            //// SomeException
                        }
                    }
                }
                else
                {
                    return false;
                }

                return true; // or false!
            }
            else
            {
                // This is the first move, so we have nothing so far.
                // Allow a move to any space.
                this.nationPositions[nation] = newPosition;
                return true;
            }
        }

        /// <summary>
        /// Calculates the distance between two spaces on the Rondel.
        /// </summary>
        /// <param name="start">The starting RondelSpace.</param>
        /// <param name="end">The ending RondelSpace.</param>
        /// <returns>The number of spaces traveled in moving from the start space to the end space.</returns>
        private static uint CalculateSpaceDistance(RondelSpace start, RondelSpace end)
        {
            uint startIndex = (uint)start;
            uint endIndex = (uint)end;
            uint totalRondelSpaces = (uint)System.Enum.GetValues(typeof(RondelSpace)).Length;

            // Because the Rondel is circular, indices loop back to the start.
            // Therefore, add the total number of spaces on the rondel to the ending index
            // if the ending index is smaller than the starting index.
            if (endIndex < startIndex)
            {
                return (endIndex + totalRondelSpaces) - startIndex;
            }
            else
            {
                return endIndex - startIndex;
            }
        }

        /// <summary>
        /// Determines if it is valid to move between the two specified Rondel spaces.
        /// </summary>
        /// <param name="start">The starting space.</param>
        /// <param name="end">The ending space.</param>
        /// <returns>Whether it is valid to move between the two specified spaces.</returns>
        private bool IsValidMove(RondelSpace start, RondelSpace end)
        {
            uint distance = Rondel.CalculateSpaceDistance(start, end);
            return 0 < distance && distance < this.maximumMovementSpaces;
        }

        /// <summary>
        /// Calculates the cost of moving the specified number of spaces on the Rondel.
        /// </summary>
        /// <param name="spaces">The number of spaces to move.</param>
        /// <param name="nation">The Nation that will be moving.</param>
        /// <returns>The cost of moving between the two specified spaces.</returns>
        private uint CalculateMovementCost(uint spaces, Nation nation)
        {
            switch (this.extraMovementCost)
            {
                case RondelExtraMovementCost.Constant2:
                    return 2 * spaces;

                case RondelExtraMovementCost.ConstantByPower:
                    return 1 + (spaces * nation.PowerFactor);

                default:
                    //// RondelExtraMovementCostException
                    return 0;
            }
        }
    }
}
