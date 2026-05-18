/*
 * Angelo Ellis
 * CST - 250
 * May 16 2026
 * Minesweeper
 * Milestone 4
 */

using System;
using System.Windows.Forms;
using MinesweeperClassLibrary.Models;
using MinesweeperClassLibrary.Services.BusinessLogicLayer;
using System.Drawing;
using System.IO;


namespace MinesweeperGUI
{
    public partial class GameForm : Form
    {
        // Board service object
        private BoardService boardService = new BoardService();

        // Stores the game board
        private BoardModel board;

        // Stores board settings
        private int boardSize;
        private int difficulty;

        // Tracks the player's score
        private int score = 0;

        // Tracks reward mode
        private bool usingReward = false;

        // Game images
        private Image tileImage;
        private Image flatTileImage;
        private Image skullImage;
        private Image rewardImage;
        private Image[] numberImages = new Image[9];

        public GameForm()
        {
            InitializeComponent();
        }

        public GameForm(int boardSize, int difficulty)
        {
            InitializeComponent();

            // Save settings
            this.boardSize = boardSize;
            this.difficulty = difficulty;

            // Create the board
            board = boardService.CreateBoard(boardSize);

            // Start with reward for testing and demonstration
            board.RewardsRemaining = 1;

            // Set difficulty
            board.Difficulty = difficulty;

            // Set up bombs and neighbors
            boardService.SetupBombs(board, difficulty);
            boardService.CountBombsNearby(board);

            // Add random reward cells
            PlaceRandomRewards();

            // Update labels
            lblStartTime.Text = "Start Time: " + DateTime.Now.ToShortTimeString();
            lblScore.Text = "Score: 0";
            lblStatus.Text = "Status: Playing";
            lblRewards.Text = "Rewards: " + board.RewardsRemaining;

            // Create GUI board
            LoadImages();
            CreateButtons();
            UpdateButtonFaces();

        }

        /// <summary>
        /// Loads the game images from the Images folder
        /// </summary>
        private void LoadImages()
        {
            string imageFolder = Path.Combine(Application.StartupPath, "Images");

            tileImage = Image.FromFile(Path.Combine(imageFolder, "Tile 2.png"));
            flatTileImage = Image.FromFile(Path.Combine(imageFolder, "Tile Flat.png"));
            skullImage = Image.FromFile(Path.Combine(imageFolder, "Skull.png"));
            rewardImage = Image.FromFile(Path.Combine(imageFolder, "Gold.png"));

            for (int i = 1; i <= 8; i++)
            {
                numberImages[i] = Image.FromFile(Path.Combine(imageFolder, "Number " + i + ".png"));
            }
        }

        /// <summary>
        /// Creates the button grid
        /// </summary>
        private void CreateButtons()
        {
            // Clear any existing buttons
            panelBoard.Controls.Clear();

            // Set button size based on the panel size
            int buttonSize = Math.Min(panelBoard.Width, panelBoard.Height) / board.Size;

            // Create buttons for each cell
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    Button button = new Button();

                    button.Width = buttonSize;
                    button.Height = buttonSize;
                    button.Left = col * buttonSize;
                    button.Top = row * buttonSize;
                    button.Tag = board.Cells[row, col];
                    button.Text = "";
                    button.BackColor = Color.Gray;
                    button.Click += Button_Click;
                    button.MouseDown += Button_MouseDown;

                    panelBoard.Controls.Add(button);
                }
            }
            // Resize the panel to fit the board exactly
            panelBoard.Width = buttonSize * board.Size;
            panelBoard.Height = buttonSize * board.Size;
        }

        /// <summary>
        /// Randomly places rewards on safe cells
        /// </summary>
        private void PlaceRandomRewards()
        {
            Random rand = new Random();

            int rewardsToPlace = Math.Max(1, board.Size / 3);
            int rewardsPlaced = 0;

            while (rewardsPlaced < rewardsToPlace)
            {
                int row = rand.Next(board.Size);
                int col = rand.Next(board.Size);

                CellModel cell = board.Cells[row, col];

                if (!cell.IsBomb && !cell.HasSpecialReward)
                {
                    cell.HasSpecialReward = true;
                    rewardsPlaced++;
                }
            }
        }

        /// <summary>
        /// Handles a cell button click
        /// </summary>
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            CellModel cell = (CellModel)button.Tag;

            // Use reward mode
            if (usingReward)
            {
                if (board.RewardsRemaining > 0)
                {
                    board.RewardsRemaining--;

                    if (cell.IsBomb)
                    {
                        MessageBox.Show("Reward used: This cell has a bomb.");
                    }
                    else
                    {
                        MessageBox.Show("Reward used: This cell is safe.");
                    }

                    lblRewards.Text = "Rewards: " + board.RewardsRemaining;

                    usingReward = false;

                    lblStatus.Text = "Status: Playing";

                    return;
                }
            }

            // Visit the selected cell
            if (!cell.IsFlagged)
            {
                if (!cell.IsBomb && cell.NumberOfBombNeighbors == 0)
                {
                    boardService.FloodFill(board, cell.Row, cell.Column);
                }
                else
                {
                    cell.IsVisited = true;
                }

                // Check for reward
                if (cell.HasSpecialReward)
                {
                    board.RewardsRemaining++;

                    cell.HasSpecialReward = false;

                    lblRewards.Text = "Rewards: " + board.RewardsRemaining;

                    MessageBox.Show("You found a reward!");
                }
            }

            UpdateButtonFaces();
            UpdateScore();

            string gameState = boardService.DetermineGameState(board);

            if (gameState == "Won")
            {
                lblStatus.Text = "Status: You won!";
                MessageBox.Show("Congratulations, you won!");
            }
            else if (gameState == "Lost")
            {
                lblStatus.Text = "Status: You lost!";
                RevealAllBombs();
                MessageBox.Show("Game over. You hit a bomb.");
            }
            else
            {
                lblStatus.Text = "Status: Playing";
            }
        }

        /// <summary>
        /// Handles right-click flagging
        /// </summary>
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            CellModel cell = (CellModel)button.Tag;

            if (e.Button == MouseButtons.Right && !cell.IsVisited)
            {
                cell.IsFlagged = !cell.IsFlagged;
                UpdateButtonFaces();
            }
        }

        /// <summary>
        /// Restarts the game
        /// </summary>
        private void btnRestart_Click(object sender, EventArgs e)
        {
            // Create a new start form
            StartForm startForm = new StartForm();

            startForm.Show();

            this.Close();
        }

        /// <summary>
        /// Updates the buttons to match the board cells
        /// </summary>
        private void UpdateButtonFaces()
        {
            foreach (Control control in panelBoard.Controls)
            {
                Button button = (Button)control;
                CellModel cell = (CellModel)button.Tag;

                button.Text = "";
                button.ForeColor = Color.Black;
                button.BackgroundImageLayout = ImageLayout.Stretch;

                if (cell.IsFlagged)
                {
                    button.Text = "🚩";
                    int flagFontSize = Math.Max(8, button.Width / 8);
                    button.Font = new Font(button.Font.FontFamily, flagFontSize, FontStyle.Bold);
                    button.ForeColor = Color.Red;
                    button.BackgroundImage = tileImage;
                    button.BackColor = Color.Yellow;
                }
                else if (!cell.IsVisited)
                {
                    button.BackgroundImage = tileImage;
                    button.BackColor = Color.Gray;
                }
                else if (cell.IsBomb)
                {
                    button.BackgroundImage = skullImage;
                    button.BackColor = Color.Red;
                }
                else if (cell.HasSpecialReward)
                {
                    button.BackgroundImage = rewardImage;
                    button.BackColor = Color.LightGray;
                }
                else if (cell.NumberOfBombNeighbors == 0)
                {
                    button.BackgroundImage = flatTileImage;
                    button.BackColor = Color.LightGray;
                }
                else
                {
                    button.BackgroundImage = numberImages[cell.NumberOfBombNeighbors];
                    button.BackColor = Color.LightGray;
                }
            }
        }

        /// <summary>
        /// Updates the score based on visited safe cells
        /// </summary>
        private void UpdateScore()
        {
            score = 0;

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    CellModel cell = board.Cells[row, col];

                    if (cell.IsVisited && !cell.IsBomb)
                    {
                        score += 10;
                    }
                }
            }

            lblScore.Text = "Score: " + score;
        }

        /// <summary>
        /// Reveals all bombs after the player loses
        /// </summary>
        private void RevealAllBombs()
        {
            foreach (Control control in panelBoard.Controls)
            {
                Button button = (Button)control;
                CellModel cell = (CellModel)button.Tag;

                if (cell.IsBomb)
                {
                    cell.IsVisited = true;
                }
            }

            UpdateButtonFaces();
        }

        /// <summary>
        /// Enables reward mode
        /// </summary>
        private void btnUseReward_Click(object sender, EventArgs e)
        {
            if (board.RewardsRemaining > 0)
            {
                usingReward = true;

                lblStatus.Text = "Status: Select a cell to reveal";
            }
            else
            {
                MessageBox.Show("No rewards available.");
            }
        }
    }
}