﻿// <copyright file="Application.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Implements an application to play Imperial.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Parse any command line arguments to set up this GameInstance and run the game.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {   
            // Figure out the number of players.
            GameAllowablePlayerCount? allowedCountOfPlayers = null;

            // The number of command line parameters tells us if we have had the number of players defined.
            if (args.Length == 1)
            {
                allowedCountOfPlayers = Application.AllowablePlayerCountFromString(args[0]);
            }

            // Create the game.
            Game gameToPlay = new Game(allowedCountOfPlayers ?? GameAllowablePlayerCount.Two);
            
            // And run it.
            gameToPlay.Run();
        }

        /// <summary>
        /// Converts from a string meant to represent a number of players to an AllowablePlayerCount? representing the same.
        /// </summary>
        /// <param name="stringCountOfPlayers">A string representing the number of players.</param>
        /// <returns>The Allowable PlayerCount corresponding to the given string or null if no match can be found.</returns>
        public static GameAllowablePlayerCount? AllowablePlayerCountFromString(string stringCountOfPlayers)
        {
            // We have had the number of players specified. Try reading it.
            uint convertedCountOfPlayers = 0;
            bool conversionSucceeded = uint.TryParse(stringCountOfPlayers, out convertedCountOfPlayers);

            // If the conversion succeeded, try to match it to a valid player count.
            GameAllowablePlayerCount? matchedCountOfPlayers = null;

            if (conversionSucceeded)
            {
                switch (convertedCountOfPlayers)
                {
                    case 2:
                        matchedCountOfPlayers = GameAllowablePlayerCount.Two;
                        break;

                    case 3:
                        matchedCountOfPlayers = GameAllowablePlayerCount.Three;
                        break;

                    case 4:
                        matchedCountOfPlayers = GameAllowablePlayerCount.Four;
                        break;

                    case 5:
                        matchedCountOfPlayers = GameAllowablePlayerCount.Five;
                        break;

                    case 6:
                        matchedCountOfPlayers = GameAllowablePlayerCount.Six;
                        break;
                }
            }

            return matchedCountOfPlayers;
        }
    }
}
