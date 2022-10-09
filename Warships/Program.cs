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
                char[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
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
                            return;
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
                            return;
                        }
                    }
                    else if (matrix[rowToAttack, colToAttack] == '#')
                    {
                        // destroy all ships in adjacent fields

                        // left
                        if (IsCommandValid(rowToAttack, colToAttack - 1, n) && matrix[rowToAttack, colToAttack - 1] != '*')
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack, colToAttack - 1] = 'X';
                        }
                        // right
                        if (IsCommandValid(rowToAttack, colToAttack + 1, n) && matrix[rowToAttack, colToAttack + 1] != '*')
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack, colToAttack + 1] = 'X';
                        }
                        // up
                        if (IsCommandValid(rowToAttack - 1, colToAttack, n) && matrix[rowToAttack - 1, colToAttack] != '*')
                        {
                            countShipsDestroyed++;
                             matrix[rowToAttack - 1, colToAttack] = 'X';
                        }
                        // down
                        if (IsCommandValid(rowToAttack + 1, colToAttack, n) && matrix[rowToAttack + 1, colToAttack] != '*')
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack + 1, colToAttack] = 'X';
                        }
                        // diagonal up-left
                        if (IsCommandValid(rowToAttack- 1, colToAttack - 1, n) && matrix[rowToAttack - 1, colToAttack - 1] != '*')
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack - 1, colToAttack - 1] = 'X';
                        }
                        // diagonal up-right
                        if (IsCommandValid(rowToAttack - 1, colToAttack + 1, n) && matrix[rowToAttack - 1, colToAttack + 1] != '*')
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack - 1, colToAttack + 1] = 'X';
                        }
                        // diagonal down-left
                        if (IsCommandValid(rowToAttack + 1, colToAttack - 1, n) && matrix[rowToAttack + 1, colToAttack - 1] != '*')
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack + 1, colToAttack - 1] = 'X';
                        }
                        // diagonal down-right
                        if (IsCommandValid(rowToAttack + 1, colToAttack + 1, n) && matrix[rowToAttack + 1, colToAttack + 1] != '*')
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack + 1, colToAttack + 1] = 'X';
                        }

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
                }
            }

            Console.WriteLine($"It's a draw! Player One has { PlayerOneShipsLeft(matrix, n)} ships left. Player Two has {PlayerTwoShipsLeft(matrix, n)} ships left.");
        }

        static int PlayerTwoShipsLeft(char[,] matrix, int n)
        {
            int count = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == '>')
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        static int PlayerOneShipsLeft(char[,] matrix, int n)
        {
            int count = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == '<')
                    {
                        count++;
                    }
                }
            }

            return count;
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
