namespace PR_III
{
    public partial class Form1 : Form
    {
        // Counter to keep track of turns.
        // Even numbers indicate Player 1 ("X") and odd numbers indicate Player 2 ("O").

        public int Counter { get; set; }

        // Constructor: Initializes the form and its components.

        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Clears the game board by resetting all buttons.
        /// It removes any symbols (text) and resets the background colors.
        /// </summary>

        private void ClearAll()
        {
            // Clear text for all buttons (resetting the board)

            button1.Text = string.Empty;
            button2.Text = string.Empty;
            button3.Text = string.Empty;
            button4.Text = string.Empty;
            button5.Text = string.Empty;
            button6.Text = string.Empty;
            button7.Text = string.Empty;
            button8.Text = string.Empty;
            button9.Text = string.Empty;

            // Reset the background color of all buttons to the default control color

            button1.BackColor = SystemColors.ControlLight;
            button2.BackColor = SystemColors.ControlLight;
            button3.BackColor = SystemColors.ControlLight;
            button4.BackColor = SystemColors.ControlLight;
            button5.BackColor = SystemColors.ControlLight;
            button6.BackColor = SystemColors.ControlLight;
            button7.BackColor = SystemColors.ControlLight;
            button8.BackColor = SystemColors.ControlLight;
            button9.BackColor = SystemColors.ControlLight;
        }


        /// <summary>
        /// Writes the player's symbol ("X" or "O") on the clicked button if it's empty.
        /// Uses pattern matching to ensure the object is a Button.
        /// Then, increments the turn counter.
        /// </summary>
        /// <param name="currentBtn">The button that was clicked (passed as an object).</param>

        private void WriteSymbol(object currentBtn)
        {
            // Verify that currentBtn is a Button and that its text is empty

            if (currentBtn is Button btn && btn.Text == string.Empty)
            {
                // Determine which symbol to write based on the turn counter:
                // Player 1 uses "X" (even counter) and Player 2 uses "O" (odd counter).

                if (Counter % 2 == 0)
                    btn.Text = "X";
                else
                    btn.Text = "O";

                // Increment the counter to switch to the next player's turn.
                Counter++;
            }           
        }


        /// <summary>
        /// Displays a message box announcing the winner based on the last move.
        /// The winner is determined by checking the counter.
        /// </summary>

        private void WinMessage()
        {
            // Since the counter is incremented after each move,
            // if the counter is even, Player 2 just made a move; if odd, Player 1 did.

            if (Counter % 2 == 0)
            {
                MessageBox.Show("Congratulations, Player 2!", "Win!");
            }
            else
            {
                MessageBox.Show("Congratulations, Player 1!", "Win!");
            }
        }


        /// <summary>
        /// Checks the game board for any winning combination.
        /// If a winning line is found, it highlights the winning buttons,
        /// shows the win message, and resets the board.
        /// </summary>

        private void CheckWin()
        {
            // Check top row: buttons 1, 2, 3

            if (button1.Text != string.Empty && button1.Text == button2.Text && button2.Text == button3.Text)
            {
                button1.BackColor = Color.YellowGreen;
                button2.BackColor = Color.YellowGreen;
                button3.BackColor = Color.YellowGreen;
                WinMessage();
                ClearAll();
            }

            // Check middle row: buttons 4, 5, 6

            else if (button4.Text != string.Empty && button4.Text == button5.Text && button5.Text == button6.Text)
            {
                button4.BackColor = Color.YellowGreen;
                button5.BackColor = Color.YellowGreen;
                button6.BackColor = Color.YellowGreen;
                WinMessage();
                ClearAll();
            }

            // Check bottom row: buttons 7, 8, 9

            else if (button7.Text != string.Empty && button7.Text == button8.Text && button8.Text == button9.Text)
            {
                button7.BackColor = Color.YellowGreen;
                button8.BackColor = Color.YellowGreen;
                button9.BackColor = Color.YellowGreen;
                WinMessage();
                ClearAll();
            }
            else if (button1.Text != string.Empty && button1.Text == button6.Text && button6.Text == button9.Text)
            {
                button1.BackColor = Color.YellowGreen;
                button6.BackColor = Color.YellowGreen;
                button9.BackColor = Color.YellowGreen;
                WinMessage();
                ClearAll();
            }
            else if (button2.Text != string.Empty && button2.Text == button5.Text && button5.Text == button8.Text)
            {
                button2.BackColor = Color.YellowGreen;
                button5.BackColor = Color.YellowGreen;
                button8.BackColor = Color.YellowGreen;
                WinMessage();
                ClearAll();
            }
            else if (button3.Text != string.Empty && button3.Text == button4.Text && button4.Text == button7.Text)
            {
                button3.BackColor = Color.YellowGreen;
                button4.BackColor = Color.YellowGreen;
                button7.BackColor = Color.YellowGreen;
                WinMessage();
                ClearAll();
            }
            else if (button1.Text != string.Empty && button1.Text == button5.Text && button5.Text == button7.Text)
            {
                button1.BackColor = Color.YellowGreen;
                button5.BackColor = Color.YellowGreen;
                button7.BackColor = Color.YellowGreen;
                WinMessage();
                ClearAll();
            }
            else if (button3.Text != string.Empty && button3.Text == button5.Text && button5.Text == button9.Text)
            {
                button3.BackColor = Color.YellowGreen;
                button5.BackColor = Color.YellowGreen;
                button9.BackColor = Color.YellowGreen;
                WinMessage();
                ClearAll();
            }
        }


        /// <summary>
        /// Handles the Click event for Button1.
        /// Writes the player's symbol on the button and checks if the move resulted in a win.
        /// </summary>
        /// <param name="sender">The button that was clicked.</param>
        /// <param name="e">Event arguments.</param>

        private void Button1_Click(object sender, EventArgs e)
        {
            WriteSymbol(sender);
            CheckWin();
        }

        // The following click event handlers for Button2 through Button9 work the same as Button1_Click:
        // They write the player's symbol on the clicked button and then check if the move resulted in a win.

        private void Button2_Click(object sender, EventArgs e)
        {
            WriteSymbol(sender);
            CheckWin();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            WriteSymbol(sender);
            CheckWin();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            WriteSymbol(sender);
            CheckWin();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            WriteSymbol(sender);
            CheckWin();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            WriteSymbol(sender);
            CheckWin();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            WriteSymbol(sender);
            CheckWin();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            WriteSymbol(sender);
            CheckWin();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            WriteSymbol(sender);
            CheckWin();
        }
    }
}
