using System;
using System.IO;

// Structure to represent a move on the Tic-Tac-Toe board
struct Move
{
    public int Row;
    public int Col;

    public Move(int row, int col)
    {
        Row = row;
        Col = col;
    }
}

// Abstract base class to demonstrate inheritance
abstract class Player
{
    public string Name { get; set; }
    public char Symbol { get; set; }

    public Player(string name, char symbol)
    {
        Name = name;
        Symbol = symbol;
    }

    public abstract Move GetMove();
}

// HumanPlayer inherits from Player
class HumanPlayer : Player
{
    public HumanPlayer(string name, char symbol) : base(name, symbol) { }

    public override Move GetMove()
    {
        Console.WriteLine($"{Name} ({Symbol}), enter your move (row and column 0-2): ");
        int row = int.Parse(Console.ReadLine());
        int col = int.Parse(Console.ReadLine());
        return new Move(row, col);
    }
}

class TicTacToe
{
    private char[,] board = new char[3, 3];
    private Player player1;
    private Player player2;

    public TicTacToe(Player p1, Player p2)
    {
        player1 = p1;
        player2 = p2;
        InitializeBoard();
    }

    // Initialize board with empty spaces
    private void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                board[i, j] = ' ';
    }

    // Print the board to console
    private void PrintBoard()
    {
        Console.WriteLine("Board:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(" --- --- ---");
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"| {board[i, j]} ");
            }
            Console.WriteLine("|");
        }
        Console.WriteLine(" --- --- ---");
    }

    // Check if a player has won
    private bool CheckWin(char symbol)
    {
        // Rows, Columns, Diagonals
        for (int i = 0; i < 3; i++)
            if (board[i, 0] == symbol && board[i, 1] == symbol && board[i, 2] == symbol)
                return true;

        for (int j = 0; j < 3; j++)
            if (board[0, j] == symbol && board[1, j] == symbol && board[2, j] == symbol)
                return true;

        if (board[0, 0] == symbol && board[1, 1] == symbol && board[2, 2] == symbol)
            return true;

        if (board[0, 2] == symbol && board[1, 1] == symbol && board[2, 0] == symbol)
            return true;

        return false;
    }

    // Check if the board is full
    private bool IsBoardFull()
    {
        foreach (char c in board)
        {
            if (c == ' ')
                return false;
        }
        return true;
    }

    // Play the game
    public void Play()
    {
        Player current = player1;
        bool gameOver = false;

        while (!gameOver)
        {
            PrintBoard();
            Move move = current.GetMove();

            if (board[move.Row, move.Col] == ' ')
            {
                board[move.Row, move.Col] = current.Symbol;

                if (CheckWin(current.Symbol))
                {
                    PrintBoard();
                    Console.WriteLine($"{current.Name} wins!");

                    // Save result to file
                    File.AppendAllText("results.txt", $"{DateTime.Now}: {current.Name} ({current.Symbol}) won!\n");
                    gameOver = true;
                }
                else if (IsBoardFull())
                {
                    PrintBoard();
                    Console.WriteLine("It's a draw!");
                    File.AppendAllText("results.txt", $"{DateTime.Now}: Game ended in a draw.\n");
                    gameOver = true;
                }
                else
                {
                    // Switch turns
                    current = (current == player1) ? player2 : player1;
                }
            }
            else
            {
                Console.WriteLine("Cell already occupied! Try again.");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create two players
        Player p1 = new HumanPlayer("Player 1", 'X');
        Player p2 = new HumanPlayer("Player 2", 'O');

        // Start game
        TicTacToe game = new TicTacToe(p1, p2);
        game.Play();

        Console.WriteLine("Game finished! Results saved to results.txt");
    }
}
