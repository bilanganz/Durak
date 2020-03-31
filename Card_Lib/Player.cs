/**Player.cs - Player class, for creating player for the game
 * 
 * Author: Gabriel Nathan Legawa
 * Since : 2020 - 02 - 25
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Lib
{
    public class Player
    {
        //Player Attribute
        public string Name { get; private set; }
        public Cards PlayHand { get; private set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        private Player()
        {
        }
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="name"></param>
        public Player(string name)
        {
            Name = name;
            PlayHand = new Cards();
        }
        /// <summary>
        /// HasWon - check if player have win
        /// </summary>
        /// <returns></returns>
        public bool HasWon()
        {
            bool won = true;
            Suit match = PlayHand[0].suit;
            for (int i = 1; i < PlayHand.Count; i++)
            {
                won &= PlayHand[i].suit == match;
            }
            return won;
        }
    }
}