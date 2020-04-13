using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Card_Lib;
using CardBox;

namespace DurakGame
{
    public partial class frmDurakGame : Form
    {
        #region VARIABLE
        private const int POP = 25;
        static private Size regularSize = new Size(93, 120);
        static private Size discardedSize = new Size(25, 30);

        private Player HumanPlayer = new Player("Player One", true);
        private Player ComputerPlayer = new Player("Computer", false);


        private int currentCard=0;
        private int discardedCardCount = 0;
        private Deck playDeck = new Deck(deckSize);
        private Cards onFieldCards = new Cards();
        private Cards discardedCards;
        private bool cardRemaining = true;
        private Card trumpCard = new Card();
        
        static int deckSize = 36;
        
        #endregion

        #region FORM AND CONTROL EVENT HANDLER
        //initialize components of the form
        public frmDurakGame()
        {
            InitializeComponent();

        }

        private void frmDurakGame_Load(object sender, EventArgs e)
        {
            StartGame();   
        }
        
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            ResetGame();
            StartGame();
        }

        //button pickup clicked ends human turn and picks up cards
        private void btnPickUp_Click(object sender, EventArgs e)
        {
            PickUpRiver(pnlHumanHand);
            EndTurn();
        }

        //cease attack button ends human turn and computer starts attacking
        private void btnCeaseAttack_Click(object sender, EventArgs e)
        {
            RemoveRiverCard();
            EndTurn();
        }

        private void new20Deck_Click(object sender, EventArgs e)
        {
            deckSize = 20;
            // myDeck = new GameDeck(deckSize);
            ResetGame();
            StartGame();
        }

        private void new36Deck_Click(object sender, EventArgs e)
        {
            deckSize = 36;
            // myDeck = new GameDeck(deckSize);
            ResetGame();
            StartGame();
        }

        private void new52Deck_Click(object sender, EventArgs e)
        {
            deckSize = 52;
            // myDeck = new GameDeck(deckSize);
            ResetGame();
            StartGame();
        }
        private void Reshuffle(object source, EventArgs args)
        {
            pbDeck.Image = null;
            cardRemaining = false;
            txtDeckCardsRemaining.Text = "0";
        }

        #endregion

        #region CARDBOX EVENT HANDLER
        /// <summary>
        ///  CardBox controls grow in size when the mouse is over it.
        /// </summary>
        void CardBox_MouseEnter(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                aCardBox.Size = new Size(regularSize.Width + POP, regularSize.Height + POP);// Enlarge the card for visual effect
                aCardBox.Top = 0;// move the card to the top edge of the panel.
            }
        }

        /// <summary>
        /// CardBox control shrinks to regular size when the mouse leaves.
        /// </summary>
        void CardBox_MouseLeave(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                aCardBox.Size = regularSize;// resize the card back to regular size
                aCardBox.Top = POP;// move the card down to accommodate for the smaller size.

            }
        }
        
        void CardBox_Click(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;
            // If the conversion worked
            if (aCardBox != null)
            {
                // if the card is in the home panel...
                if (aCardBox.Parent == pnlHumanHand)
                {
                    if (HumanPlayer.IsAttacking)
                    {
                        if (ValidAttack(aCardBox.Card))
                        {
                            pnlHumanHand.Controls.Remove(aCardBox); // Remove the card from the home panel
                            aCardBox.Enabled = false;
                            onFieldCards.Add(aCardBox.Card);
                            flowRiver.Controls.Add(aCardBox); // Add the control to the play panel

                            ComputerDefence(aCardBox.Card);
                        }
                        btnCeaseAttack.Enabled = true;
                    }
                    else
                    {
                        if (ValidDefend(aCardBox.Card))
                        {
                            pnlHumanHand.Controls.Remove(aCardBox); // Remove the card from the home panel
                            aCardBox.Enabled = false;
                            onFieldCards.Add(aCardBox.Card);
                            flowRiver.Controls.Add(aCardBox); // Add the control to the play panel

                            ComputerAttack();
                        }
                        btnCeaseAttack.Enabled = false;
                    }
                }
                // Realign the cards 
                RealignCards(pnlHumanHand);
            }
        }
        #endregion

        #region GAME METHOD
        private void StartGame()
        {
            currentCard = 0;
            discardedCardCount = 0;
            pbDeck.Image = (new Card()).GetCardImage();
            playDeck = new Deck(deckSize);
            //MessageBox.Show(playDeck.CardsRemaining.ToString());
            playDeck.Shuffle(deckSize);
            playDeck.LastCardDrawn +=Reshuffle;
            discardedCards = new Cards();

            cardRemaining = true;

            DealHands(cardRemaining);
            DisplayTrumpCards();

            if (deckSize == 20)
            {
                new20Deck.Checked = true;
                new36Deck.Checked = false;
                new52Deck.Checked = false;
            }
            else if (deckSize == 36)
            {
                new20Deck.Checked = false;
                new36Deck.Checked = true;
                new52Deck.Checked = false;
            }else if (deckSize == 52)
            {
                new20Deck.Checked = false;
                new36Deck.Checked = false;
                new52Deck.Checked = true;
            }

            btnPickUp.Enabled = false;
            txtDeckCardsRemaining.Text = (playDeck.CardsRemaining - currentCard).ToString();
            txtDicardCardsRemaining.Text = "0";
            lblHumanAttacking.Visible = true;
            lblComputerAttacking.Visible = false;
        }
        
        public void CheckWinner()
        {
            if (pnlComputerHand.Controls.Count == 0)
            {
                DialogResult d = MessageBox.Show("Computer has won the game", "New game?", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    ResetGame();
                    StartGame();
                }
                else
                {
                    this.Close();
                }
            }
            else if (pnlHumanHand.Controls.Count == 0)
            {
                DialogResult d = MessageBox.Show("Player has won the game", "New game?", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    ResetGame();
                    StartGame();
                }
            }
        }

        //resets game
        public void ResetGame()
        {
            pnlComputerHand.Controls.Clear();
            pnlHumanHand.Controls.Clear();
            flowRiver.Controls.Clear();
            flowTrumpCard.Controls.Clear();
            pnlDiscardPile.Controls.Clear();
        }

        private void DealHands(bool cardRemaing)
        {
            if (cardRemaing)
            {
                if (playDeck.CardsRemaining > 1)
                {
                    for (int c = pnlHumanHand.Controls.Count; c < 6; c++)
                    {
                        DrawCard(pnlHumanHand);
                    }
                    for (int c = pnlComputerHand.Controls.Count; c < 6; c++)
                    {
                        DrawCard(pnlComputerHand);
                    }
                    RealignCards(pnlHumanHand);
                    RealignCards(pnlComputerHand);
                }
                else if (playDeck.CardsRemaining == 1)
                {
                    if (HumanPlayer.IsAttacking)
                        DrawCard(pnlHumanHand);
                    else
                        DrawCard(pnlComputerHand);
                }
            }
            else
            {
                CheckWinner();
            }
        }

        private void DrawCard(Panel panel)
        {
            txtDeckCardsRemaining.Text = (playDeck.CardsRemaining - currentCard).ToString();
            if (panel == pnlHumanHand) 
            {
                HumanPlayer.PlayHand.Add(playDeck.GetCard(currentCard));
                CardBox.CardBox aCardBox = new CardBox.CardBox(playDeck.GetCard(currentCard), true);
                aCardBox.Click += CardBox_Click;
                aCardBox.MouseEnter += CardBox_MouseEnter;// wire CardBox_MouseEnter for the "POP" visual effect
                aCardBox.MouseLeave += CardBox_MouseLeave;// wire CardBox_MouseLeave for the regular visual effect
                pnlHumanHand.Controls.Add(aCardBox);
                currentCard++;
            }
            if (panel == pnlComputerHand) 
            {
                ComputerPlayer.PlayHand.Add(playDeck.GetCard(currentCard));
                CardBox.CardBox aCardBox = new CardBox.CardBox(playDeck.GetCard(currentCard), false);
                pnlComputerHand.Controls.Add(aCardBox);
                currentCard++;
            }
        }

        private void RemoveRiverCard()
        {
            try
            {
                int count = (flowRiver.Controls.Count-1);
                for (int i = count; i >= 0; i--)  
                {
                    onFieldCards = new Cards();
                    flowRiver.Controls[i].Size = new Size(discardedSize.Width + POP, discardedSize.Height + POP);
                    flowRiver.Controls[i].Enabled = false;
                    pnlDiscardPile.Controls.Add(flowRiver.Controls[i]);
                    discardedCardCount++;
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                txtDicardCardsRemaining.Text = (discardedCardCount).ToString();
                RealignCards(pnlDiscardPile);
                flowRiver.Controls.Clear();
            }
           
        }

        public bool ValidAttack(Card attackCard)
        {
            if(flowRiver.Controls.Count < 1)
            {
                return true;
            }
            else
            {
                foreach(Card playedCard in onFieldCards)
                {
                    if (attackCard.Rank == playedCard.Rank)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool ValidDefend(Card defendCard)
        {
            Card lastCard = onFieldCards[onFieldCards.Count - 1];
            if ((defendCard.Suit == lastCard.Suit && defendCard.Rank > lastCard.Rank) || defendCard.Suit == trumpCard.Suit)
            {
                return true;
            }
            return false;
        }

        public void ComputerDefence(Card attackCard)
        {
            foreach (CardBox.CardBox aCardBox in pnlComputerHand.Controls)
            {
                if ((aCardBox.Card.Suit == attackCard.Suit && aCardBox.Card.Rank > attackCard.Rank) || aCardBox.Card.Suit == trumpCard.Suit)
                {
                    ComputerPlaysCard(aCardBox);
                    return;
                }
            }
            PickUpRiver(pnlComputerHand);
        }

        public void ComputerAttack()
        {     
            if (flowRiver.Controls.Count == 0)
            {
                if (playDeck.CardsRemaining > 0)
                {
                    CardBox.CardBox attackCard = pnlComputerHand.Controls.OfType<CardBox.CardBox>().First();
                    foreach(CardBox.CardBox card in pnlComputerHand.Controls)
                    {
                        if(card.Rank < attackCard.Rank)
                        {
                            attackCard = card;
                        }
                    }
                    ComputerPlaysCard(attackCard);
                }
                else
                {
                    CardBox.CardBox attackCard = pnlComputerHand.Controls.OfType<CardBox.CardBox>().First();
                    foreach (CardBox.CardBox card in pnlComputerHand.Controls)
                    {
                        if (card.Rank > attackCard.Rank)
                        {
                            attackCard = card;
                        }
                    }
                    ComputerPlaysCard(attackCard);
                }
                
            }
            else
            {
                foreach (Card card in onFieldCards)
                {
                    foreach (CardBox.CardBox aCardBox in pnlComputerHand.Controls)
                    {
                        if (card.Rank == aCardBox.Card.Rank)
                        {
                            ComputerPlaysCard(aCardBox);
                            return;
                        }
                    }
                }
                RemoveRiverCard();
                EndTurn();
            }
        }
        
        public void ComputerPlaysCard(CardBox.CardBox aCardBox)
        {
            pnlComputerHand.Controls.Remove(aCardBox); // Remove the card from the home panel
            aCardBox.Enabled = false;
            aCardBox.FaceUp = true;
            onFieldCards.Add(aCardBox.Card);
            flowRiver.Controls.Add(aCardBox);
            RealignCards(pnlComputerHand);
        }

        public void PickUpRiver(Panel panel)
        {
            foreach (CardBox.CardBox card in flowRiver.Controls)
            {
                panel.Controls.Add(card);
                if (panel == pnlComputerHand)
                {
                    card.FaceUp = false;
                    card.Enabled = false;
                }
                card.Enabled = true;
                if(panel == pnlHumanHand)
                {
                    card.Click += CardBox_Click;
                    card.MouseEnter += CardBox_MouseEnter;// wire CardBox_MouseEnter for the "POP" visual effect
                    card.MouseLeave += CardBox_MouseLeave;// wire CardBox_MouseLeave for the regular visual effect

                }
                onFieldCards.Remove(card.Card);
                flowRiver.Controls.Remove(card);    
            }
            RealignCards(panel);
            EndTurn();
        }

        public void EndTurn()
        {
            DealHands(cardRemaining);
            if (HumanPlayer.IsAttacking)
            {
                HumanPlayer.IsAttacking = false;
                lblHumanAttacking.Visible = false;
                ComputerPlayer.IsAttacking = true;
                lblComputerAttacking.Visible = true;
                btnCeaseAttack.Enabled = false;
                btnPickUp.Enabled = true;
                ComputerAttack();
            }
            else
            {
                HumanPlayer.IsAttacking = true;
                lblHumanAttacking.Visible = true;
                ComputerPlayer.IsAttacking = false;
                lblComputerAttacking.Visible = false;
                if (flowRiver.Controls.Count!=0)
                {
                    btnCeaseAttack.Enabled = true;
                }
                btnPickUp.Enabled = false;
            }
            
        }

        //will display all card lists on the windows form
        public void DisplayAllCardLists()
        {
            DisplayDiscardCards();
            DisplayTrumpCards();
            DisplayPlayerOneCards();
            DisplayPlayerTwoCards();
            DisplayRiverCards();
        }

        //displays discard cards
        public void DisplayDiscardCards()
        {
            foreach (Control control in pnlDiscardPile.Controls)
            {
                CardBox.CardBox card = control as CardBox.CardBox;
                card.FaceUp = true;
            }
        }

        public void DisplayOnFieldCards()
        {
            foreach (Card card in onFieldCards)
            {
                MessageBox.Show(card.ToString());
            }
        }

        //displays trump card
        public void DisplayTrumpCards()
        {
            CardBox.CardBox aCardBox = new CardBox.CardBox(playDeck.GetCard(12), true);
            flowTrumpCard.Controls.Add(aCardBox);
            playDeck.GetCard(12).TrumpSuit= playDeck.GetCard(12).Suit;
            playDeck.changePosition(12, playDeck.GetCard(12));
            trumpCard = playDeck.GetCard(12);
        }

        //displays player one cards
        public void DisplayPlayerOneCards()
        {
            foreach (Control control in pnlHumanHand.Controls)
            {
                CardBox.CardBox card = control as CardBox.CardBox;
                card.FaceUp = true;
            }
        }

        //displays player two cards
        public void DisplayPlayerTwoCards()
        {
            foreach (Control control in pnlComputerHand.Controls)
            {
                CardBox.CardBox card = control as CardBox.CardBox;
                card.FaceUp = true;
            }
        }

        //displays river cards
        public void DisplayRiverCards()
        {
            foreach (Control control in flowRiver.Controls)
            {
                CardBox.CardBox card = control as CardBox.CardBox;
                card.FaceUp = true;
            }

        }
        
        #endregion

        #region HELPER METHOD
        private void RealignCards(Panel panelHand)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = panelHand.Controls.Count;

            // If there are any cards in the panel
            if (myCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = panelHand.Controls[0].Width;

                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = (panelHand.Width - cardWidth) / 2;

                // An offset for the remaining cards
                int offset = 0;

                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (panelHand.Width - cardWidth - 2 * POP) / (myCount - 1);

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                        offset = cardWidth;

                    // Determine width of all the cards/controls 
                    int allCardWidth = (myCount - 1) * offset + cardWidth;

                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (panelHand.Width - allCardWidth) / 2;
                }
                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.

                // Align the "first" card (which is the last control in the collection)
                panelHand.Controls[myCount - 1].Top = POP;
                System.Diagnostics.Debug.Write(panelHand.Controls[myCount - 1].Top.ToString() + "\n");
                panelHand.Controls[myCount - 1].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    panelHand.Controls[index].Top = POP;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;

                }
            }
        }

        #endregion

        private void pbDeck_Click(object sender, EventArgs e)
        {
            //DrawCard(pnlComputerHand);
            //DisplayOnFieldCards();
            DisplayAllCardLists();
        }

        private void quitToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
