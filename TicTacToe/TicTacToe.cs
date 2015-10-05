﻿using System;

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
        BoardGame();
    }

    static void BoardGame()
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

    private static void EndGame()
    {

        Console.WriteLine("Do you want to play again? Enter button \"Y\" for yes and \"N\" for no :)");

        ConsoleKeyInfo endGameKey = Console.ReadKey();

        if (endGameKey.Key == ConsoleKey.Y)
        {
            Main();
        }
        if (endGameKey.Key == ConsoleKey.N)
        {
            System.Environment.Exit(0);
        }

    }

    static void PlayerVsComputer()
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
    }
}