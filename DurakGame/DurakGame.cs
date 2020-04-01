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

        private Player HumanPlayer = new Player("Player One");
        private Player ComputerPlayer = new Player("Computer");
        private Player[] player = new Player[2] { new Player("Player One"), new Player("Computer") };


        private int currentCard=0;
        private Deck playDeck = new Deck(deckSize);
        private Cards onFieldCards = new Cards();
        private Cards discardedCards;
        private CardBox.CardBox dragCard;
        
        static int deckSize = 52;
        
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


            DisplayAllCardLists();


            //AttackDefendPhase();

        }

        //on card click will raise event in card image control class
        //clicked card will go through player attack/defend phase method
        private void Card_Click(object sender, EventArgs e)
        {

        }


        //button pickup clicked ends human turn and picks up cards
        private void btnPickUp_Click(object sender, EventArgs e)
        {
            RemoveRiverCard();
        }

        //cease attack button ends human turn and computer starts attacking
        private void btnCeaseAttack_Click(object sender, EventArgs e)
        {


        }
        private void flpDeck_Paint(object sender, PaintEventArgs e)
        {

        }

        private void new20Deck_Click(object sender, EventArgs e)
        {
            deckSize = 20;
            // myDeck = new GameDeck(deckSize);
            //ResetGame();
        }

        private void new36Deck_Click(object sender, EventArgs e)
        {
            deckSize = 36;
            // myDeck = new GameDeck(deckSize);
            //ResetGame();
        }

        private void new52Deck_Click(object sender, EventArgs e)
        {
            deckSize = 52;
            // myDeck = new GameDeck(deckSize);
            //ResetGame();
        }

        private void lblTrumpCard_Click(object sender, EventArgs e)
        {

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
                    pnlHumanHand.Controls.Remove(aCardBox); // Remove the card from the home panel
                    aCardBox.Enabled = false;
                    onFieldCards.Add(aCardBox.Card);
                    flowRiver.Controls.Add(aCardBox); // Add the control to the play panel
                }
                else if (aCardBox.Parent == flowComputerHand)
                {
                    flowComputerHand.Controls.Remove(aCardBox); // Remove the card from the play panel
                    aCardBox.Enabled = false;
                    flowRiver.Controls.Add(aCardBox); // Add the control to the home panel
                }
                // Realign the cards 
                //RealignCards(pnlCardHome);
                //RealignCards(pnlPlay);
            }
        }
        #endregion

        #region GAME METHOD
        private void StartGame()
        {
            currentCard = 0;
            pbDeck.Image = (new Card()).GetCardImage();
            playDeck = new Deck(deckSize);
            playDeck.Shuffle(deckSize);
            discardedCards = new Cards();
            
            DealHands();
            DisplayTrumpCards();

            txtDeckCardsRemaining.Text = (playDeck.CardsRemaining - currentCard).ToString();

            //RealignCards(flowComputerHand);
        }

        //resets game
        public void ResetGame()
        {
            flowComputerHand.Controls.Clear();
            pnlHumanHand.Controls.Clear();
            flowRiver.Controls.Clear();
            flowTrumpCard.Controls.Clear();
            flowDiscardPile.Controls.Clear();
        }

        private void DealHands()
        {
            for (int c = 0; c < 6; c++)
            {
                DrawCard(pnlHumanHand);
                DrawCard(flowComputerHand);
            }
            RealignCards(pnlHumanHand);
        }
        
        private void DrawCard(Panel panel)
        {
            txtDeckCardsRemaining.Text = (playDeck.CardsRemaining - currentCard).ToString();
            if (panel == pnlHumanHand && pnlHumanHand.Controls.Count <= 6) 
            {
                HumanPlayer.PlayHand.Add(playDeck.GetCard(currentCard));
                CardBox.CardBox aCardBox = new CardBox.CardBox(playDeck.GetCard(currentCard), true);
                aCardBox.Click += CardBox_Click;
                aCardBox.MouseEnter += CardBox_MouseEnter;// wire CardBox_MouseEnter for the "POP" visual effect
                aCardBox.MouseLeave += CardBox_MouseLeave;// wire CardBox_MouseLeave for the regular visual effect
                pnlHumanHand.Controls.Add(aCardBox);
                currentCard++;
            }
            else if (panel == flowComputerHand && flowComputerHand.Controls.Count <= 6) 
            {
                ComputerPlayer.PlayHand.Add(playDeck.GetCard(currentCard));
                CardBox.CardBox aCardBox = new CardBox.CardBox(playDeck.GetCard(currentCard), false);
                flowComputerHand.Controls.Add(aCardBox);
                currentCard++;
            }
            else
            {
                MessageBox.Show("Error when drawing Card");
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
                    flowDiscardPile.Controls.Add(flowRiver.Controls[i]);
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                flowRiver.Controls.Clear();
            }
           
        }

        public void AttackDefendPhase()
        {
            //int userInput = 1;
            //Attacking/defendingPhase   
            //myPlayerOne.AttackingPhase(myRiver, userInput);

            //myPlayerTwo.DefendingPhase(myRiver);

            DisplayAllCardLists();

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
            foreach (Control control in flowDiscardPile.Controls)
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
            CardBox.CardBox aCardBox = new CardBox.CardBox(playDeck.GetCard(17), true);
            flowTrumpCard.Controls.Add(aCardBox);
            playDeck.GetCard(17).TrumpSuit= playDeck.GetCard(17).Suit;
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
            foreach (Control control in flowComputerHand.Controls)
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
            //DrawCard(flowComputerHand);
            DisplayOnFieldCards();
        }
    }
}
