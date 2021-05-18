using System;
using System.Collections.Generic;
using System.Text;
using static TextBasedGame1.InputOutput;

namespace TextBasedGame1
{
    class GameRunner
    {
        Player player;
        Outside outside;
        FirstRoom firstRoom;

        public GameRunner()
        {
            
            player = new Player(ReceiveInput("What is your name?"));
            outside = new Outside();
            firstRoom = new FirstRoom();

            PrintNew(readFromScript("/game/gamestart"));

            //game will run until killed.
            while (true)
            {
                //So we check what room the player is currently in then run that room.
                switch (player.room) {
                    case 0:
                        outside.RunRoom(ref player);
                        break;
                    case 1:
                        firstRoom.RunRoom(ref player);
                        break;
                    default:
                        break;
                }
            }   
            
        }
    }
}
