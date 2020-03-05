/**Card.cs - card class
 * 
 * Author: Group #2
 * Since : 2020 - 03 - 03
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card_Lib
{
    /// <summary>
    /// Card Class,
    /// set card property, suit and rank
    /// </summary>
    public class Card : ICloneable
    {
        /// <summary>
        /// == operator check if card 1 and card 2 are the same
        /// </summary>
        /// <param name="card1">input card 1</param>
        /// <param name="card2">input card 2</param>
        /// <returns>true or false</returns>
        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.suit == card2.suit) && (card1.rank == card2.rank);
        }
        /// <summary>
        /// != operator check if card 1 and card 2 are different
        /// </summary>
        /// <param name="card1">input card 1</param>
        /// <param name="card2">input card 2</param>
        /// <returns>true or false</returns>
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }
        /// <summary>
        /// Equals, check if current object is same with card
        /// </summary>
        /// <param name="card">comparing object</param>
        /// <returns>true or false</returns>
        public override bool Equals(object card)
        {
            return this == (Card)card;
        }
        /// <summary>
        /// GetHashCode() - overloading GetHashCode returning int of 13* suit + rank
        /// </summary>
        /// <returns>int</returns>
        public override int GetHashCode()
        {
            return 13 * (int)suit + (int)rank;
        }
        /// <summary>
        /// greater than operator, check if left card is bigger than card 2
        /// </summary>
        /// <param name="card1">input card 1</param>
        /// <param name="card2">input card 2</param>
        /// <returns>true or false</returns>
        public static bool operator >(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank > card2.rank);
                    }
                }
                else
                {
                    return (card1.rank > card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }
        /// <summary>
        /// less than operator, check if left card 1 is smaller than card 2
        /// </summary>
        /// <param name="card1">input card 1</param>
        /// <param name="card2">input card 2</param>
        /// <returns>true or false</returns>
        public static bool operator <(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }
        /// <summary>
        /// greater than or equal, check if card 1 is greater than or equal to card 2
        /// </summary>
        /// <param name="card1">input card 1</param>
        /// <param name="card2">input card 2</param>
        /// <returns>true or false</returns>
        public static bool operator >=(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {
                        return true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank >= card2.rank);
                    }
                }
                else
                {
                    return (card1.rank >= card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }
        /// <summary>
        /// less than or equal operator, check if card 1 is less than or equal to card 2
        /// </summary>
        /// <param name="card1">input card 1</param>
        /// <param name="card2">input card 2</param>
        /// <returns>true or false</returns>
        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 > card2);
        }

        /// <summary>
        /// Flag for trump usage. If true, trumps are valued higher
        /// than cards of other suits.
        /// </summary>
        public static bool useTrumps = true;

        //MODIFY INTO 
        /// <summary>
        /// Trump suit to use if useTrumps is true.
        /// </summary>
        public static Suit trump;
        public static Suit Trump
        {
            set
            {
                trump = value;
            }
            get
            {
                return trump;
            }
        }
        
        /// <summary>
        /// Flag that determines whether aces are higher than kings or lower
        /// than deuces.
        /// </summary>
        public static bool isAceHigh = true;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public readonly Rank rank;
        public readonly Suit suit;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="newSuit">Card Suit</param>
        /// <param name="newRank">Card Rank</param>
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        private Card()
        {
        }
        /// <summary>
        /// ToString - print out card class
        /// </summary>
        /// <returns>Formatted String</returns>
        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }
    }
}