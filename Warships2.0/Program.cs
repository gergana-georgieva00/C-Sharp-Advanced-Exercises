using System;
using System.Linq;

namespace Warships2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            string[] attackCoordinates = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            // fill matrix
            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            // logic
            int countShipsDestroyed = 0;
            foreach (var pair in attackCoordinates)
            {
                int[] splitPair = pair.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int rowToAttack = splitPair[0];
                int colToAttack = splitPair[1];

                if (IsCommandValid(rowToAttack, colToAttack, n))
                {
                    if (matrix[rowToAttack, colToAttack] == '<' || matrix[rowToAttack, colToAttack] == '>')
                    {
                        matrix[rowToAttack, colToAttack] = 'X';
                        countShipsDestroyed++;
                    }
                    else if (matrix[rowToAttack, colToAttack] == '#')
                    {
                        // destroy all ships in adjacent fields

                        // left
                        if (colToAttack - 1 >= 0)
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack, colToAttack - 1] = 'X';
                        }
                        // right
                        if (colToAttack + 1 < n)
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack, colToAttack + 1] = 'X';
                        }
                        // up
                        if (rowToAttack - 1 >= 0)
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack - 1, colToAttack] = 'X';
                        }
                        // down
                        if (rowToAttack + 1 < n)
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack + 1, colToAttack] = 'X';
                        }
                        // diagonal up-left
                        if (rowToAttack - 1 >= 0 && colToAttack - 1 >= 0)
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack - 1, colToAttack - 1] = 'X';
                        }
                        // diagonal up-right
                        if (rowToAttack - 1 >= 0 && colToAttack + 1 < n)
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack - 1, colToAttack + 1] = 'X';
                        }
                        // diagonal down-left
                        if (rowToAttack + 1 < n && colToAttack - 1 >= 0)
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack + 1, colToAttack - 1] = 'X';
                        }
                        // diagonal down-right
                        if (rowToAttack + 1 < n && colToAttack + 1 < n)
                        {
                            countShipsDestroyed++;
                            matrix[rowToAttack + 1, colToAttack + 1] = 'X';
                        }
                    }
                }

                int plOneShipsLeft = 0;
                int pl2ShipsLeft = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == '<')
                        {
                            plOneShipsLeft++;
                        }

                        if (matrix[row, col] == '>')
                        {
                            pl2ShipsLeft++;
                        }
                    }
                }

                if (plOneShipsLeft <= 0)
                {
                    Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                    return;
                }

                if (pl2ShipsLeft <= 0)
                {
                    Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                    return;
                }
            }

            int playerOneShipsLeft = 0;
            int player2ShipsLeft = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == '<')
                    {
                        playerOneShipsLeft++;
                    }

                    if (matrix[row, col] == '>')
                    {
                        player2ShipsLeft++;
                    }
                }
            }

            if (playerOneShipsLeft <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                return;
            }

            if (player2ShipsLeft <= 0)
            {
                Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                return;
            }

            Console.WriteLine($"It's a draw! Player One has {playerOneShipsLeft} ships left. Player Two has {player2ShipsLeft} ships left.");
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
