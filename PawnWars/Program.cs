using System;

namespace PawnWars
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

            // make moves
            int currRowW = PositionWhite(chessboard)[0];
            int currColW = PositionWhite(chessboard)[1];

            int currRowB = PositionBlack(chessboard)[0];
            int currColB = PositionBlack(chessboard)[1];

            while (currRowW >= 0 && currRowB < 8)
            {
               currRowW = PositionWhite(chessboard)[0];
               currColW = PositionWhite(chessboard)[1];

               currRowB = PositionBlack(chessboard)[0];
               currColB = PositionBlack(chessboard)[1];

                // diagonal win
                if (currColW - 1 >= 0 && currRowW - 1 >= 0 && currRowW + 1 < 8 && chessboard[currRowW - 1, currColW - 1] == 'b')
                {
                    chessboard[currRowW, currColW] = '-';
                    chessboard[currRowW - 1, currColW - 1] = 'w';

                    switch (currRowW - 1)
                    {
                        case 0:
                            currRowW = 8;
                            break;
                        case 1:
                            currRowW = 7;
                            break;
                        case 2:
                            currRowW = 6;
                            break;
                        case 3:
                            currRowW = 5;
                            break;
                        case 4:
                            currRowW = 4;
                            break;
                        case 5:
                            currRowW = 3;
                            break;
                        case 6:
                            currRowW = 2;
                            break;
                        case 7:
                            currRowW = 1;
                            break;
                    }

                    char col = 'a';
                    switch (currColW - 1)
                    {
                        case 1:
                            col = 'a';
                            break;
                        case 2:
                            col = 'b';
                            break;
                        case 3:
                            col = 'c';
                            break;
                        case 4:
                            col = 'd';
                            break;
                        case 5:
                            col = 'e';
                            break;
                        case 6:
                            col = 'f';
                            break;
                        case 7:
                            col = 'g';
                            break;
                        case 8:
                            col = 'h';
                            break;
                    }

                    Console.WriteLine($"Game over! White capture on {col}{currRowW}.");
                    return;
                }
                // regular move
                else
                {
                    // move white
                    

                    if (currRowW == 0)
                    {
                        switch (currRowW)
                        {
                            case 0:
                                currRowW = 8;
                                break;
                            case 1:
                                currRowW = 7;
                                break;
                            case 2:
                                currRowW = 6;
                                break;
                            case 3:
                                currRowW = 5;
                                break;
                            case 4:
                                currRowW = 4;
                                break;
                            case 5:
                                currRowW = 3;
                                break;
                            case 6:
                                currRowW = 2;
                                break;
                            case 7:
                                currRowW = 1;
                                break;
                        }

                        char colW = 'a';
                        switch (currColW)
                        {
                            case 0:
                                colW = 'a';
                                break;
                            case 1:
                                colW = 'b';
                                break;
                            case 2:
                                colW = 'c';
                                break;
                            case 3:
                                colW = 'd';
                                break;
                            case 4:
                                colW = 'e';
                                break;
                            case 5:
                                colW = 'f';
                                break;
                            case 6:
                                colW = 'g';
                                break;
                            case 7:
                                colW = 'h';
                                break;
                        }

                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {colW}{currRowW}.");
                        return;
                    }

                    chessboard[currRowW, currColW] = '-';
                    chessboard[currRowW - 1, currColW] = 'w';

                    // move black
                    

                    if (currColB == 7)
                    {
                        switch (currRowB + 1)
                        {
                            case 0:
                                currRowB = 8;
                                break;
                            case 1:
                                currRowB = 7;
                                break;
                            case 2:
                                currRowB = 6;
                                break;
                            case 3:
                                currRowB = 5;
                                break;
                            case 4:
                                currRowB = 4;
                                break;
                            case 5:
                                currRowB = 3;
                                break;
                            case 6:
                                currRowB = 2;
                                break;
                            case 7:
                                currRowB = 1;
                                break;
                        }

                        char colB = 'a';
                        switch (currColB)
                        {
                            case 1:
                                colB = 'a';
                                break;
                            case 2:
                                colB = 'b';
                                break;
                            case 3:
                                colB = 'c';
                                break;
                            case 4:
                                colB = 'd';
                                break;
                            case 5:
                                colB = 'e';
                                break;
                            case 6:
                                colB = 'f';
                                break;
                            case 7:
                                colB = 'g';
                                break;
                            case 8:
                                colB = 'h';
                                break;
                        }

                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {colB}{currRowB}.");
                        return;
                    }

                    chessboard[currRowB, currColB] = '-';
                    chessboard[currRowB + 1, currColB] = 'b';
                }
            }
        }

        static int[] PositionWhite (char[,] chessboard)
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
