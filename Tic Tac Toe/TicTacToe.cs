namespace Tic_Tac_Toe
{
    public partial class TicTacToe : Form
    {
        public TicTacToe()
        {
            InitializeComponent();
        }

        public string currentPlayer = "X";
        public int currentTurn = 1;
        public int maxTurns = 9;
        public int xScoreCount = 0;
        public int oScoreCount = 0;

        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (currentPlayer == "X")
            {
                button.Text = "X";
                currentPlayer = "O";
            }
            else
            {
                button.Text = "O";
                currentPlayer = "X";
            }

            currentTurn++;
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {

        }

        private void restartGameBtn_Click(object sender, EventArgs e)
        {

        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}