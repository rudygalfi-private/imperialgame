﻿// <copyright file="Game.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Definition of the range of the allowable count of players for a single game.
    /// </summary>
    public enum GamePlayerCount
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
        /// The count of players for this Game.
        /// </summary>
        private readonly GamePlayerCount playerCount;

        /// <summary>
        /// The Map for this Game.
        /// </summary>
        private readonly Map map;

        /// <summary>
        /// The Rondel for this Game.
        /// </summary>
        private readonly Rondel rondel = new Rondel(6, 3, RondelExtraMovementCost.Constant2);

        /// <summary>
        /// Initializes a new instance of the Game class.
        /// </summary>
        /// <param name="mapFilePath">The path to the map file to load.</param>
        /// <param name="playerCount">The number of players for this game.</param>
        public Game(string mapFilePath, GamePlayerCount playerCount)
        {
            this.playerCount = playerCount;

            System.Xml.XmlDocument mapDefinitionDocument = new System.Xml.XmlDocument();
            mapDefinitionDocument.Load(mapFilePath);

            System.Xml.XmlNodeList maps = mapDefinitionDocument.GetElementsByTagName(Map.XmlElement);

            if (1 == maps.Count)
            {
                this.map = new Map(maps.Item(0));
            }
            else
            {
                //// throw InvalidMapCountException
            }
        }

        /// <summary>
        /// Gets the count of players for this game.
        /// </summary>
        public GamePlayerCount PlayerCount
        {
            get
            {
                return this.playerCount;
            }
        }

        /// <summary>
        /// Gets the Map of this Game.
        /// </summary>
        public Map Map
        {
            get
            {
                return this.map;
            }
        }

        /// <summary>
        /// Run the main game loop until we're told to exit.
        /// </summary>
        public void Run()
        {
            // Flag to indicate when to exit this application.
            bool quit = false;

            // Count the turns.
            uint turnNumber = 0;

            // Loop infinitely if we don't want to exit.
            do
            {
                this.ExecuteTurn(turnNumber);
                ++turnNumber;
            }
            while (!quit);
        }

        /// <summary>
        /// Executes the turn specified.
        /// </summary>
        /// <param name="turnNumber">The turn to execute.</param>
        private void ExecuteTurn(uint turnNumber)
        {
            Nation actingNation = this.DiscernActingNation(turnNumber);
            RondelSpace action = actingNation.SelectRondelSpace();
            actingNation.ExecuteRondelSpaceAction(action);
        }

        /// <summary>
        /// Discerns the Nation that acts during this turn by the specified turn number.
        /// </summary>
        /// <param name="turnNumber">The turn number for which to find the acting Nation.</param>
        /// <returns>The acting Nation for the specified turn.</returns>
        /// <remarks>
        /// Makes implicit assumption that the Nations are ordered by their NationName
        /// with the starting Nation listed first.
        /// </remarks>
        private Nation DiscernActingNation(uint turnNumber)
        {
            uint nationCount = (uint)this.map.Nations.Count;
            return this.map.Nations[(int)(turnNumber % nationCount)];
        }
    }
}