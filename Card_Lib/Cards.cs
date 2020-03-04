using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Lib
{
    public class Cards : List<Card>, ICloneable
    {
        /// <summary>
        /// Clone - clone the list
        /// </summary>
        /// <returns>cloned object</returns>
        public object Clone()
        {
            Cards newCards = new Cards();
            foreach (Card sourceCard in this)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }

        /// <summary>
        /// Utility method for copying card instances into another Cards
        /// instance—used in Deck.Shuffle(). This implementation assumes that
        /// source and target collections are the same size.
        /// </summary>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }
        /*/// <summary>
        /// Add - add  card
        /// </summary>
        /// <param name="newCard">new card</param>
        public void Add(Card newCard)
        {
            List.Add(newCard);
        }
        /// <summary>
        /// Remove - remove card
        /// </summary>
        /// <param name="oldCard">old card</param>
        public void Remove(Card oldCard)
        {
            List.Remove(oldCard);
        }
        /// <summary>
        /// Accessor and mutator -  set and get card 
        /// </summary>
        /// <param name="cardIndex">card index</param>
        /// <returns>card</returns>
            {
                return (Card)List[cardIndex];
        public Card this[int cardIndex]
        {
            get
            }
            set
            {
                List[cardIndex] = value;
            }
        }
        
        /// <summary>
        /// Check to see if the Cards collection contains a particular card.
        /// This calls the Contains() method of the ArrayList for the collection,
        /// which you access through the InnerList property.
        /// </summary>
        public bool Contains(Card card)
        {
            return InnerList.Contains(card);
        }*/
    }
}
