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

            if (rowWhite == 0)
            {
                char colW = 'a';
                switch (colWhite)
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

            if (rowBlack == 7)
            {
                char colB = 'a';
                switch (colBlack)
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

            // diagonal win
            if ((rowBlack == rowWhite - 1 && colBlack == colWhite - 1) || (rowBlack == rowWhite + 1 && colBlack == colWhite - 1))
            {
                chessboard[rowWhite, colWhite] = '-';
                chessboard[rowBlack, colBlack] = 'w';

                switch (rowBlack)
                {
                    case 0:
                        rowWhite = 8;
                        break;
                    case 1:
                        rowWhite = 7;
                        break;
                    case 2:
                        rowWhite = 6;
                        break;
                    case 3:
                        rowWhite = 5;
                        break;
                    case 4:
                        rowWhite = 4;
                        break;
                    case 5:
                        rowWhite = 3;
                        break;
                    case 6:
                        rowWhite = 2;
                        break;
                    case 7:
                        rowWhite = 1;
                        break;
                }

                char colB = 'a';
                switch (colBlack)
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

                Console.WriteLine($"Game over! White capture on {colB}{rowWhite}.");
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

                // check if white wins
                rowWhite = PositionWhite(chessboard)[0];
                colWhite = PositionWhite(chessboard)[1];

                rowBlack = PositionBlack(chessboard)[0];
                colBlack = PositionBlack(chessboard)[1];
                // diagonal win
                if ((rowBlack == rowWhite - 1 && colBlack == colWhite - 1) || (rowBlack == rowWhite + 1 && colBlack == colWhite - 1)
                    || (rowBlack == rowWhite + 1 && colBlack == colWhite + 1) || (rowBlack == rowWhite - 1 && colBlack == colWhite + 1))
                {
                    chessboard[rowBlack, colBlack] = '-';
                    chessboard[rowBlack, colBlack] = 'w';

                    switch (rowBlack)
                    {
                        case 0:
                            rowWhite = 8;
                            break;
                        case 1:
                            rowWhite = 7;
                            break;
                        case 2:
                            rowWhite = 6;
                            break;
                        case 3:
                            rowWhite = 5;
                            break;
                        case 4:
                            rowWhite = 4;
                            break;
                        case 5:
                            rowWhite = 3;
                            break;
                        case 6:
                            rowWhite = 2;
                            break;
                        case 7:
                            rowWhite = 1;
                            break;
                    }

                    char colB = 'a';
                    switch (colBlack)
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

                    Console.WriteLine($"Game over! White capture on {colB}{rowWhite}.");
                    return;
                }

                if (rowWhite == 0)
                {
                    char colW = 'a';
                    switch (colWhite)
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
                chessboard[rowBlack, colBlack] = '-';
                chessboard[rowBlack + 1, colBlack] = 'b';

                // check if black wins
                rowWhite = PositionWhite(chessboard)[0];
                colWhite = PositionWhite(chessboard)[1];

                rowBlack = PositionBlack(chessboard)[0];
                colBlack = PositionBlack(chessboard)[1];

                if (rowBlack == 7)
                {
                    char colB = 'a';
                    switch (colBlack)
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

                // diagonal win
                if ((rowBlack == rowWhite - 1 && colBlack == colWhite - 1) || (rowBlack == rowWhite + 1 && colBlack == colWhite - 1)
                    || (rowBlack == rowWhite + 1 && colBlack == colWhite + 1) || (rowBlack == rowWhite - 1 && colBlack == colWhite + 1))
                {
                    chessboard[rowWhite, colWhite] = '-';
                    chessboard[rowBlack, colBlack] = 'w';

                    switch (rowBlack)
                    {
                        case 0:
                            rowWhite = 8;
                            break;
                        case 1:
                            rowWhite = 7;
                            break;
                        case 2:
                            rowWhite = 6;
                            break;
                        case 3:
                            rowWhite = 5;
                            break;
                        case 4:
                            rowWhite = 4;
                            break;
                        case 5:
                            rowWhite = 3;
                            break;
                        case 6:
                            rowWhite = 2;
                            break;
                        case 7:
                            rowWhite = 1;
                            break;
                    }

                    char colB = 'a';
                    switch (colBlack)
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

                    Console.WriteLine($"Game over! Black capture on {colB}{rowWhite}.");
                    return;
                }

                if (rowBlack == 7)
                {
                    char colB = 'a';
                    switch (colBlack)
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
