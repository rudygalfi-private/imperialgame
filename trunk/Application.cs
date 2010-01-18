// <copyright file="Application.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Implements an application to play Imperial.
    /// </summary>
    public sealed class Application
    {
        /// <summary>
        /// Parse any command line arguments to set up this GameInstance and run the game.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            // Figure out the number of players.
            uint playerCount = 0;

            // The number of command line parameters tells us if we have had the number of players defined.
            if (args.Length == 1)
            {
                playerCount = Application.PlayerCountFromString(args[0]);
            }

            System.Console.Write("Absolute path of map file to load: ");
            string mapFilePath = System.Console.ReadLine();

            // Create the game and run it.
            Game game = new Game(mapFilePath, playerCount);
            game.Run();
        }

        /// <summary>
        /// Converts from a string meant to represent a number of players to an AllowablePlayerCount? representing the same.
        /// </summary>
        /// <param name="stringCountOfPlayers">A string representing the number of players.</param>
        /// <returns>The Allowable PlayerCount corresponding to the given string or null if no match can be found.</returns>
        public static uint PlayerCountFromString(string playerCountText)
        {
            // We have had the number of players specified. Try reading it.
            uint playerCount = 0;
            bool conversionSucceeded = uint.TryParse(playerCountText, out playerCount);

            return conversionSucceeded ? playerCount : 0;
        }
    }
}
