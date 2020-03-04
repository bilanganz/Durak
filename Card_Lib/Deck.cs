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
    public class Deck
    {
        private Cards cards = new Cards();
        private const int numOfCards = 36;
        /// <summary>
        /// Default Constructor - create a deck of 52 cards
        /// </summary>
        public Deck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 9; rankVal++)
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
            if (cardNum >= 0 && cardNum <= numOfCards)
            {
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
            bool[] assigned = new bool[numOfCards];
            Random sourceGen = new Random();
            for (int i = 0; i < numOfCards; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(numOfCards);
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