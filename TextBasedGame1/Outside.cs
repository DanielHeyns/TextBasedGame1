using System;
using System.Collections.Generic;
using System.Text;
using static TextBasedGame1.InputOutput;

namespace TextBasedGame1
{
    class Outside : Room
    {
        public bool key;

        public bool intactWindow;

        public bool foundWindow;

        public bool woodenSpear;

        public bool closedDoor;

        public Outside()
        {
            key = true;
            intactWindow = true;
            foundWindow = false;
            woodenSpear = true;
            closedDoor = true;
        }

        public override void RunRoom(ref Player player)
        {
            switch (player.position)
            {
                case 0:
                    DownThePath(ref player);
                    break;
                case 1:
                    InfrontOfDoor(ref player);
                    break;
                case 2:
                    ByTheWindow(ref player);

                default:
                    break;
            }
        }

        public void DownThePath(ref Player player)
        {
            string[] baseOptions = { "Walk towards the house.", "Examine the pond.", "Call out for anyone that may be nearby.", "Leave." };
            List<string> options = new List<string>();
            options.AddRange(baseOptions);
            int chosenOption = ReceiveOptions(readFromScript("/game/rooms/outside/downthepath/description"), options);
            switch (chosenOption)
            {
                case 1:
                    player.position = 1;
                    break;
                case 2:
                    PrintNewPause(readFromScript("/game/rooms/outside/downthepath/thepond"));
                    break;
                case 3:
                    PrintNewPause(readFromScript("/game/rooms/outside/downthepath/callout"));
                    break;
                case 4:
                    PrintNewPause(readFromScript("/game/rooms/outside/downthepath/leave"));
                    Environment.Exit(1);
                    break;

            }
        }

        public void InfrontOfDoor(ref Player player)
        {
            string[] baseOptions = { "Examine door.", "Search around the house.", "Try the door handle.", "Kick the door."};
            List<string> options = new List<string>();

            if (player.inventory.Contains("wooden spear")) options.Add("Drive spear into own chest.");
            if (player.inventory.Contains("dying fish")) options.Add("Pour the dying fish's blood onto the door handle.");

            int chosenOption = ReceiveOptions(readFromScript("/game/rooms/outside/infrontofthedoor/description"), options);
            switch (chosenOption)
            {
                case 1:
                    PrintNewPause(readFromScript("/game/rooms/outside/infrontofthedoor/examinethedoor"));
                    break;
                case 2:
                    PrintNewPause(readFromScript("/game/rooms/outside/infrontofthedoor/searcharoundthehouse"));
                    player.position = 2;
                    break;
                case 3:
                    PrintNewPause(readFromScript("/game/rooms/outside/infrontofthedoor/tryhandle"));
                    break;
                case 4:
                    PrintNewPause(readFromScript("/game/rooms/outside/infrontofthedoor/kickdoor"));
                    break;
                case 5: //TODO when spear is gone, dying fish will be in position 5 in the options, but this case statement is static. Can be fixed by tying the case to the first word in the options, and then checking the options list at index corresponding to chosen by player.
                        //After you fix this, implement from the script xml.
                    if (player.inventory.Contains("wooden spear"))
                    {
                        PrintNewPause(readFromScript("/game/rooms/outside/infrontofthedoor/drivespearintochest"));
                        Environment.Exit(1);
                    }
                    break;
                case 6:
                    if (player.inventory.Contains("dying fish"))
                    {
                        PrintNewPause(readFromScript("/game/rooms/outside/infrontofthedoor/pourthefishbloodonhandle"));
                        player.inventory.Remove("dying fish");

                    }
                    break;


            }
        }

        public void ByTheWindow(ref Player player)
        {

        }

    }
}
