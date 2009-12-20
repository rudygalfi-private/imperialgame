// <copyright file="Game.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Definition of the range of the allowable count of players for a single game.
    /// </summary>
    public enum GameAllowablePlayerCount
    {
        /// <summary>
        /// Represents two players.
        /// </summary>
        Two = 2,

        /// <summary>
        /// Represents three players.
        /// </summary>
        Three = 3,

        /// <summary>
        /// Represents four players.
        /// </summary>
        Four = 4,

        /// <summary>
        /// Represents five players.
        /// </summary>
        Five = 5,

        /// <summary>
        /// Represents six players.
        /// </summary>
        Six = 6
    }

    /// <summary>
    /// Implements a game defined by its count of players.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The count of players for this game.
        /// </summary>
        private GameAllowablePlayerCount playerCount;

        /// <summary>
        /// Initializes a new instance of the Game class.
        /// </summary>
        /// <param name="pc">The number of players for this game.</param>
        public Game(GameAllowablePlayerCount pc)
        {
            this.playerCount = pc;
        }

        /// <summary>
        /// Gets or sets the count of players for this game.
        /// </summary>
        public GameAllowablePlayerCount PlayerCount
        {
            get
            {
                return this.playerCount;
            }

            set
            {
                this.playerCount = value;
            }
        }

        /// <summary>
        /// Run the main game loop until we're told to exit.
        /// </summary>
        public void Run()
        {
            // Flag to indicate when to exit this application.
            bool quitFlag = false;

            // Loop infinitely if we don't want to exit.
            do
            {
                // Get a quit flag somehow.
            }
            while (!quitFlag);
        }
    }
}
