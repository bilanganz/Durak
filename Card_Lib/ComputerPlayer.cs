/**ComputerPlayer.cs - computer player class
 * 
 * Author: Group #2
 * Since : 2020 - 03 - 03
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Lib
{
    public class ComputerPlayer : Player
    {   
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
