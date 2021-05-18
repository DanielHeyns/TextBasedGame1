using System;
using System.Collections.Generic;
using System.Text;
using static TextBasedGame1.InputOutput;

namespace TextBasedGame1
{
    class FirstRoom : Room
    {
        public bool knife;

        public FirstRoom()
        {
            knife = true;
        }

        public override void RunRoom(ref Player player)
        {
            switch (player.position)
            {
                case 0:
                    InsideOfDoorPosition(ref player);
                    break;
                default:
                    break;
            }
        }

        private void InsideOfDoorPosition(ref Player player)
        {
            
        }
    }
}
