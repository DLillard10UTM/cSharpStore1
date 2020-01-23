//Author: Danny Lillard
//Date: 1/22/2020
//Description: A simple store to get aquantied with OOP and C#.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpStore
{
    public abstract class item
    {
        private string i_name;
        private int i_quanity;
        private double i_price;

        public string Name
        {
            get { return i_name; }
            set { i_name = value; }
        }
        public int Quanity
        {
            get { return i_quanity; }
            set { i_quanity = value; }
        }
        public double Price
        {
            get { return i_price; }
            set { i_price = value; }
        }
        public void sell(int sellNum)
        {
            i_quanity -= sellNum;
        }
        public void restock(int addNum)
        {
            i_quanity += addNum;
        }
        public void info()
        {
            Console.WriteLine("Item name: " + i_name);
            Console.WriteLine("Item quantity: " + i_quanity);
            Console.WriteLine("Item price: $" + i_price);
        }
    }
    public class book : item
    {
        public book(string n, int q, double p)
        {
            Name = n;
            Quanity = q;
            Price = p;
        }
    }
    public class fruit : item
    {
        public fruit(string n, int q, double p)
        {
            Name = n;
            Quanity = q;
            Price = p;
        }
    }
    public class baguette : item
    {
        public baguette(int q, double p)
        {
            Name = "baguette";
            Quanity = q;
            Price = p;
        }
        public int crunchiness()
        {
            Random rnd = new Random();
            int crunchness = rnd.Next(1, 10);
            return crunchness;
        }
    }
    class Store
    {
        static void Main(string[] args)
        {
            int menuChoice = 1;
            List<item> inventory = new List<item>();
            //Here are the default items.
            inventory.Add(new book("Design Patterns", 2, 32.19));
            inventory.Add(new book("Dune", 14, 12.19));

            inventory.Add(new fruit("apple", 71, 1.19));
            inventory.Add(new fruit("banana", 32, 0.67));
            inventory.Add(new baguette(200, 2.00));

            Console.WriteLine("Hello! Welcome to the C# Store! Simply press the number corresponding to your choice.");

            //MENU: Lets user add, sell, restock, and access information on inventory items.
            while (menuChoice != 5)
            {
                Console.WriteLine("1. Add a new item");
                Console.WriteLine("2. Sell an item");
                Console.WriteLine("3. Restock an item");
                Console.WriteLine("4. Request info on an item");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice now: ");
                menuChoice = Convert.ToInt32(Console.ReadLine());

                if (menuChoice == 1)
                {
                    Console.WriteLine("What kind of item are you adding?");
                    Console.WriteLine("1. Book");
                    Console.WriteLine("2. Fruit");
                    Console.Write("Enter choice now: ");
                    int menuChoice1 = Convert.ToInt32(Console.ReadLine());
                    if (menuChoice1 == 1)
                    {
                        Console.Write("Enter the book title: ");
                        string newName = Console.ReadLine();

                        Console.Write("Enter the quantity of " + newName + ": ");
                        int newQuant = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter the price for " + newName + ": ");
                        double newPrice = Convert.ToDouble(Console.ReadLine());

                        inventory.Add(new book(newName, newQuant, newPrice));
                        Console.WriteLine("New book " + newName + " has been added.");
                    }
                    if (menuChoice1 == 2)
                    {
                        Console.Write("Enter the fruit name: ");
                        string newName = Console.ReadLine();

                        Console.Write("Enter the quantity of " + newName + ": ");
                        int newQuant = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter the price for " + newName + ": ");
                        double newPrice = Convert.ToDouble(Console.ReadLine());

                        inventory.Add(new fruit(newName, newQuant, newPrice));
                        Console.WriteLine("New fruit " + newName + " has been added.");
                    }
                }
                if (menuChoice == 2)
                {
                    Console.WriteLine("What is the name of the item being sold?");
                    Console.Write("Enter choice now: ");
                    string itemName = Console.ReadLine();
                    Console.Write("How many " + itemName + "(s) are being sold: ");
                    int sellNum = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        if (inventory[i].Name == itemName)
                        {
                            if (itemName == "baguette")
                            {
                                if (sellNum > 1)
                                {
                                    Console.WriteLine("La baguette is a French piece of arte, you cannot buy more than one.");
                                    Console.WriteLine("Changing the number being sold to one...");
                                    sellNum = 1;
                                }
                                //Cannot access baguette functionality from the list.
                                baguette testBagu = new baguette(1, 0);
                                Console.WriteLine("Would you like me(the cashier) to test the crunchiness of the baguette?");
                                Console.WriteLine("1. Yes");
                                Console.WriteLine("2. Please do not eat my bread.");
                                Console.Write("Enter choice now: ");
                                int baguetteChoice = Convert.ToInt32(Console.ReadLine());
                                if (baguetteChoice == 1)
                                {
                                    Console.WriteLine("The cashier (Mike) takes a bite of the baguette...");
                                    int cronch = testBagu.crunchiness();
                                    if (cronch <= 2)
                                        Console.WriteLine("There is no audible crunch, the baguette is not crunchy.");
                                    else
                                        Console.WriteLine("There is a crunch! the baguette is good!");
                                    Console.WriteLine("Mike notices how weird this is and wishes it wasn't a part of his job, he throws away the baguette.");
                                    
                                }
                                else
                                {
                                    inventory[i].sell(sellNum);
                                }
                            }
                            if (inventory[i].Quanity >= sellNum)
                            {
                                inventory[i].sell(sellNum);
                                Console.WriteLine(sellNum + " of " + inventory[i].Name + " has been sold at price $" + sellNum * inventory[i].Price);
                            }
                            else
                                Console.WriteLine("ERROR: SELL REQUEST IS GREATER THAN QUANTITY");
                        }
                    }
                }
                if (menuChoice == 3)
                {
                    Console.WriteLine("What is the name of the item being restocked?");
                    Console.Write("Enter choice now: ");
                    string itemName = Console.ReadLine();
                    Console.Write("How many " + itemName + "(s) are being restocked: ");
                    int restockNum = Convert.ToInt32(Console.ReadLine());

                    if (restockNum > 0)
                    {
                        for (int i = 0; i < inventory.Count; i++)
                        {
                            if (inventory[i].Name == itemName)
                            {
                                inventory[i].restock(restockNum);
                                Console.WriteLine(restockNum + " " + itemName + "(s) has been added to inventory.");
                            }
                        }
                    }
                    else
                        Console.WriteLine("ERROR: RESTOCK NUM MUST BE LARGER THAN 0, SIMPLY SELL OR DO NOTHING");
                }
                if (menuChoice == 4)
                {
                    Console.WriteLine("What is the name of the item being searched for?");
                    Console.Write("Enter choice now: ");
                    string itemName = Console.ReadLine();
                    bool itemExist = false;
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        if (inventory[i].Name == itemName)
                        {
                            inventory[i].info();
                            itemExist = true;
                        }
                    }
                    if (!itemExist)
                    {
                        Console.WriteLine("ERROR: ITEM SEARCHED FOR DOES NOT EXIST");
                    }
                }
            }
        }
    }
}


