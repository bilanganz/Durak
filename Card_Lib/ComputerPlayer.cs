using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Lib
{
    public class ComputerPlayer
    {
        public string Name { get; private set; }
        public Cards PlayHand { get; private set; }
        
        public ComputerPlayer()
        {

        }

        public ComputerPlayer(string name, Cards hand)
        {
            Name = name;
            PlayHand = hand;
        }

        public void Attack()
        {

        }
    }
}
