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
        public int minTurnsRequiredToScore = 5;
        public int maxTurns = 9;
        public int xScoreCount = 0;
        public int oScoreCount = 0;
        public int drawsCount = 0;

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            xScore.Text = $"X score: {xScoreCount}";
            oScore.Text = $"O score: {oScoreCount}";
            draws.Text = $"Draws:   {drawsCount}";
        }

        private void boxClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            bool boxIsEmpty = string.IsNullOrWhiteSpace(button.Text);

            if (boxIsEmpty)
            {
                if (currentPlayer == "X")
                {
                    button.Text = "X";

                    bool hasWinner = CheckForWinner();
                    if (currentTurn >= minTurnsRequiredToScore && hasWinner)
                    {
                        xScoreCount++;
                        xScore.Text = $"X score: {xScoreCount}";
                        restartGameBtn_Click(sender, e);
                    }

                    currentPlayer = "O";
                }
                else
                {
                    button.Text = "O";

                    bool hasWinner = CheckForWinner();
                    if (currentTurn >= minTurnsRequiredToScore && hasWinner)
                    {
                        oScoreCount++;
                        oScore.Text = $"O score: {oScoreCount}";
                        restartGameBtn_Click(sender, e);
                    }

                    currentPlayer = "X";
                }

                currentTurn++;
            }

        }

        private bool CheckForWinner()
        {
            // horizontal
            if (box1.Text == box2.Text && box1.Text == box3.Text && !string.IsNullOrWhiteSpace(box1.Text))
            {
                return true;
            }
            else if (box4.Text == box5.Text && box4.Text == box6.Text && !string.IsNullOrWhiteSpace(box4.Text))
            {
                return true;
            }
            else if (box7.Text == box8.Text && box7.Text == box9.Text && !string.IsNullOrWhiteSpace(box7.Text))
            {
                return true;
            }

            // vertical
            if (box1.Text == box4.Text && box1.Text == box7.Text && !string.IsNullOrWhiteSpace(box1.Text))
            {
                return true;
            }
            else if (box2.Text == box5.Text && box2.Text == box8.Text && !string.IsNullOrWhiteSpace(box2.Text))
            {
                return true;
            }
            else if (box3.Text == box6.Text && box3.Text == box9.Text && !string.IsNullOrWhiteSpace(box3.Text))
            {
                return true;
            }

            // diagonal
            if (box1.Text == box5.Text && box1.Text == box9.Text && !string.IsNullOrWhiteSpace(box1.Text))
            {
                return true;
            }
            else if (box3.Text == box5.Text && box3.Text == box7.Text && !string.IsNullOrWhiteSpace(box3.Text))
            {
                return true;
            }

            return false;

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

            xScore.Text = $"X score: {xScoreCount}";
            oScore.Text = $"O score: {oScoreCount}";
            draws.Text = $"Draws:   {drawsCount}";

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}