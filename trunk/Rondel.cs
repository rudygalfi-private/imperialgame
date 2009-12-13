// <copyright file="Rondel.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    public enum RondelSpace : byte
    {
        Factory = 0,
        EarlyProduction,
        EarlyManeuver,
        Investor,
        Import,
        LateProduction,
        LateManeuver,
        Taxation
    }

    public enum RondelAction : byte
    {
        Factory = 0,
        Production,
        Import,
        Maneuver,
        Investor,
        Taxation
    }

    class Rondel
    {
        public RondelAction? DiscernRondelActionFromSpace(RondelSpace space)
        {
            switch (space)
            {
                case RondelSpace.Factory:
                    return RondelAction.Factory;
                case RondelSpace.EarlyProduction:
                case RondelSpace.LateProduction:
                    return RondelAction.Production;
                case RondelSpace.Import:
                    return RondelAction.Import;
                case RondelSpace.EarlyManeuver:
                case RondelSpace.LateManeuver:
                    return RondelAction.Maneuver;
                case RondelSpace.Investor:
                    return RondelAction.Investor;
                case RondelSpace.Taxation:
                    return RondelAction.Taxation;
                default:
                    return null;
            }
        }
    }
}
