﻿using CheckoutLibrary;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"A", 30},
            {"B", 20},
            {"C", 50},
            {"D", 30},
            {"E", 100},
            {"F", 120},
            {"G", 40},
            {"H", 40},
            {"I", 70},
            {"J", 80},
            {"K", 50},
            {"L", 20},
            {"M", 10},
            {"N", 80},
            {"O", 50},
            {"P", 90},
            {"Q", 110},
            {"R", 70},
            {"S", 200},
            {"T", 230},
            {"U", 10},
            {"V", 40},
            {"W", 60},
            {"X", 90},
            {"Y", 70},
            {"Z", 30}
        };
        Dictionary<string, Dictionary<string, int>> specialPrices = new Dictionary<string, Dictionary<string, int>>()
        {
            {"A", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 20},
                }
            },
            {"B", new Dictionary<string, int>
                {
                   {"quantity", 2}, 
                   {"price", 20},
                }
            },
            {"C", new Dictionary<string, int>
                {
                   {"quantity", 4}, 
                   {"price", 150},
                }
            },
            {"F", new Dictionary<string, int>
                {
                   {"quantity", 3}, 
                   {"price", 300},
                }
            },
            {"G", new Dictionary<string, int>
                {
                   {"quantity", 2}, 
                   {"price", 60},
                }
            },
            {"N", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 40},
                }
            },
            {"O", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 25},
                }
            },
            {"P", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 45},
                }
            },
            {"Q", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 55},
                }
            },
            {"R", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 35},
                }
            },
            {"S", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 100},
                }
            },
            {"T", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 115},
                }
            }
        };
        int bagPrice = 5;
        int bagCarryCapacity = 5;
        Checkout checkout = new Checkout(prices, specialPrices, bagPrice, bagCarryCapacity);
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
        Console.WriteLine("*                                                                 *");
        Console.WriteLine("*                      Welcome To Checkout!                       *");
        Console.WriteLine("*                                                                 *");
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Please scan your items by entering a single lettter... ");
        Console.WriteLine("and then pressing enter (enter only single capital letters)");
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("When you are finished scanning your items, just press Enter");
        Console.WriteLine(Environment.NewLine);

        do
        {
            string ?item = Console.ReadLine();
            if(string.IsNullOrEmpty(item))
            {
                break;
            }
            checkout.Scan(item);
        }while(true);
        string formattedString = String.Format("*           Your total is: {0}           You saved: {1}            *", checkout.GetTotalPrice(), checkout.Savings);
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
        Console.WriteLine("*                                                                 *");
        Console.WriteLine("*                  Thank You For Using Checkout                   *");
        Console.WriteLine("*                                                                 *");
        Console.WriteLine(formattedString);
        Console.WriteLine("*                                                                 *");
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
    }
}
