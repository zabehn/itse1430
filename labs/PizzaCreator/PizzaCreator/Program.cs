/*
 * ITSE 1430
 * Lab 1
 * PizzaCreator
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
                "PizzaCreator\n" +
                "Spring 2020\n" +
                "Zachary Behn\n");

            var done = false;
            do
            {
                switch(printMenu())
                {
                    case Command.Create:
                        checkOrder();break;
                    case Command.View:
                        viewOrder();break;
                    case Command.Modify:
                        modifyOrder();break;
                    case Command.Quit:
                        done = confirmQuit();break;
                }
            } while (!done);
        }

        private static void checkOrder ()
        {
            if (!String.IsNullOrEmpty(size))
            {
                do
                {
                    Console.WriteLine("You have an order do you want to continue? It will erase your progress Y/N");
                    var input = Console.ReadLine();

                    switch(input.ToLower())
                    {
                        case "y":
                            createOrder();break;
                        case "n":
                            return;
                        default: Console.WriteLine("invalid option, try again");break;
                    }
                } while (true);
            }
            else
            {
                createOrder();
            }
        }

        private static bool confirmQuit ()
        {
            do
            {
                Console.WriteLine("are you sure you want to quit? Y/N");
                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    default:
                        Console.WriteLine("Invalid response");break;
                }
            } while (true);
            
        }

        private static void modifyOrder ()
        {
            Console.WriteLine("viewing price\npress any key to continue");
            Console.ReadLine();
        }

        private static void viewOrder ()
        {
            Console.WriteLine("Order Summary");
            Console.WriteLine($"{size} Pizza:"+ $"${sizePrice}".PadLeft(20));
            Console.WriteLine($"{sauce} Sauce" + ((sauce == "Traditional")? "$0".PadLeft(20) : "$1".PadLeft(20)));
            Console.WriteLine(extraCheese? "Extra Cheese:"+"$1.25".PadLeft(20) : "Normal Cheese:"+"$0".PadLeft(20));
            Console.WriteLine("Meats");
            foreach (string s in meats)
            {
                if(!String.IsNullOrEmpty(s))
                {
                    Console.WriteLine($"\t{s}:"+"$0.75".PadLeft(20));
                }
            }
            Console.WriteLine("Vegetables");
            foreach (string s in vegetables)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    Console.WriteLine($"\t{s}:"+"$0.50".PadLeft(20));
                }
            }
            Console.WriteLine(isDelivery? "Delivery:"+"$2.50".PadLeft(20) : "Take Out:" + "$0".PadLeft(20));
            Console.WriteLine("Total:" + $"${price}".PadLeft(20));
            Console.WriteLine("press the enter key to continue");
            Console.WriteLine();
            Console.ReadLine();
        }

        static string size, sauce;
        static bool extraCheese, isDelivery;
        static string[] meats, vegetables;
        static double price, sizePrice;

        private static void createOrder ()
        {
            price = 0;
            
            Console.WriteLine("\ncreating order");
            size = pickSize();
            sauce = pickSauce();
            extraCheese = pickCheese();
            meats = pickMeats();
            vegetables = pickVegetables();
            isDelivery = pickMethodOfDelivery();  
        }

        private static bool pickMethodOfDelivery ()
        {
            do
            {
                Console.WriteLine("Please pick one, Delivery or Take Out");
                Console.WriteLine("D. Delivery ($2.50)");
                Console.WriteLine("T. Take Out ($0)");

                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "d":
                    price += 2.50;
                    return true;
                    case "t":
                    return false;
                    default: Console.WriteLine("Invalid option, try again"); break;
                }
            } while (true);
        }

        private static string[] pickVegetables ()
        {
                bool[] selectedVegetables = new bool[4];
                vegetables = new string[4];
            do
            {
                Console.WriteLine("Please pick or deselect Vegetables or select Done, ($.50 each)");
                Console.WriteLine("B. Black Olives");
                Console.WriteLine("M. Mushrooms");
                Console.WriteLine("O. Onions");
                Console.WriteLine("P. Peppers");
                Console.WriteLine("D. Done");

                printArray(vegetables);

                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "b":
                        if(!selectedVegetables[0])
                        {
                            vegetables[0] = "Black Olives";
                            price += .50;
                            selectedVegetables[0] = true;
                        }
                        else
                        {
                            vegetables[0] = "";
                            price -= .50;
                            selectedVegetables[0] = false;
                        }
                        break;
                    case "m":
                        if (!selectedVegetables[1])
                        {
                            vegetables[1] = "Mushrooms";
                            price += .50;
                            selectedVegetables[1] = true;
                        } else
                        {
                            vegetables[1] = "";
                            price -= .50;
                            selectedVegetables[1] = false;
                        }
                        break;
                    case "o":
                        if (!selectedVegetables[2])
                        {
                            vegetables[2] = "Onions";
                            price += .50;
                            selectedVegetables[2] = true;
                        }
                        else
                        {
                            vegetables[2] = "";
                            price -= .50;
                            selectedVegetables[2] = false;
                        }
                        break;
                    case "p":
                        if (!selectedVegetables[3])
                        {
                            vegetables[3] = "Peppers";
                            price += .50;
                            selectedVegetables[3] = true;
                        }
                        else
                        {
                            vegetables[3] = "";
                            price -= .50;
                            selectedVegetables[3] = false;
                        }
                        break;
                    case "d":
                        return vegetables;
                    default: Console.WriteLine("Invalid option, try again"); break;
                }
            } while (true);
        }

        private static bool pickCheese ()
        {
            do
            {
                Console.WriteLine("Please pick one Cheese option");
                Console.WriteLine("E. Extra ($1.25)");
                Console.WriteLine("N. Normal ($0)");

                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "e":
                        price += 1.25;
                        return true;
                    case "n":
                        return false;
                    default: Console.WriteLine("Invalid option, try again"); break;
                }
            } while (true);
        }

        private static string[] pickMeats ()
        {
            bool[] selectedMeats = new bool[4];
            meats = new string[4];

            do
            {
                Console.WriteLine("Please pick or deselect Vegetables or select Done, ($.75 each)");
                Console.WriteLine("B. Bacon");
                Console.WriteLine("H. Ham");
                Console.WriteLine("S. Sausage");
                Console.WriteLine("P. Pepperoni");
                Console.WriteLine("D. Done");

                printArray(meats);

                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "b":
                    if (!selectedMeats[0])
                    {
                        meats[0] = "Bacon";
                        price += .75;
                        selectedMeats[0] = true;
                    } else
                    {
                        meats[0] = "";
                        price -= .75;
                        selectedMeats[0] = false;
                    }
                    break;
                    case "h":
                    if (!selectedMeats[1])
                    {
                        meats[1] = "Ham";
                        price += .75;
                        selectedMeats[1] = true;
                    } else
                    {
                        meats[1] = "";
                        price -= .75;
                        selectedMeats[1] = false;
                    }
                    break;
                    case "s":
                    if (!selectedMeats[2])
                    {
                        meats[2] = "Sausage";
                        price += .75;
                        selectedMeats[2] = true;
                    } else
                    {
                        meats[2] = "";
                        price -= .75;
                        selectedMeats[2] = false;
                    }
                    break;
                    case "p":
                    if (!selectedMeats[3])
                    {
                        meats[3] = "Pepperoni";
                        price += .75;
                        selectedMeats[3] = true;
                    } else
                    {
                        meats[3] = "";
                        price -= .75;
                        selectedMeats[3] = false;
                    }
                    break;
                    case "d":
                    return meats;
                    default: Console.WriteLine("Invalid option, try again"); break;
                }
            } while (true);
        }

        private static void printArray ( string[] array )
        {
            Console.WriteLine();
            foreach (string s in array)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    Console.Write(s+",");
                }
            }
        }

        private static string pickSauce ()
        {
            do
            {
                Console.WriteLine("Please pick one Sauce option");
                Console.WriteLine("T. Traditional ($0)");
                Console.WriteLine("G. Garlic ($1)");
                Console.WriteLine("O. Oregano ($1)");

                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "t":
                        return "Traditional";
                    case "g":
                        price += 1;
                        return "Garlic";
                    case "o":
                        price += 1;
                        return "Oregano";
                    default: Console.WriteLine("Invalid option, try again"); break;
                }
            } while (true);
        }

        private static string pickSize ()
        {
            do
            {
                Console.WriteLine("Please pick one Crust option");
                Console.WriteLine("L. Large ($8.75)");
                Console.WriteLine("M. Medium ($6.25)");
                Console.WriteLine("S. Small ($5)");

                var input = Console.ReadLine();
                switch(input.ToLower())
                {
                    case "l":
                        price += 8.75;
                        sizePrice = 8.75;
                        return "Large";
                    case "m":
                        price += 6.25;
                        sizePrice = 6.75;
                        return "Medium";
                    case "s":
                        price += 5;
                        sizePrice = 5;
                        return "Small";
                    default:Console.WriteLine("Invalid option, try again");break;
                }
            } while (true);
        }

        enum Command
        {
            Quit = 0,
            Create = 1,
            View = 2,
            Modify = 3,
        }

        static Command printMenu()
        {
            do
            {
                Console.WriteLine("C. Create Order\n" +
                    "V. View Order\n" +
                    "M. Modify Order\n" +
                    "Q. Quit\n" + "please enter a valid response ");

                var input = Console.ReadLine();
                switch(input.ToLower())
                {
                    case "c":
                        return Command.Create;
                    case "v":
                        return Command.View;
                    case "m":
                        return Command.Modify;
                    case "q":
                        return Command.Quit;
                    default: 
                        Console.WriteLine("Invalid response, please try again.");break;
                }
            } while (true);
        }
    }
}
