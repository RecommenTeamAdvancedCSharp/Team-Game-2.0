using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerVsComputer
{

    class Program
    {
        static char[] position = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int playerTurn = 1;
        static int playerTurnChoise;
        static int computerChoise;
        static int winingCondition = 0;
        static string firstPlayerName, secondPlayerName;
        static bool isPlayerTurn = true;
        static ConsoleKeyInfo userInput;
        int name = int.Parse(Console.ReadLine());

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

                    if (isPlayerTurn)
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

                    if (isPlayerTurn)
                    {
                        playerTurnChoise = int.Parse(Console.ReadLine());

                        if (position[playerTurnChoise] != 'X' && position[playerTurnChoise] != 'O')
                        {
                            position[playerTurnChoise] = 'X';
                            isPlayerTurn = false;
                        }
                        else
                        {
                            Console.WriteLine("Sorry the box {0} is already marked with {1}\n", playerTurnChoise, position[playerTurnChoise]);
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
                            isPlayerTurn = true;
                        }
                    }

                    winingCondition = CheckWin();
                }

                while (winingCondition != 1 && winingCondition != -1);

                Console.Clear();
                Board();

                if (winingCondition == 1)
                {
                    Console.WriteLine("Winner : \n".PadLeft(35), (playerTurn % 2) + 1);
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
                Console.WriteLine("Please wait 2 seconds board is loading again.....");
                Thread.Sleep(2000);
            }
        }
    }
}
