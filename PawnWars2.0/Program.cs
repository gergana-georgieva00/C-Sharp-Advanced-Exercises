using System;

namespace PawnWars2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] chessboard = new char[8, 8];

            // fill chessboard
            for (int row = 0; row < 8; row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < 8; col++)
                {
                    chessboard[row, col] = currRow[col];
                }
            }

            // check for initial win
            int rowWhite = PositionWhite(chessboard)[0];
            int colWhite = PositionWhite(chessboard)[1];

            int rowBlack = PositionBlack(chessboard)[0];
            int colBlack = PositionBlack(chessboard)[1];

            // diagonal win
            if ((rowBlack == rowWhite - 1 && colBlack == colWhite - 1) || (rowBlack == rowWhite + 1 && colBlack == colWhite - 1)
                    || (rowBlack == rowWhite + 1 && colBlack == colWhite + 1) || (rowBlack == rowWhite - 1 && colBlack == colWhite + 1))
            {
                chessboard[rowWhite, colWhite] = '-';
                chessboard[rowBlack, colBlack] = 'w';


                Console.WriteLine($"Game over! White capture on {(char)(97 + colBlack)}{8 - rowBlack}.");
                return;
            }

            // make moves
            while (true)
            {
                rowWhite = PositionWhite(chessboard)[0];
                colWhite = PositionWhite(chessboard)[1];

                rowBlack = PositionBlack(chessboard)[0];
                colBlack = PositionBlack(chessboard)[1];

                // move white
                chessboard[rowWhite, colWhite] = '-';
                chessboard[rowWhite - 1, colWhite] = 'w';

                rowWhite--;

                if (rowWhite == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(97 + colWhite)}8.");
                    return;
                }

                if ((rowBlack == rowWhite - 1 && colBlack == colWhite - 1) || (rowBlack == rowWhite + 1 && colBlack == colWhite - 1)
                    || (rowBlack == rowWhite + 1 && colBlack == colWhite + 1) || (rowBlack == rowWhite - 1 && colBlack == colWhite + 1))
                {
                    chessboard[rowWhite, colWhite] = '-';
                    chessboard[rowBlack, colBlack] = 'w';

                    Console.WriteLine($"Game over! White capture on {(char)(97 + colBlack)}{8 - rowBlack}.");
                    return;
                }


                // move black
                chessboard[rowBlack, colBlack] = '-';
                chessboard[rowBlack + 1, colBlack] = 'b';

                rowBlack++;

                // check if black wins
                if (rowBlack == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(97 + colBlack)}1.");
                    return;
                }

                // diagonal win
                if ((rowBlack == rowWhite - 1 && colBlack == colWhite - 1) || (rowBlack == rowWhite + 1 && colBlack == colWhite - 1)
                    || (rowBlack == rowWhite + 1 && colBlack == colWhite + 1) || (rowBlack == rowWhite - 1 && colBlack == colWhite + 1))
                {
                    chessboard[rowWhite, colWhite] = '-';
                    chessboard[rowBlack, colBlack] = 'b';

                    Console.WriteLine($"Game over! Black capture on {(char)(97 + colBlack)}{8 - rowBlack}.");
                    return;
                }
            }
        }

        static int[] PositionWhite(char[,] chessboard)
        {
            int[] coordinates = new int[2];

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (chessboard[row, col] == 'w')
                    {
                        coordinates[0] = row;
                        coordinates[1] = col;

                        return coordinates;
                    }
                }
            }

            return coordinates;
        }

        static int[] PositionBlack(char[,] chessboard)
        {
            int[] coordinates = new int[2];

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (chessboard[row, col] == 'b')
                    {
                        coordinates[0] = row;
                        coordinates[1] = col;

                        return coordinates;
                    }
                }
            }

            return coordinates;
        }
    }
}
