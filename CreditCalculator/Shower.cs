using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCalculator
{
    public class Shower
    {
        public static string Number_monthly_payment(int number)
        {
            if (number % 12 == 0)
            {
                number /= 12;
                return $"It will take {number} years to repay this loan!";
            }
            else
            {
                int number_of_years = (int)number/12 - number % 12;
                int number_of_months = number % 12;
                return $"It will take {number_of_years} years and {number_of_months} months to repay this loan!";
            }
        }

        public static int Over_payment_calculate(int loan_principal, List<int>monthly_payments)
        {
            int sum = 0;
            foreach(int element in monthly_payments)
            {
                sum += element;
            }
            return sum - loan_principal;
        }

        public static void Show_over_payment(int over_payment)
        {
            Console.WriteLine($"Your overpayment = {over_payment} \n");
        }
    }
}
