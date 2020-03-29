using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardBox;

namespace DurakGame
{
    public partial class frmDurakGame : Form
    {
        //initialize components of the form
        public frmDurakGame()
        {
            InitializeComponent();

        }

        int deckSize = 52;

        //resets game
        public void ResetGame()
        {
             
        }

        //on form load reset game
        private void frmDurakGame_Load(object sender, EventArgs e)
        {
            ResetGame();
            this.BackgroundImage = Properties.Resources.bg1;
        }

        //starts a new game
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            ResetGame();

            DisplayAllCardLists();


            //AttackDefendPhase();

        }


        public void AttackDefendPhase()
        {
            //int userInput = 1;
            //Attacking/defendingPhase   
            //myPlayerOne.AttackingPhase(myRiver, userInput);

            //myPlayerTwo.DefendingPhase(myRiver);

            DisplayAllCardLists();

        }



        //on card click will raise event in card image control class
        //clicked card will go through player attack/defend phase method
        private void Card_Click(object sender, EventArgs e)
        {
            
        }


        //will display all card lists on the windows form
        public void DisplayAllCardLists()
        {
            
        }

        //displays discard cards
        public void DisplayDiscardCards()
        {
            
        }

        //displays trump card
        public void DisplayTrumpCards()
        {
           
        }

        //displays player one cards
        public void DisplayPlayerOneCards()
        {
            
        }

        //displays player two cards
        public void DisplayPlayerTwoCards()
        {
           
        }

        //displays river cards
        public void DisplayRiverCards()
        {
            
        }

        //button pickup clicked ends human turn and picks up cards
        private void btnPickUp_Click(object sender, EventArgs e)
        {
            
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
            ResetGame();
        }

        private void new36Deck_Click(object sender, EventArgs e)
        {
            deckSize = 36;
            // myDeck = new GameDeck(deckSize);
            ResetGame();
        }

        private void new52Deck_Click(object sender, EventArgs e)
        {
            deckSize = 52;
            // myDeck = new GameDeck(deckSize);
            ResetGame();
        }

        private void lblTrumpCard_Click(object sender, EventArgs e)
        {

        }
    }
}
