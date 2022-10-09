using System;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            string[] attackCoordinates = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < n; row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int countShipsDestroyed = 0;

            foreach (var coordPair in attackCoordinates)
            {
                int[] splitPair = coordPair.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int rowToAttack = splitPair[0];
                int colToAttack = splitPair[1];

                if (IsCommandValid(rowToAttack, colToAttack, n))
                {
                    if (matrix[rowToAttack, colToAttack] == '<')
                    {
                        matrix[rowToAttack, colToAttack] = 'X';
                        countShipsDestroyed++;

                        if (IsGameOver(matrix, n))
                        {
                            int winner = WhoWins(matrix, n);

                            if (winner == 1)
                            {
                                Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }

                            Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                        }
                    }
                    else if (matrix[rowToAttack, colToAttack] == '>')
                    {
                        matrix[rowToAttack, colToAttack] = 'X';
                        countShipsDestroyed++;

                        if (IsGameOver(matrix, n))
                        {
                            int winner = WhoWins(matrix, n);

                            if (winner == 1)
                            {
                                Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }

                            Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                        }
                    }
                    else if (matrix[rowToAttack, colToAttack] == '#')
                    {

                    }
                }
            }
        }

        static int WhoWins(char[,] matrix, int n)
        {
            int player1Count = 0;
            int player2Count = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == '<')
                    {
                        player1Count++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        player2Count++;
                    }
                }
            }

            if (player2Count == 0)
            {
                return 1;
            }

            return 2;
        }

        static bool IsGameOver(char[,] matrix, int n)
        {
            int player1Count = 0;
            int player2Count = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == '<')
                    {
                        player1Count++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        player2Count++;
                    }
                }
            }

            if (player1Count == 0 || player2Count == 0)
            {
                return true;
            }

            return false;
        }

        static bool IsCommandValid(int rowToAttack, int colToAttack, int n)
        {
            if (rowToAttack >= 0 && colToAttack >= 0 && rowToAttack < n && colToAttack < n)
            {
                return true;
            }

            return false;
        }
    }
}
