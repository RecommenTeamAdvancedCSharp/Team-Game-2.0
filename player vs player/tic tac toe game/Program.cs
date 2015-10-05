using System;
using System.Threading;

class TicTacToe
{
    static char[] position = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int playerTurn = 1;
    static int playerTurnChoise;
    static int computerChoise;
    static int winingCondition = 0;
    static string playerOneName, playerTurnTwoName;
    static bool isPlayerTurn = true;

    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Tic-Tac-Toe\n");
        Console.WriteLine("1 --- > Game Rules");
        Console.WriteLine("2 --- > Player vs Player");
        Console.WriteLine("3 --- > Player Vs Computer");

        ConsoleKeyInfo userInput = Console.ReadKey();

        if (userInput.Key == ConsoleKey.D1)
        {
            GameRules();
        }
        if (userInput.Key == ConsoleKey.D2)
        {
            PlayerVsPlayer();
        }
        if (userInput.Key == ConsoleKey.D3)
        {
            PlayerVsComputer();
        }
    }

    static void PlayerVsPlayer()
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter a name for Player 1: ");
            playerOneName = Console.ReadLine();
            Console.Write("Enter a name for Player 2: ");
            playerTurnTwoName = Console.ReadLine();

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(@"TIC-TAC-TOE GAME".PadLeft(36));
                Console.WriteLine("{0} (X)  -  {1} (O)", playerOneName.PadLeft(21), playerTurnTwoName);
                Console.WriteLine();

                if (playerTurn % 2 + 1 == 1)
                {
                    Console.WriteLine("On turn : {0}\n".PadLeft(35), playerTurnTwoName);
                }
                else
                {
                    Console.WriteLine("On turn : {0}\n".PadLeft(35), playerOneName);
                }


                Board();
                Console.Write("Selection : ");
                playerTurnChoise = int.Parse(Console.ReadLine());

                if (position[playerTurnChoise] != 'X' && position[playerTurnChoise] != 'O')
                {
                    if (playerTurn % 2 == 0)
                    {
                        position[playerTurnChoise] = 'O';
                        playerTurn++;
                    }
                    else
                    {
                        position[playerTurnChoise] = 'X';
                        playerTurn++;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}\n", playerTurnChoise, position[playerTurnChoise]);
                    Console.WriteLine("Please wait 2 second board is loading again.....");
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
                    Console.WriteLine("Winner : {0}", playerOneName);
                }
                else
                {
                    Console.WriteLine("Winner : {0}.", playerTurnTwoName);
                }

            }
            else
            {
                Console.WriteLine("Draw");
            }
            EndGame();

        }

        catch (Exception)
        {
            Console.Write("\nSomething went wrong. Do you want to play again ? : " + "(Y / N) ");
            string answer = Console.ReadLine();

            if (answer == "Y" || answer == "y")
            {
                Main();
            }
            else
            {
                Console.Clear();
            }
        }

    }
}