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
                    break;

                default:
                    break;
            }
        }

        public void DownThePath(ref Player player)
        {
            string[] baseOptions = { "Walk towards the house.", "Examine the pond.", "Call out for anyone that may be nearby.", "Leave." };
            List<string> options = new List<string>();
            options.AddRange(baseOptions);
            int chosenOption = ReceiveOptions(ReadFromScript("/game/rooms/outside/downthepath/description"), options);
            switch (chosenOption)
            {
                case 1:
                    player.position = 1;
                    break;
                case 2:
                    PrintNewPause(ReadFromScript("/game/rooms/outside/downthepath/thepond"));
                    break;
                case 3:
                    PrintNewPause(ReadFromScript("/game/rooms/outside/downthepath/callout"));
                    break;
                case 4:
                    PrintNewPause(ReadFromScript("/game/rooms/outside/downthepath/leave"));
                    Environment.Exit(1);
                    break;

            }
        }

        public void InfrontOfDoor(ref Player player)
        {
            string[] baseOptions = { "Examine door.", "Search around the house.", "Try the door handle.", "Kick the door."};
            List<string> options = new List<string>();
            options.AddRange(baseOptions);

            if (player.inventory.Contains("wooden spear")) options.Add("Drive spear into own chest.");
            if (player.inventory.Contains("dying fish")) options.Add("Pour the dying fish's blood onto the door handle.");

            int chosenOption = ReceiveOptions(ReadFromScript("/game/rooms/outside/infrontofdoor/description"), options);
            string chosenOptionWord = GetFirstWord(options[chosenOption-1]);
            switch (chosenOptionWord)
            {
                case "Examine":
                    PrintNewPause(ReadFromScript("/game/rooms/outside/infrontofdoor/examinethedoor"));
                    break;
                case "Search":
                    PrintNewPause(ReadFromScript("/game/rooms/outside/infrontofdoor/searcharoundthehouse"));
                    player.position = 2;
                    break;
                case "Try":
                    PrintNewPause(ReadFromScript("/game/rooms/outside/infrontofdoor/tryhandle"));
                    break;
                case "Kick":
                    PrintNewPause(ReadFromScript("/game/rooms/outside/infrontofdoor/kickdoor"));
                    break;
                case "Drive": 
                    if (player.inventory.Contains("wooden spear"))
                    {
                        PrintNewPause(ReadFromScript("/game/rooms/outside/infrontofdoor/drivespearintochest"));
                        Environment.Exit(1);
                    }
                    break;
                case "Pour":
                    if (player.inventory.Contains("dying fish"))
                    {
                        PrintNewPause(ReadFromScript("/game/rooms/outside/infrontofdoor/pourthefishbloodonhandle"));
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
