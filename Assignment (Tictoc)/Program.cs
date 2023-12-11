using System;

class TicTacToe
{
    private static char[,] board = new char[3, 3];
    private static char currentPlayer = 'X';
    private static bool gameover = false;

    static void Main()
    {
        InitializeBoard();
        while (!gameover)
        {
            DisplayBoard();
            GetPlayerMove();
            CheckForWin();
            CheckForDraw();
            SwitchPlayer();
        }
    }

    static void InitializeBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = ' ';
            }
        }
    }

    static void DisplayBoard()
    {
        Console.Clear();
        Console.WriteLine("  0 1 2");
        for (int row = 0; row < 3; row++)
        {
            Console.Write(row + " ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    static void GetPlayerMove()
    {
        Console.WriteLine($"Player {currentPlayer}, enter your move (row and column):");
        bool validMove = false;
        while (!validMove)
        {
            string[] input = Console.ReadLine().Split();
            if (input.Length == 2 && int.TryParse(input[0], out int row) && int.TryParse(input[1], out int col)
                && row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                validMove = true;
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }
    }

    static void CheckForWin()
    {
        // Check rows, columns, and diagonals for a win
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer) ||
                (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
            {
                DisplayBoard();
                Console.WriteLine($"Player {currentPlayer} wins!");
                gameover = true;
                return;
            }
        }
    }

    static void CheckForDraw()
    {
        // Check for a draw (all cells filled)
        bool isBoardFull = true;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == ' ')
                {
                    isBoardFull = false;
                    break;
                }
            }
        }

        if (isBoardFull)
        {
            DisplayBoard();
            Console.WriteLine("It's a draw!");
            gameover = true;
        }
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }
}
