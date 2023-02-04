using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CreditCalculator
{
    internal class Handler
    {
        private const string what_do_you_want = "What do you want to calculate?\ntype \"n\" for number of monthly payments\ntype \"a\" for annuity monthly payment amount\ntype \"p\" for loan principal: ";
        private const string enter_loan_principal = "Enter the loan principal: ";
        private const string enter_monthly_payment = "Enter the monthly payment: ";
        private const string enter_interest = "Enter the interest: ";
        private const string enter_periods = "Enter perods: ";

        public static void Handl(string type)
        {
            switch (type)
            {
                case "annuity":
                    Annual_handler();
                    break;
                case "diff":
                    Differential_handler();
                    break;
            }
        }

        private static string User_Input()
        {
            while (true)
            {
                Console.Write(what_do_you_want);
                string userChoice = Console.ReadLine();
                if (userChoice != "a" && userChoice != "p" && userChoice != "n")
                {
                    Console.WriteLine("Incorrect!");
                    continue;
                }
                return userChoice;
            }
        }

        private static void Annual_handler()
        {
            switch (User_Input())
            {
                case "a":
                    AnnualCalc.Monthly_payment(Input_LoanPrincipal(), Input_Periods(), Input_Interest());
                    break;
                case "p":
                    AnnualCalc.LoanPrincipal(Input_MonthlyPayment(), Input_Periods(), Input_Interest());
                    break;
                case "n":
                    DifferentialCalc.Monthly_payment(Input_LoanPrincipal(), Input_MonthlyPayment(), Input_Interest());
                    break;
            }
        }
        
        private static void Differential_handler()
        {
            if (User_Input() != "a")
            {
                Console.WriteLine("In the differential loan could calculate only monthly payment!");
            }
            DifferentialCalc.Monthly_payment(Input_LoanPrincipal(), Input_Periods(), Input_Interest());
        }

        private static int Input_LoanPrincipal()
        {
            while (true)
            {
                Console.Write(enter_loan_principal);
                string userInput = Console.ReadLine();
                try
                {
                    int loan_principal;
                    Int32.TryParse(userInput, out loan_principal);
                    if (loan_principal > 0)
                    {
                        return loan_principal;
                    }
                }
                catch
                { 
                    Console.WriteLine("Incorrect!");
                }
            }
        }

        private static int Input_MonthlyPayment()
        {
            while (true)
            {
                Console.Write(enter_monthly_payment);
                string userInput = Console.ReadLine();
                try
                {
                    int monthly_payment;
                    Int32.TryParse(userInput, out monthly_payment);
                    if (monthly_payment > 0)
                    {
                        return monthly_payment;
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect!");
                }
            }
        }
        
        private static double Input_Interest()
        {
            while (true)
            {
                Console.Write(enter_interest);
                string userInput = Console.ReadLine();
                try
                {
                    double interest;
                    interest = double.Parse(userInput);
                    if (interest >=0)
                    {
                        return interest;
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect!");
                }
            }
        }
        
        private static int Input_Periods()
        {
            while (true)
            {
                Console.Write(enter_periods);
                string userInput = Console.ReadLine();
                try
                {
                    int periods;
                    Int32.TryParse(userInput, out periods);
                    if (periods > 0)
                    {
                        return periods;
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect!");
                }
            }
        }

        public static List<int> GetMonthlyPaymentsList(int monthlyPayment, int number)
        {
            List<int> MonthlyPaymentsList = new List<int>();
            for (int i = 0; i<number;  i++)
            {
                MonthlyPaymentsList.Add(monthlyPayment);
            }
            return MonthlyPaymentsList;
        }
    }
}
