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
            while (true)
            {
                // get current positions
               int currRowW = PositionWhite(chessboard)[0];
               int currColW = PositionWhite(chessboard)[1];

               int currRowB = PositionBlack(chessboard)[0];
               int currColB = PositionBlack(chessboard)[1];

                // diagonal win
                if (currRowW - 1 >= 0 && currColW - 1 >= 0 && currColB == currColW - 1 && currRowB == currRowW - 1)
                {
                    chessboard[currRowW, currColW] = '-';
                    chessboard[currRowB, currColB] = 'w';

                    switch (currRowB)
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
                    switch (currColB)
                    {
                        case 0:
                            col = 'a';
                            break;
                        case 1:
                            col = 'b';
                            break;
                        case 2:
                            col = 'c';
                            break;
                        case 3:
                            col = 'd';
                            break;
                        case 4:
                            col = 'e';
                            break;
                        case 5:
                            col = 'f';
                            break;
                        case 6:
                            col = 'g';
                            break;
                        case 7:
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
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {colW}8.");
                        return;
                    }

                    chessboard[currRowW, currColW] = '-';
                    chessboard[currRowW - 1, currColW] = 'w';

                    if (currRowW - 1 == 0)
                    {
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

                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {colW}8.");
                        return;
                    }


                    // move black
                    if (currRowB == 7)
                    {
                        char colB = 'a';
                        switch (currColB)
                        {
                            case 0:
                                colB = 'a';
                                break;
                            case 1:
                                colB = 'b';
                                break;
                            case 2:
                                colB = 'c';
                                break;
                            case 3:
                                colB = 'd';
                                break;
                            case 4:
                                colB = 'e';
                                break;
                            case 5:
                                colB = 'f';
                                break;
                            case 6:
                                colB = 'g';
                                break;
                            case 7:
                                colB = 'h';
                                break;
                        }
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {colB}1.");
                        return;
                    }

                    chessboard[currRowB, currColB] = '-';
                    chessboard[currRowB + 1, currColB] = 'b';

                    if (currColB  + 1 == 7)
                    {
                        char colB = 'a';
                        switch (currColB)
                        {
                            case 0:
                                colB = 'a';
                                break;
                            case 1:
                                colB = 'b';
                                break;
                            case 2:
                                colB = 'c';
                                break;
                            case 3:
                                colB = 'd';
                                break;
                            case 4:
                                colB = 'e';
                                break;
                            case 5:
                                colB = 'f';
                                break;
                            case 6:
                                colB = 'g';
                                break;
                            case 7:
                                colB = 'h';
                                break;
                        }

                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {colB}1.");
                        return;
                    }

                    // check for diagonal win
                    // get current positions
                    currRowW = PositionWhite(chessboard)[0];
                    currColW = PositionWhite(chessboard)[1];

                    currRowB = PositionBlack(chessboard)[0];
                    currColB = PositionBlack(chessboard)[1];

                    if (currRowW - 1 >= 0 && currColW - 1 >= 0 && currColB == currColW - 1 && currRowB == currRowW - 1)
                    {
                        chessboard[currRowW, currColW] = '-';
                        chessboard[currRowW - 1, currColW - 1] = 'w';

                        switch (currRowB)
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
                        switch (currColB)
                        {
                            case 0:
                                col = 'a';
                                break;
                            case 1:
                                col = 'b';
                                break;
                            case 2:
                                col = 'c';
                                break;
                            case 3:
                                col = 'd';
                                break;
                            case 4:
                                col = 'e';
                                break;
                            case 5:
                                col = 'f';
                                break;
                            case 6:
                                col = 'g';
                                break;
                            case 7:
                                col = 'h';
                                break;
                        }

                        Console.WriteLine($"Game over! White capture on {col}{currRowW}.");
                        return;
                    }
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
