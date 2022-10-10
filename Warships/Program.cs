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

            for (int i = 0; i < attackCoordinates.Length; i++)
            {
                string coordPair = attackCoordinates[i];

                int[] splitPair = coordPair.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int rowToAttack = splitPair[0];
                int colToAttack = splitPair[1];

                if (IsCommandValid(rowToAttack, colToAttack, n))
                {
                    if (matrix[rowToAttack, colToAttack] == '<')
                    {
                        matrix[rowToAttack, colToAttack] = 'X';
                        countShipsDestroyed++;

                        if (PlayerOneShipsLeft(matrix, n) <= 0)
                        {
                            Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                            break;
                        }

                        if (PlayerTwoShipsLeft(matrix, n) <= 0)
                        {
                            Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                            break;
                        }
                    }
                    else if (matrix[rowToAttack, colToAttack] == '>')
                    {
                        matrix[rowToAttack, colToAttack] = 'X';
                        countShipsDestroyed++;

                        if (PlayerOneShipsLeft(matrix, n) <= 0)
                        {
                            Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                            break;
                        }

                        if (PlayerTwoShipsLeft(matrix, n) <= 0)
                        {
                            Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                            break;
                        }
                    }
                    else if (matrix[rowToAttack, colToAttack] == '#')
                    {
                        matrix[rowToAttack, colToAttack] = 'X';
                        // destroy all ships in adjacent fields

                        // left
                        if (colToAttack - 1 >= 0)
                        {
                            if (matrix[rowToAttack, colToAttack - 1] != '*')
                            {
                                countShipsDestroyed++;
                            }
                            
                            matrix[rowToAttack, colToAttack - 1] = 'X';
                            if (PlayerOneShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }

                            if (PlayerTwoShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        // right
                        if (colToAttack + 1 < n)
                        {
                            if (matrix[rowToAttack, colToAttack + 1] != '*')
                            {
                                countShipsDestroyed++;
                            }

                            matrix[rowToAttack, colToAttack + 1] = 'X';
                            if (PlayerOneShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }

                            if (PlayerTwoShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        // up
                        if (rowToAttack - 1 >= 0)
                        {
                            if (matrix[rowToAttack - 1, colToAttack] != '*')
                            {
                                countShipsDestroyed++;
                            }

                            matrix[rowToAttack - 1, colToAttack] = 'X';
                            if (PlayerOneShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }

                            if (PlayerTwoShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        // down
                        if (rowToAttack + 1 < n)
                        {
                            if (matrix[rowToAttack + 1, colToAttack] != '*')
                            {
                                countShipsDestroyed++;
                            }

                            matrix[rowToAttack + 1, colToAttack] = 'X';
                            if (PlayerOneShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }

                            if (PlayerTwoShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        // diagonal up-left
                        if (rowToAttack - 1 >= 0 && colToAttack - 1 >= 0)
                        {
                            if (matrix[rowToAttack - 1, colToAttack - 1] != '*')
                            {
                                countShipsDestroyed++;
                            }

                            matrix[rowToAttack - 1, colToAttack - 1] = 'X';
                            if (PlayerOneShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }

                            if (PlayerTwoShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        // diagonal up-right
                        if (rowToAttack - 1 >= 0 && colToAttack + 1 < n)
                        {
                            if (matrix[rowToAttack - 1, colToAttack + 1] != '*')
                            {
                                countShipsDestroyed++;
                            }

                            matrix[rowToAttack - 1, colToAttack + 1] = 'X';
                            if (PlayerOneShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }

                            if (PlayerTwoShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        // diagonal down-left
                        if (rowToAttack + 1 < n && colToAttack - 1 >= 0)
                        {
                            if (matrix[rowToAttack + 1, colToAttack - 1] != '*')
                            {
                                countShipsDestroyed++;
                            }

                            matrix[rowToAttack + 1, colToAttack - 1] = 'X';
                            if (PlayerOneShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }

                            if (PlayerTwoShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        // diagonal down-right
                        if (rowToAttack + 1 < n && colToAttack + 1 < n)
                        {
                            if (matrix[rowToAttack + 1, colToAttack + 1] != '*')
                            {
                                countShipsDestroyed++;
                            }

                            matrix[rowToAttack + 1, colToAttack + 1] = 'X';
                            if (PlayerOneShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }

                            if (PlayerTwoShipsLeft(matrix, n) <= 0)
                            {
                                Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                                return;
                            }
                        }

                        if (PlayerOneShipsLeft(matrix, n) <= 0)
                        {
                            Console.WriteLine($"Player Two has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                            return;
                        }

                        if (PlayerTwoShipsLeft(matrix, n) <= 0)
                        {
                            Console.WriteLine($"Player One has won the game! {countShipsDestroyed} ships have been sunk in the battle.");
                            return;
                        }
                    }
                }
            }

            if (PlayerOneShipsLeft(matrix, n) > 0 && PlayerTwoShipsLeft(matrix, n) > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {PlayerOneShipsLeft(matrix, n)} ships left. Player Two has {PlayerTwoShipsLeft(matrix, n)} ships left.");
            }
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

        static bool IsGameOver(char[,] matrix, int n)
        {
            int player1Count = PlayerOneShipsLeft(matrix, n);
            int player2Count = PlayerTwoShipsLeft(matrix, n);

            if (player1Count > 0 && player2Count > 0)
            {
                return false;
            }

            return true;
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
