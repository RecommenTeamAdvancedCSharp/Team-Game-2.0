using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardSoftUniProjectConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] position = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            // static void Board()
   // {
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
 
 
    //}
        }
    }
}
