using System;
using System.Collections.Generic;
using System.Text;
using static TextBasedGame1.ConsoleInputOutput;

namespace TextBasedGame1
{
    class FirstRoom
    {
        public Boolean knife;

        public FirstRoom()
        {
            knife = true;
        }

        public void RunRoom(ref Player player)
        {
            switch (player.position)
            {
                case 0:
                    InfrontOfDoorPosition(ref player);
                    break;
            }
        }

        private void InfrontOfDoorPosition(ref Player player)
        {
            if (knife)
            {
                PrintNew("You see a dagger infront of you :)");
                if (RecieveYesNo("Pick it up?"))
                {
                    PrintNew("You recieve a dagger.");
                    player.inventory.Add("dagger");
                    knife = false;
                }
            }
            else
            {
                PrintNew("knife gone :(");
                Console.ReadLine();
            }
        }
    }
}
