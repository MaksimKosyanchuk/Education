using System;

namespace CreditCalculator
{
    public class LoanFormulas
    {
        public static int Loan_principal(int monthly, int periods, double interest)
        {
            double i = interest / 1200;
            int a = monthly;
            int n = periods;
            var p = Math.Floor(a / ( (i * Math.Pow(1 + i, n)) / (Math.Pow(1 + i, n) - 1)) );
            return (int)p;
        }

        public static int Monthly_payment(int loan_principal, int periods, double interest)
        {
            if (interest == 0) 
                return (int)Math.Floor((float)loan_principal / periods);  
            double i = interest / 1200;
            int p = loan_principal;
            int n = periods;
            return (int)Math.Ceiling(p * ((i * Math.Pow((1 + i), n)) / (Math.Pow((1 + i), n) - 1)));

        }
        
        public static int Monthly_payment(int loan_principal, int periods, double interest, int number)
        {
            double i = interest / 1200;
            int n = periods;
            int p = loan_principal;
            int m = number;
            return (int)Math.Ceiling((p / n) + (i * (p - ((p * (m - 1)) / n))));
        }

        public static int Periods(int loan_principal, int monthly, double interest)
        {
            if (interest == 0)
            {
                return (int)Math.Ceiling((float)loan_principal/monthly);
            }
            int p = loan_principal;
            int a = monthly;
            double i = interest/1200;
            return (int)Math.Ceiling(Math.Log(a / (a - i * p), 1+i));
        }

    }
}
