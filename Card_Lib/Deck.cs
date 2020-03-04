/**Deck.cs - deck of cards class
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
    public class Deck : ICloneable
    {
        private int minRange=1;
        public int MinRange
        {
            set
            {
                minRange = value;
            }
            get
            {
                return minRange;
            }
        }

        private int maxRange=14;
        public int MaxRange
        {
            set
            {
                maxRange = value;
            }
            get
            {
                return maxRange;
            }
        }

        public event EventHandler LastCardDrawn;
        /// <summary>
        /// Nondefault constructor. Allows aces to be set high.
        /// </summary>
        public Deck(bool isAceHigh) : this()
        {
            Card.isAceHigh = isAceHigh;
        }

        /// <summary>
        /// Nondefault constructor. Allows a trump suit to be used.
        /// </summary>
        public Deck(bool useTrumps, Suit trump) : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        /// <summary>
        /// Nondefault constructor. Allows aces to be set high and a trump suit
        /// to be used.
        /// </summary>
        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        /// <summary>
        /// Clone - clone the deck of card
        /// </summary>
        /// <returns>object of the deck</returns>
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }

        private Deck(Cards newCards)
        {
            cards = newCards;
        }
        private Cards cards = new Cards();
        /// <summary>
        /// Default Constructor - create a deck of 52 cards
        /// </summary>
        public Deck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = MinRange; rankVal < MaxRange; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }
        /// <summary>
        /// GetCard - get card at position index
        /// </summary>
        /// <param name="cardNum">position index</param>
        /// <returns>card on that index</returns>
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum < (MinRange*MaxRange))
            {
                if ((cardNum == (MinRange * MaxRange)-1) && (LastCardDrawn != null))
                    LastCardDrawn(this, EventArgs.Empty);
                return cards[cardNum];
            }
            else
                throw new CardOutOfRangeException((Cards)cards.Clone());
        }
        /// <summary>
        /// Shuffle - randomize the sequence of the deck
        /// </summary>
        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[(MinRange * MaxRange)];
            Random sourceGen = new Random();
            for (int i = 0; i < (MinRange * MaxRange); i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next((MinRange * MaxRange));
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }
    }
}