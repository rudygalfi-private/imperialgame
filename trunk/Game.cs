// <copyright file="Game.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Implements a game defined by its count of players.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The count of players for this Game.
        /// </summary>
        private readonly uint playerCount;

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
        public Game(string mapFilePath, uint playerCount)
        {
            this.playerCount = playerCount;

            System.Xml.XmlDocument mapDefinitionDocument = new System.Xml.XmlDocument();
            mapDefinitionDocument.Load(mapFilePath);
            System.Xml.XmlNodeList maps = mapDefinitionDocument.GetElementsByTagName(Map.XmlElement);

            if (maps.Count > 0)
            {
                this.map = new Map(maps.Item(0));
            }
            else
            {
                //// throw InvalidMapFileException
            }
        }

        /// <summary>
        /// Gets the count of players for this game.
        /// </summary>
        public uint PlayerCount
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
            Nation home = null;
            System.Console.Write("Nation: ");
            string nationInput = System.Console.ReadLine();

            Region location = null;
            System.Console.Write("Location: ");
            string locationInput = System.Console.ReadLine();

            ////System.Console.WriteLine("NATIONS:");
            foreach (Nation nation in this.map.Nations)
            {
                ////System.Console.WriteLine(nation);

                if (nation.Name == nationInput)
                {
                    home = nation;
                }

                foreach (HomeProvince homeProvince in nation.HomeProvinces)
                {
                    if (homeProvince.Name == locationInput)
                    {
                        location = homeProvince;
                    }
                }
            }

            ////System.Console.WriteLine("TAXABLE REGIONS:");
            foreach (TaxableRegion taxableRegion in this.map.TaxableRegions)
            {
                ////System.Console.WriteLine(taxableRegion);

                if (taxableRegion.Name == locationInput)
                {
                    location = taxableRegion;
                }
            }

            // Flag to indicate when to exit this application.
            bool quit = false;

            // Count the turns.
            uint turnNumber = 0;

            // Loop infinitely if we don't want to exit.
            while (!quit && null != home)
            {
                System.Console.WriteLine("You are in " + location.Name + ".");

                System.Collections.Generic.HashSet<Region> reachableRegions = home.GetRegionsReachableFromRegion(location);
                System.Collections.Generic.Dictionary<string, Region> reachableRegionNameAssociations = new System.Collections.Generic.Dictionary<string, Region>();
                foreach (Region reachableRegion in reachableRegions)
                {
                    reachableRegionNameAssociations.Add(reachableRegion.Name, reachableRegion);
                }

                System.Console.Write("You can move to ");

                bool first = true;
                foreach (System.Collections.Generic.KeyValuePair<string, Region> reachableRegionNameAssociation in reachableRegionNameAssociations)
                {
                    //neighbors.Add(neighbor.Name, neighbor);
                    System.Console.Write((first ? string.Empty : ", ") + reachableRegionNameAssociation.Key);
                    first = false;
                }

                System.Console.WriteLine(".");

                do
                {
                    System.Console.Write("Go to: ");
                    locationInput = System.Console.ReadLine();

                    if ("quit" == locationInput.ToLower())
                    {
                        quit = true;
                    }
                }
                while (!quit && !reachableRegionNameAssociations.ContainsKey(locationInput));

                if (!quit)
                {
                    location = reachableRegionNameAssociations[locationInput];

                    ////this.ExecuteTurn(turnNumber);
                    ++turnNumber;
                }
            }
        }

        /// <summary>
        /// Executes the turn specified.
        /// </summary>
        /// <param name="turnNumber">The turn to execute.</param>
        private void ExecuteTurn(uint turnNumber)
        {
            try
            {
                Nation actingNation = this.DiscernActingNation(turnNumber);

                RondelSpace action = actingNation.SelectRondelSpace();

                actingNation.ExecuteRondelSpaceAction(action);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
            }
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

            if (nationCount != 0)
            {
                return this.map.Nations[(int)(turnNumber % nationCount)];
            }
            else
            {
                //// throw NoNationsException
                return null;
            }
        }
    }
}
