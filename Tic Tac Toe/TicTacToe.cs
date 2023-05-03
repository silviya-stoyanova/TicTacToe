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
        public int drawsCount = 0;

        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (string.IsNullOrWhiteSpace(button.Text))
            {


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

                if (currentTurn == maxTurns)
                {

                }

                currentTurn++;
            }

        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            xScore.Text = $"X score: {xScoreCount}";
            oScore.Text = $"O score: {oScoreCount}";
            draws.Text = $"Draws:   {drawsCount}";
        }

        private void restartGameBtn_Click(object sender, EventArgs e)
        {
            box1.Text = "";
            box2.Text = "";
            box3.Text = "";
            box4.Text = "";
            box5.Text = "";
            box6.Text = "";
            box7.Text = "";
            box8.Text = "";
            box9.Text = "";

            currentPlayer = "X";
            currentTurn = 1;
        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            restartGameBtn_Click(sender, e);

            xScoreCount = 0;
            oScoreCount = 0;
            drawsCount = 0;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}