using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine;

namespace CoffeeMachine
{
    internal class Program
    {
        private static CoffeeMachine coffeemachine = new CoffeeMachine();

        public static Coffee Espresso = new Coffee(250, 0, 16, 1, 4);
        public static Coffee Latte = new Coffee(350, 75, 20, 1, 7);
        public static Coffee Cappuccino = new Coffee(200, 100, 12, 1, 6);

        private const string WriteAction = "Write action(buy, fill, take, remaining, exit): ";
        private const string WhatCoffee = "What do you want to buy? 1 - espresso, 2 - latte, 3 - cappuccino, back – to main menu: ";

        static void Main(string[] args)
        {
            Console.WriteLine("Coffee Machine by Maks");
            GamePay();
        }

        private static void GamePay()
        {
            while (true)
            {
                Console.WriteLine(WriteAction);
                string UserChoice = Console.ReadLine();
                switch (UserChoice.ToLower())
                {
                    case "buy":
                        Buy();
                        break;
                    case "fill":
                        Fill();
                        break;
                    case "take":
                        Take();
                        break;
                    case "remaining":
                        Remaining();
                        break;
                    case "exit":
                        return;
                }
            }
        }

        private static void Remaining()
        {
            string Text = "Coffee Machine has: \n";
            Text += $"{coffeemachine.Water} of water\n";
            Text += $"{coffeemachine.Milk} of milk\n";
            Text += $"{coffeemachine.Beans} of beans\n";
            Text += $"{coffeemachine.Cups} of cups\n";
            Text += $"{coffeemachine.Money} of money\n";

            Console.Write(Text);
        }

        private static void Buy()
        {
            bool iterator = true;
            Coffee CurrentCoffee = new Coffee(0, 0, 0, 0, 0);
            while (iterator)
            {
                Console.Write(WhatCoffee);
                string coffee = Console.ReadLine();
                switch (coffee)
                {
                    case "1":
                        CurrentCoffee = Espresso;
                        iterator = false;
                        break;
                    case "2":
                        CurrentCoffee = Latte;
                        iterator = false;
                        break;
                    case "3":
                        CurrentCoffee = Cappuccino;
                        iterator = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестный номер!");
                        break;
                }
            }

            if (CurrentCoffee.Water > coffeemachine.Water)
            {
                Console.WriteLine("Недостаточно воды!");
                return;
            }
            if (CurrentCoffee.Milk > coffeemachine.Milk)
            {
                Console.WriteLine("Недостаточно молока!");
                return;
            }
            if (CurrentCoffee.Beans > coffeemachine.Beans)
            {
                Console.WriteLine("Недостаточно бобов!");
                return;
            }
            if (CurrentCoffee.Cups > coffeemachine.Cups)
            {
                Console.WriteLine("Недостаточно стаканчиков!");
                return;
            }

            Console.WriteLine($"Окей, готовлю!");

            coffeemachine.Water -= CurrentCoffee.Water;
            coffeemachine.Milk -= CurrentCoffee.Milk;
            coffeemachine.Beans -= CurrentCoffee.Beans;
            coffeemachine.Cups -= CurrentCoffee.Cups;
            coffeemachine.Money += CurrentCoffee.Money;
        }

        private static void Fill()
        {
            int water;
            int milk;
            int beans;
            int cups;
            while (true)
            {
                try
                {
                    Console.WriteLine("Write how many ml of water you want to add:");
                    string _water = Console.ReadLine();
                    water = Int32.Parse(_water);
                    Console.WriteLine("Write how many ml of milk you want to add:");
                    string _milk = Console.ReadLine();
                    milk = Int32.Parse(_milk);
                    Console.WriteLine("Write how many ml of beans you want to add:");
                    string _beans = Console.ReadLine();
                    beans = Int32.Parse(_beans);
                    Console.WriteLine("Write how many ml of cups you want to add:");
                    string _cups = Console.ReadLine();
                    cups = Int32.Parse(_cups);
                }
                catch
                {
                    Console.WriteLine("You must enter an integer!");
                    continue;
                }

                if (water <= 0 && milk <= 0 && beans <= 0 && cups <= 0)
                {
                    Console.WriteLine("Number should be more than 0!");
                    continue;
                }
                else
                {
                    coffeemachine.Water += water;
                    coffeemachine.Milk += milk;
                    coffeemachine.Beans += beans;
                    coffeemachine.Cups += cups;
                    break;
                }
            }
        }

        private static void Take()
        {
            if (coffeemachine.Money == 0)
            {
                Console.WriteLine("Coffee Machine has 0$");
            }
            else
            {
                coffeemachine.Money = 0;
            }
        }
    }
}
