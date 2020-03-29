namespace DurakGame
{
    partial class frmDurakGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGameDeck = new System.Windows.Forms.Label();
            this.lblHumanPlayer = new System.Windows.Forms.Label();
            this.lblComputerPlayer = new System.Windows.Forms.Label();
            this.lblRiver = new System.Windows.Forms.Label();
            this.lblComputerAttacking = new System.Windows.Forms.Label();
            this.lblHumanAttacking = new System.Windows.Forms.Label();
            this.lblTrumpCard = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnPickUp = new System.Windows.Forms.Button();
            this.flowGameDeck = new System.Windows.Forms.FlowLayoutPanel();
            this.flowTrumpCard = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDiscardPile = new System.Windows.Forms.Label();
            this.flowDiscardPile = new System.Windows.Forms.FlowLayoutPanel();
            this.txtDeckCardsRemaining = new System.Windows.Forms.TextBox();
            this.txtDicardCardsRemaining = new System.Windows.Forms.TextBox();
            this.txtRiverCardsRemaning = new System.Windows.Forms.TextBox();
            this.btnCeaseAttack = new System.Windows.Forms.Button();
            this.lblRoundNumber = new System.Windows.Forms.Label();
            this.txtRoundNumber = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.new20Deck = new System.Windows.Forms.ToolStripMenuItem();
            this.new36Deck = new System.Windows.Forms.ToolStripMenuItem();
            this.new52Deck = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.flowRiver = new System.Windows.Forms.FlowLayoutPanel();
            this.flowComputerHand = new System.Windows.Forms.FlowLayoutPanel();
            this.flowHumanHand = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGameDeck
            // 
            this.lblGameDeck.AutoSize = true;
            this.lblGameDeck.BackColor = System.Drawing.Color.YellowGreen;
            this.lblGameDeck.Location = new System.Drawing.Point(35, 125);
            this.lblGameDeck.Name = "lblGameDeck";
            this.lblGameDeck.Size = new System.Drawing.Size(78, 17);
            this.lblGameDeck.TabIndex = 0;
            this.lblGameDeck.Text = "GameDeck";
            // 
            // lblHumanPlayer
            // 
            this.lblHumanPlayer.AutoSize = true;
            this.lblHumanPlayer.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblHumanPlayer.Location = new System.Drawing.Point(992, 518);
            this.lblHumanPlayer.Name = "lblHumanPlayer";
            this.lblHumanPlayer.Size = new System.Drawing.Size(138, 17);
            this.lblHumanPlayer.TabIndex = 1;
            this.lblHumanPlayer.Text = "Human Player Cards";
            // 
            // lblComputerPlayer
            // 
            this.lblComputerPlayer.AutoSize = true;
            this.lblComputerPlayer.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblComputerPlayer.Location = new System.Drawing.Point(992, 103);
            this.lblComputerPlayer.Name = "lblComputerPlayer";
            this.lblComputerPlayer.Size = new System.Drawing.Size(154, 17);
            this.lblComputerPlayer.TabIndex = 2;
            this.lblComputerPlayer.Text = "Computer Player Cards";
            // 
            // lblRiver
            // 
            this.lblRiver.AutoSize = true;
            this.lblRiver.BackColor = System.Drawing.Color.YellowGreen;
            this.lblRiver.Location = new System.Drawing.Point(985, 259);
            this.lblRiver.Name = "lblRiver";
            this.lblRiver.Size = new System.Drawing.Size(82, 17);
            this.lblRiver.TabIndex = 3;
            this.lblRiver.Text = "River Cards";
            // 
            // lblComputerAttacking
            // 
            this.lblComputerAttacking.AutoEllipsis = true;
            this.lblComputerAttacking.AutoSize = true;
            this.lblComputerAttacking.BackColor = System.Drawing.Color.Red;
            this.lblComputerAttacking.Location = new System.Drawing.Point(992, 74);
            this.lblComputerAttacking.Name = "lblComputerAttacking";
            this.lblComputerAttacking.Size = new System.Drawing.Size(131, 17);
            this.lblComputerAttacking.TabIndex = 4;
            this.lblComputerAttacking.Text = "Computer Attacking";
            // 
            // lblHumanAttacking
            // 
            this.lblHumanAttacking.AutoSize = true;
            this.lblHumanAttacking.BackColor = System.Drawing.Color.Red;
            this.lblHumanAttacking.Location = new System.Drawing.Point(992, 546);
            this.lblHumanAttacking.Name = "lblHumanAttacking";
            this.lblHumanAttacking.Size = new System.Drawing.Size(115, 17);
            this.lblHumanAttacking.TabIndex = 5;
            this.lblHumanAttacking.Text = "Human Attacking";
            // 
            // lblTrumpCard
            // 
            this.lblTrumpCard.AutoSize = true;
            this.lblTrumpCard.BackColor = System.Drawing.Color.YellowGreen;
            this.lblTrumpCard.Location = new System.Drawing.Point(35, 306);
            this.lblTrumpCard.Name = "lblTrumpCard";
            this.lblTrumpCard.Size = new System.Drawing.Size(83, 17);
            this.lblTrumpCard.TabIndex = 6;
            this.lblTrumpCard.Text = "Trump Card";
            this.lblTrumpCard.Click += new System.EventHandler(this.lblTrumpCard_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(12, 58);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(139, 48);
            this.btnStartGame.TabIndex = 7;
            this.btnStartGame.Text = "Start/New Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnPickUp
            // 
            this.btnPickUp.Location = new System.Drawing.Point(1111, 247);
            this.btnPickUp.Name = "btnPickUp";
            this.btnPickUp.Size = new System.Drawing.Size(75, 67);
            this.btnPickUp.TabIndex = 8;
            this.btnPickUp.Text = "Pick Up River Cards";
            this.btnPickUp.UseVisualStyleBackColor = true;
            this.btnPickUp.Click += new System.EventHandler(this.btnPickUp_Click);
            // 
            // flowGameDeck
            // 
            this.flowGameDeck.BackColor = System.Drawing.Color.Transparent;
            this.flowGameDeck.Location = new System.Drawing.Point(23, 161);
            this.flowGameDeck.Name = "flowGameDeck";
            this.flowGameDeck.Size = new System.Drawing.Size(107, 120);
            this.flowGameDeck.TabIndex = 12;
            this.flowGameDeck.Paint += new System.Windows.Forms.PaintEventHandler(this.flpDeck_Paint);
            // 
            // flowTrumpCard
            // 
            this.flowTrumpCard.BackColor = System.Drawing.Color.Transparent;
            this.flowTrumpCard.Location = new System.Drawing.Point(26, 340);
            this.flowTrumpCard.Name = "flowTrumpCard";
            this.flowTrumpCard.Size = new System.Drawing.Size(108, 122);
            this.flowTrumpCard.TabIndex = 13;
            // 
            // lblDiscardPile
            // 
            this.lblDiscardPile.AutoSize = true;
            this.lblDiscardPile.BackColor = System.Drawing.Color.YellowGreen;
            this.lblDiscardPile.Location = new System.Drawing.Point(35, 481);
            this.lblDiscardPile.Name = "lblDiscardPile";
            this.lblDiscardPile.Size = new System.Drawing.Size(79, 17);
            this.lblDiscardPile.TabIndex = 14;
            this.lblDiscardPile.Text = "DiscardPile";
            // 
            // flowDiscardPile
            // 
            this.flowDiscardPile.BackColor = System.Drawing.Color.Transparent;
            this.flowDiscardPile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowDiscardPile.Location = new System.Drawing.Point(26, 518);
            this.flowDiscardPile.Name = "flowDiscardPile";
            this.flowDiscardPile.Size = new System.Drawing.Size(107, 121);
            this.flowDiscardPile.TabIndex = 15;
            // 
            // txtDeckCardsRemaining
            // 
            this.txtDeckCardsRemaining.Location = new System.Drawing.Point(152, 204);
            this.txtDeckCardsRemaining.Name = "txtDeckCardsRemaining";
            this.txtDeckCardsRemaining.ReadOnly = true;
            this.txtDeckCardsRemaining.Size = new System.Drawing.Size(23, 22);
            this.txtDeckCardsRemaining.TabIndex = 16;
            // 
            // txtDicardCardsRemaining
            // 
            this.txtDicardCardsRemaining.Location = new System.Drawing.Point(152, 559);
            this.txtDicardCardsRemaining.Name = "txtDicardCardsRemaining";
            this.txtDicardCardsRemaining.ReadOnly = true;
            this.txtDicardCardsRemaining.Size = new System.Drawing.Size(23, 22);
            this.txtDicardCardsRemaining.TabIndex = 17;
            // 
            // txtRiverCardsRemaning
            // 
            this.txtRiverCardsRemaning.Location = new System.Drawing.Point(1073, 259);
            this.txtRiverCardsRemaning.Name = "txtRiverCardsRemaning";
            this.txtRiverCardsRemaning.ReadOnly = true;
            this.txtRiverCardsRemaning.Size = new System.Drawing.Size(23, 22);
            this.txtRiverCardsRemaning.TabIndex = 18;
            // 
            // btnCeaseAttack
            // 
            this.btnCeaseAttack.Location = new System.Drawing.Point(1111, 320);
            this.btnCeaseAttack.Name = "btnCeaseAttack";
            this.btnCeaseAttack.Size = new System.Drawing.Size(79, 64);
            this.btnCeaseAttack.TabIndex = 19;
            this.btnCeaseAttack.Text = "Cease Attack";
            this.btnCeaseAttack.UseVisualStyleBackColor = true;
            this.btnCeaseAttack.Click += new System.EventHandler(this.btnCeaseAttack_Click);
            // 
            // lblRoundNumber
            // 
            this.lblRoundNumber.AutoSize = true;
            this.lblRoundNumber.BackColor = System.Drawing.Color.YellowGreen;
            this.lblRoundNumber.Location = new System.Drawing.Point(992, 40);
            this.lblRoundNumber.Name = "lblRoundNumber";
            this.lblRoundNumber.Size = new System.Drawing.Size(104, 17);
            this.lblRoundNumber.TabIndex = 25;
            this.lblRoundNumber.Text = "Round Number";
            // 
            // txtRoundNumber
            // 
            this.txtRoundNumber.Location = new System.Drawing.Point(1111, 35);
            this.txtRoundNumber.Name = "txtRoundNumber";
            this.txtRoundNumber.ReadOnly = true;
            this.txtRoundNumber.Size = new System.Drawing.Size(23, 22);
            this.txtRoundNumber.TabIndex = 26;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenu,
            this.logToolStrip,
            this.quitToolStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1195, 28);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenu
            // 
            this.newToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.new20Deck,
            this.new36Deck,
            this.new52Deck});
            this.newToolStripMenu.Name = "newToolStripMenu";
            this.newToolStripMenu.Size = new System.Drawing.Size(96, 24);
            this.newToolStripMenu.Text = "New Game";
            // 
            // new20Deck
            // 
            this.new20Deck.Name = "new20Deck";
            this.new20Deck.Size = new System.Drawing.Size(145, 26);
            this.new20Deck.Text = "20 Deck";
            this.new20Deck.Click += new System.EventHandler(this.new20Deck_Click);
            // 
            // new36Deck
            // 
            this.new36Deck.Name = "new36Deck";
            this.new36Deck.Size = new System.Drawing.Size(145, 26);
            this.new36Deck.Text = "36 Deck";
            this.new36Deck.Click += new System.EventHandler(this.new36Deck_Click);
            // 
            // new52Deck
            // 
            this.new52Deck.Name = "new52Deck";
            this.new52Deck.Size = new System.Drawing.Size(145, 26);
            this.new52Deck.Text = "52 Deck";
            // 
            // logToolStrip
            // 
            this.logToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLogToolStripMenuItem,
            this.clearLogToolStripMenuItem});
            this.logToolStrip.Name = "logToolStrip";
            this.logToolStrip.Size = new System.Drawing.Size(48, 24);
            this.logToolStrip.Text = "Log";
            // 
            // showLogToolStripMenuItem
            // 
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.showLogToolStripMenuItem.Text = "Show Log";
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            // 
            // quitToolStrip
            // 
            this.quitToolStrip.Name = "quitToolStrip";
            this.quitToolStrip.Size = new System.Drawing.Size(51, 24);
            this.quitToolStrip.Text = "Quit";
            // 
            // flowRiver
            // 
            this.flowRiver.BackColor = System.Drawing.Color.Transparent;
            this.flowRiver.Location = new System.Drawing.Point(223, 204);
            this.flowRiver.Name = "flowRiver";
            this.flowRiver.Size = new System.Drawing.Size(740, 273);
            this.flowRiver.TabIndex = 10;
            // 
            // flowComputerHand
            // 
            this.flowComputerHand.BackColor = System.Drawing.Color.Transparent;
            this.flowComputerHand.Location = new System.Drawing.Point(223, 29);
            this.flowComputerHand.Name = "flowComputerHand";
            this.flowComputerHand.Size = new System.Drawing.Size(740, 124);
            this.flowComputerHand.TabIndex = 9;
            // 
            // flowHumanHand
            // 
            this.flowHumanHand.BackColor = System.Drawing.Color.Transparent;
            this.flowHumanHand.Location = new System.Drawing.Point(223, 534);
            this.flowHumanHand.Name = "flowHumanHand";
            this.flowHumanHand.Size = new System.Drawing.Size(740, 120);
            this.flowHumanHand.TabIndex = 11;
            // 
            // frmDurakGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1195, 725);
            this.Controls.Add(this.txtRoundNumber);
            this.Controls.Add(this.lblRoundNumber);
            this.Controls.Add(this.btnCeaseAttack);
            this.Controls.Add(this.txtRiverCardsRemaning);
            this.Controls.Add(this.txtDicardCardsRemaining);
            this.Controls.Add(this.txtDeckCardsRemaining);
            this.Controls.Add(this.flowDiscardPile);
            this.Controls.Add(this.lblDiscardPile);
            this.Controls.Add(this.flowTrumpCard);
            this.Controls.Add(this.flowGameDeck);
            this.Controls.Add(this.flowHumanHand);
            this.Controls.Add(this.flowRiver);
            this.Controls.Add(this.flowComputerHand);
            this.Controls.Add(this.btnPickUp);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.lblTrumpCard);
            this.Controls.Add(this.lblHumanAttacking);
            this.Controls.Add(this.lblComputerAttacking);
            this.Controls.Add(this.lblRiver);
            this.Controls.Add(this.lblComputerPlayer);
            this.Controls.Add(this.lblHumanPlayer);
            this.Controls.Add(this.lblGameDeck);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDurakGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak Game";
            this.Load += new System.EventHandler(this.frmDurakGame_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameDeck;
        private System.Windows.Forms.Label lblHumanPlayer;
        private System.Windows.Forms.Label lblComputerPlayer;
        private System.Windows.Forms.Label lblRiver;
        private System.Windows.Forms.Label lblComputerAttacking;
        private System.Windows.Forms.Label lblHumanAttacking;
        private System.Windows.Forms.Label lblTrumpCard;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnPickUp;
        private System.Windows.Forms.FlowLayoutPanel flowGameDeck;
        private System.Windows.Forms.FlowLayoutPanel flowTrumpCard;
        private System.Windows.Forms.Label lblDiscardPile;
        private System.Windows.Forms.FlowLayoutPanel flowDiscardPile;
        private System.Windows.Forms.TextBox txtDeckCardsRemaining;
        private System.Windows.Forms.TextBox txtDicardCardsRemaining;
        private System.Windows.Forms.TextBox txtRiverCardsRemaning;
        private System.Windows.Forms.Button btnCeaseAttack;
        private System.Windows.Forms.Label lblRoundNumber;
        private System.Windows.Forms.TextBox txtRoundNumber;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem new20Deck;
        private System.Windows.Forms.ToolStripMenuItem new36Deck;
        private System.Windows.Forms.ToolStripMenuItem new52Deck;
        private System.Windows.Forms.ToolStripMenuItem logToolStrip;
        private System.Windows.Forms.ToolStripMenuItem quitToolStrip;
        private System.Windows.Forms.FlowLayoutPanel flowRiver;
        private System.Windows.Forms.FlowLayoutPanel flowComputerHand;
        private System.Windows.Forms.FlowLayoutPanel flowHumanHand;
        private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private CardBox.CardBox cardTrumpCard;
        private CardBox.CardBox cardBox2;
        private CardBox.CardBox cardGameDeck;
        private CardBox.CardBox cardBox3;
        private CardBox.CardBox cardDiscardPile;
    }
}