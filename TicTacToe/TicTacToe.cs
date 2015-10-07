using System;
using System.Threading;

class TicTacToe
{
    static char[] position = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int playerTurn = 1;
    static int playerChoise;
    static int computerChoise;
    static int winingCondition = 0;
    static string firstPlayerName, secondPlayerName;
    static bool isPlayerOnTurn = true;
    static ConsoleKeyInfo userInput;
    int name = int.Parse(Console.ReadLine());


    static void Main()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.Clear();
        Console.WriteLine("|..Tic-Tac-Toe..|\n".PadLeft(22));
        Console.WriteLine("Press \"1\" for Game Rules.\n");
        Console.WriteLine("Press \"2\" to Start the Game.\n");
        Console.WriteLine("Press 'Q' to Quit the Game.");
        Console.CursorVisible = false;

        userInput = Console.ReadKey();

        if (userInput.Key == ConsoleKey.D1)
        {
            GameRules();
        }
        if (userInput.Key == ConsoleKey.D2)
        {
            Console.Clear();
            Console.WriteLine("|..Game Modes..|\n".PadLeft(22));
            Console.WriteLine("Press \"1\" for PlayerVsPlayer mode.\n");
            Console.WriteLine("Press \"2\" for PlayerVsComputer mode.\n\n");
            Console.WriteLine("Press 'Q' to quit the game.");

            userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.D1)
            {
                PlayerVsPlayer();
            }
            if (userInput.Key == ConsoleKey.D2)
            {
                PlayerVsComputer();
            }
            else if (userInput.Key == ConsoleKey.Q)
            {
                Console.Clear();
                Environment.Exit(0);
            }
            else
            {

                Main();
            }
        }
        if (userInput.Key == ConsoleKey.D3)
        {
            PlayerVsComputer();
        }
        if (userInput.Key == ConsoleKey.Q)
        {
            Console.Clear();
            Environment.Exit(0);
        }

    }

    static void PlayerVsPlayer()
    {
        try
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.Clear();
            Console.Write("Enter a name for Player 1 : ");
            firstPlayerName = Console.ReadLine();
            Console.Write("Enter a name for Player 2 : ");
            secondPlayerName = Console.ReadLine();

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(@"TIC-TAC-TOE GAME".PadLeft(36));
                Console.WriteLine("{0} (X)  -  {1} (O)", firstPlayerName.PadLeft(21), secondPlayerName);
                Console.WriteLine();

                if (playerTurn % 2 + 1 == 1)
                {
                    Console.WriteLine("On turn : {0}\n".PadLeft(35), secondPlayerName);
                }
                else
                {
                    Console.WriteLine("On turn : {0}\n".PadLeft(35), firstPlayerName);
                }


                Board();
                Console.WriteLine();
                Console.Write("Selection : ".PadLeft(33));
                playerChoise = int.Parse(Console.ReadLine());

                if (position[playerChoise] != 'X' && position[playerChoise] != 'O')
                {
                    if (playerTurn % 2 == 0)
                    {
                        position[playerChoise] = 'O';
                        playerTurn++;
                    }
                    else
                    {
                        position[playerChoise] = 'X';
                        playerTurn++;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}\n", playerChoise, position[playerChoise]);
                    Console.WriteLine("Please wait 2 seconds board is loading again.....");
                    Thread.Sleep(2000);
                }

                winingCondition = CheckWin();
            }

            while (winingCondition != 1 && winingCondition != -1);

            Console.Clear();
            Board();

            if (winingCondition == 1)
            {

                if (playerTurn % 2 + 1 == 1)
                {
                    Console.WriteLine("Winner : {0}\n".PadLeft(34), firstPlayerName);
                }
                else
                {
                    Console.WriteLine("Winner : {0}\n.".PadLeft(34), secondPlayerName);
                }

            }
            else
            {
                Console.WriteLine("Draw\n".PadLeft(28));
            }
            EndGame();

        }

        catch (Exception)
        {
            Console.WriteLine("Invalid input.");
            Console.WriteLine("Please wait 2 seconds board is loading again.....");
            Thread.Sleep(2000);
        }

    }

    static void Board()
    {
        Console.WriteLine(" *-----*-----*-----*".PadLeft(37));
        Console.WriteLine(" |     |     |     |".PadLeft(37));
        Console.WriteLine(" |  {0}  |  {1}  |  {2}  |".PadLeft(43), position[1], position[2], position[3]);
        Console.WriteLine(" |     |     |     |".PadLeft(37));
        Console.WriteLine("*-----*-----*-----*".PadLeft(37));
        Console.WriteLine(" |     |     |     |".PadLeft(37));
        Console.WriteLine(" |  {0}  |  {1}  |  {2}  |".PadLeft(43), position[4], position[5], position[6]);
        Console.WriteLine(" |     |     |     |".PadLeft(37));
        Console.WriteLine("*-----*-----*-----*".PadLeft(37));
        Console.WriteLine(" |     |     |     |".PadLeft(37));
        Console.WriteLine(" |  {0}  |  {1}  |  {2}  |".PadLeft(43), position[7], position[8], position[9]);
        Console.WriteLine(" |     |     |     |".PadLeft(37));
        Console.WriteLine("*-----*-----*-----*".PadLeft(37));
    }

    static int CheckWin()
    {
        // Horizontal.
        if (position[1] == position[2] && position[2] == position[3])
        {
            return 1;
        }
        else if (position[4] == position[5] && position[5] == position[6])
        {
            return 1;
        }
        else if (position[7] == position[8] && position[8] == position[9])
        {
            return 1;
        }
        // ..

        // Vertical.     
        else if (position[1] == position[4] && position[4] == position[7])
        {
            return 1;
        }
        else if (position[2] == position[5] && position[5] == position[8])
        {
            return 1;
        }
        else if (position[3] == position[6] && position[6] == position[9])
        {
            return 1;
        }
        // ..

        // Diagonal.
        else if (position[1] == position[5] && position[5] == position[9])
        {
            return 1;
        }
        else if (position[3] == position[5] && position[5] == position[7])
        {
            return 1;
        }
        // ..

        // Check for Draw.
        else if (position[1] != '1' && position[2] != '2' && position[3] != '3' && position[4] != '4' && position[5] != '5' && position[6] != '6' && position[7] != '7' && position[8] != '8' && position[9] != '9')
        {
            return -1;
        }

        else
        {
            return 0;
        }
        //..
    }

    static void GameRules()
    {
        Console.Clear();
        Console.WriteLine("|..Game Rules..|\n".PadLeft(45));
        Console.WriteLine("1. Traditionally the first playerTurn plays with \"X\". So you can decide who wants to go \"X\" and who wants go with \"O\".\n");
        Console.WriteLine("2. Only one playerTurn can play at a time.\n");
        Console.WriteLine("3. If any of the playerTurns have filled a square then the other playerTurn and the same playerTurn cannot override that square.\n ");
        Console.WriteLine("4. There are only two conditions that may be match will be draw or may be win.\n ");
        Console.WriteLine("5. The playerTurn that succeeds in placing three respective mark (X or O) in a horizontal, vertical or diagonal row wins the game.\n");

        Console.WriteLine("Press BACKSPACE to go back.\n");

        ConsoleKeyInfo userInput = Console.ReadKey();

        if (userInput.Key == ConsoleKey.Backspace)
        {
            Main();
        }
    }

    static void PlayerVsComputer()
    {
        try
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.Clear();
            Console.Write("Enter name for Player : ");
            firstPlayerName = Console.ReadLine();

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(@"TIC-TAC-TOE GAME".PadLeft(36));
                Console.WriteLine("{0} (X)  -  Computer (O)", firstPlayerName.PadLeft(20));
                Console.WriteLine();

                if (isPlayerOnTurn)
                {
                    Console.WriteLine("On turn : {0}\n".PadLeft(35), firstPlayerName);
                }
                else
                {
                    Console.WriteLine("On turn : Computer\n".PadLeft(37));
                }

                Board();
                Console.Write("Selection : ".PadLeft(33));
                Random r = new Random();
                int computerNumber = r.Next(1, 9);

                if (isPlayerOnTurn)
                {
                    playerChoise = int.Parse(Console.ReadLine());

                    if (position[playerChoise] != 'X' && position[playerChoise] != 'O')
                    {
                        position[playerChoise] = 'X';
                        isPlayerOnTurn = false;
                    }
                    else
                    {
                        Console.WriteLine("Sorry the box {0} is already marked with {1}\n", playerChoise, position[playerChoise]);
                        Console.WriteLine("Please wait 2 seconds. Board is loading again...");
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    computerChoise = computerNumber;

                    if (position[computerChoise] != 'X' && position[computerChoise] != 'O')
                    {
                        Thread.Sleep(2000);
                        position[computerChoise] = 'O';
                        isPlayerOnTurn = true;
                    }
                }

                winingCondition = CheckWin();
            }

            while (winingCondition != 1 && winingCondition != -1);

            Console.Clear();
            Board();

            if (winingCondition == 1)
            {
                Console.WriteLine("Winner : {0}\n".PadLeft(35), firstPlayerName);
            }
            else
            {
                Console.WriteLine("Draw\n".PadLeft(27));
            }

            EndGame();

        }

        catch (Exception)
        {
            Console.WriteLine("Invalid input.");
            Console.WriteLine("Loading ...");
            Thread.Sleep(2000);
            ResetPositions();
            PlayerVsComputer();
        }
    }

    static void EndGame()
    {

        Console.Write("Do you want to play again? Enter \"Y\" for YES and \"N\" for NO.");

        ConsoleKeyInfo endGameKey = Console.ReadKey();

        if (endGameKey.Key == ConsoleKey.Y)
        {
            ResetPositions();
            Main();
        }
        if (endGameKey.Key == ConsoleKey.N)
        {
            System.Environment.Exit(0);
        }


    }

    static void ResetPositions()
    {
        position[0] = '0';
        position[1] = '1';
        position[2] = '2';
        position[3] = '3';
        position[4] = '4';
        position[5] = '5';
        position[6] = '6';
        position[7] = '7';
        position[8] = '8';
        position[9] = '9';
    }

}

