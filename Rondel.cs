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
    /// A listing of all the game phases.
    /// </summary>
    public enum Phase
    {
        /// <summary>
        /// The Factory phase.
        /// </summary>
        Factory = 0,

        /// <summary>
        /// The Production phase.
        /// </summary>
        Production,

        /// <summary>
        /// The Import phase.
        /// </summary>
        Import,

        /// <summary>
        /// The Maneuver phase.
        /// </summary>
        Maneuver,

        /// <summary>
        /// The Investor phase.
        /// </summary>
        Investor,

        /// <summary>
        /// The Taxation phase.
        /// </summary>
        Taxation
    }

    /// <summary>
    /// Implements the rondel.
    /// </summary>
    public class Rondel
    {
        /// <summary>
        /// Discerns the phase corresponding to the supplied rondel space.
        /// </summary>
        /// <param name="space">The rondel space for which to discern a phase.</param>
        /// <returns>The phase corrseponding to the given rondel space.</returns>
        public Phase? DiscernPhaseFromRondelSpace(RondelSpace space)
        {
            switch (space)
            {
                case RondelSpace.Factory:
                    return Phase.Factory;
                case RondelSpace.EarlyProduction:
                case RondelSpace.LateProduction:
                    return Phase.Production;
                case RondelSpace.Import:
                    return Phase.Import;
                case RondelSpace.EarlyManeuver:
                case RondelSpace.LateManeuver:
                    return Phase.Maneuver;
                case RondelSpace.Investor:
                    return Phase.Investor;
                case RondelSpace.Taxation:
                    return Phase.Taxation;
                default:
                    return null;
            }
        }
    }
}
