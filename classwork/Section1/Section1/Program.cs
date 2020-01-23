/*
 * ITSE 1430
 * Zachary Behn
 */
using System;

namespace Section1
{
    class Program
    {
        static void Main ( string[] args )
        {
            //PlayingWithVariables();
            AddMovie();
            
        }

        static void AddMovie ()
        {
            string title = ReadString("Enter a title: ", true);

            int releaseYear = ReadInt32("Enter the release year (>=0): ", 0, 2100);

            int runLength = ReadInt32("Enter the run length (>=0): ", 0, 86400);

            string description = ReadString("Enter a description: " , false);

            Boolean isClassic = ReadBoolean("Is this a classic movie?");
        }

        static string ReadString (string message, Boolean isRequired)
        {
            Console.Write(message);
            string value = Console.ReadLine();

            //TODO: validate
            return value;
        }

        static bool ReadBoolean ( string message )
        {
            Console.Write(message + " (Y/N)");
            string value = Console.ReadLine();

            //TODO: Do correctly
            char firstChar = value[0];
            return firstChar == 'Y';
        }

        static int ReadInt32 (string message, int minValue, int maxValue)
        {
            Console.Write(message);
            string temp = Console.ReadLine();
            int value;
            if (Int32.TryParse(temp, out value))
                return value;
            
            //TODO: validate input
            return -1;
        }

        private static void PlayingWithVariables ()
        {
            Console.WriteLine("Hello World!");

            int hours = 5;
            double payRate;
            string name = "maaaaaaaaaaaaaaaaaaan";
            bool pass;

            //"Display Message"
            Console.WriteLine("Enter a value");
            string input = Console.ReadLine();
        }
    }
}