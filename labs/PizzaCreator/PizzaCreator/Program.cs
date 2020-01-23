/*
 * ITSE 1430
 * Spring 2020
 * Zachary Behn
 */

using System;

namespace PizzaCreator
{
    class Program
    {
        static void Main ( string[] args )
        {
            Console.WriteLine("ITSE 1430\n" +
                "Spring 2020\n" +
                "Zachary Behn\n");
            printMenu();
            string s = Console.ReadLine();
            Console.WriteLine(s);
        }

        static void printMenu()
        {
            Console.Write("1. Create Order\n" +
                "2. View Order\n" +
                "3. Order Food\n" +
                "\n Please Enter a value 1 through 3__");
        }
    }
}
