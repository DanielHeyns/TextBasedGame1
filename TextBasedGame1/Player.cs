using System;
using System.Collections.Generic;
using System.Text;


namespace TextBasedGame1
{
    /// <summary>
    /// The player class, responsible for holding all necessary information 
    /// about the player.
    /// </summary>
    class Player
    {
        public string name;

        public List<string> inventory;

        //position the player is currently in, there will be limited positons, this can be used for saving and will be a key part of choosing what text to show the player.
        public int position;

        //room the player is in.
        public int room;

        public Player(string name)
        {
            this.name = name;
            inventory = new List<string>();
            room = 0;
            position = 0;
        }

    }
}
