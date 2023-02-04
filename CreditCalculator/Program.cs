using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CreditCalculator
{
    internal class Program
    {
        private const string what_type_do_you_want = "What is type of loan do you want to calculate?\ntype \"a\" for annuity\ntype \"d\" for differential\ntype\"exit\" for exit: ";
        
        static void Main()
        {
            User_input();
            Console.WriteLine("Bye");
        }
        
        public static void User_input()
        {
            while (true)
            {
                Console.Write(what_type_do_you_want);
                string userChoice = Console.ReadLine();
                switch (userChoice.ToLower())
                {
                    case "a":
                        Handler.Handl("annuity");
                        break;
                    case "d":
                        Handler.Handl("diff");
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Incorrect!");
                        continue;
                }
            }
        }
    }
}
