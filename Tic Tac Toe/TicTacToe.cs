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
        public int minTurnsRequiredToWin = 5;
        public int xScoreCount = 0;
        public int oScoreCount = 0;
        public int drawsCount = 0;

        public List<Button> GetBoxes()
        {
            return new List<Button>()
            {
                box1, box2, box3, box4, box5, box6, box7, box8, box9
            };
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            xScore.Text = $"X score: {xScoreCount}";
            oScore.Text = $"O score: {oScoreCount}";
            draws.Text = $"Draws:   {drawsCount}";
        }

        private void HandleBoxClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            bool boxIsEmpty = string.IsNullOrWhiteSpace(button.Text);
            bool hasWinnerOrDraw = false;

            if (boxIsEmpty)
            {
                if (currentPlayer == "X")
                {
                    button.Text = "X";

                    if (currentTurn >= minTurnsRequiredToWin)
                    {
                        hasWinnerOrDraw = CheckForWinner(sender, e);
                    }

                    if (!hasWinnerOrDraw)
                    {
                        currentPlayer = "O";
                    }
                }
                else
                {
                    button.Text = "O";

                    if (currentTurn >= minTurnsRequiredToWin)
                    {
                        hasWinnerOrDraw = CheckForWinner(sender, e);
                    }

                    if (!hasWinnerOrDraw)
                    {
                        currentPlayer = "X";
                    }
                }

                if (!hasWinnerOrDraw)
                {
                    currentTurn++;
                }
            }
        }

        private bool CheckForWinner(object sender, EventArgs e)
        {
            bool hasWinnerOrDraw = false;

            // horizontal
            if (box1.Text == box2.Text && box1.Text == box3.Text && !string.IsNullOrWhiteSpace(box1.Text))
            {
                hasWinnerOrDraw = true;
            }
            else if (box4.Text == box5.Text && box4.Text == box6.Text && !string.IsNullOrWhiteSpace(box4.Text))
            {
                hasWinnerOrDraw = true;
            }
            else if (box7.Text == box8.Text && box7.Text == box9.Text && !string.IsNullOrWhiteSpace(box7.Text))
            {
                hasWinnerOrDraw = true;
            }

            // vertical
            if (box1.Text == box4.Text && box1.Text == box7.Text && !string.IsNullOrWhiteSpace(box1.Text))
            {
                hasWinnerOrDraw = true;
            }
            else if (box2.Text == box5.Text && box2.Text == box8.Text && !string.IsNullOrWhiteSpace(box2.Text))
            {
                hasWinnerOrDraw = true;
            }
            else if (box3.Text == box6.Text && box3.Text == box9.Text && !string.IsNullOrWhiteSpace(box3.Text))
            {
                hasWinnerOrDraw = true;
            }

            // diagonal
            if (box1.Text == box5.Text && box1.Text == box9.Text && !string.IsNullOrWhiteSpace(box1.Text))
            {
                hasWinnerOrDraw = true;
            }
            else if (box3.Text == box5.Text && box3.Text == box7.Text && !string.IsNullOrWhiteSpace(box3.Text))
            {
                hasWinnerOrDraw = true;
            }

            if (hasWinnerOrDraw)
            {
                if (currentPlayer == "X")
                {
                    xScoreCount++;
                    xScore.Text = $"{currentPlayer} score: {xScoreCount}";
                }
                else
                {
                    oScoreCount++;
                    oScore.Text = $"{currentPlayer} score: {oScoreCount}";
                }


                RestartGame(sender, e);
            }
            else if (currentTurn == maxTurns)
            {
                hasWinnerOrDraw = true;
                CheckForDraw(sender, e);
            }

            return hasWinnerOrDraw;
        }

        private void CheckForDraw(object sender, EventArgs e)
        {
            drawsCount++;
            draws.Text = $"Draws:   {drawsCount}";
            RestartGame(sender, e);
        }

        private void RestartGame(object sender, EventArgs e)
        {
            GetBoxes().ForEach(box => box.Text = "");
            currentPlayer = "X";
            currentTurn = 1;
        }

        private void CreateNewGame(object sender, EventArgs e)
        {
            RestartGame(sender, e);

            xScoreCount = 0;
            oScoreCount = 0;
            drawsCount = 0;

            xScore.Text = $"X score: {xScoreCount}";
            oScore.Text = $"O score: {oScoreCount}";
            draws.Text = $"Draws:   {drawsCount}";
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}