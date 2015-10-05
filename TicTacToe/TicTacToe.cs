using System;

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
}
