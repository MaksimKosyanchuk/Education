
namespace CreditCalculator
{
    internal class AnnualCalc
    {
        public static void Monthly_payment(int loanPrincipal, int periods, double interest)
        {
            int monthlyPayment = LoanFormulas.Monthly_payment(loanPrincipal, periods, interest);
            int overPayment = Shower.Over_payment_calculate(loanPrincipal, Handler.GetMonthlyPaymentsList(monthlyPayment, periods));
            Console.WriteLine($"Your monthly payment is {monthlyPayment}");
            Shower.Show_over_payment(overPayment);
        }

        public static void LoanPrincipal(int monthlyPayment, int periods, double interest)
        {
            int loanPrincipal = LoanFormulas.Loan_principal(monthlyPayment, periods, interest);
            int overPayment = Shower.Over_payment_calculate(loanPrincipal, Handler.GetMonthlyPaymentsList(monthlyPayment, periods));
            Console.WriteLine($"Your loan principal is {loanPrincipal}");
            Shower.Show_over_payment(overPayment);
        }

        public static void Periods(int loanPrincipal, int monthlyPayment, double interest)
        {
            int periods = LoanFormulas.Periods(loanPrincipal, monthlyPayment, interest);
            int overPayment = Shower.Over_payment_calculate(loanPrincipal, Handler.GetMonthlyPaymentsList(monthlyPayment, periods));
            Console.WriteLine(Shower.Number_monthly_payment(periods));
            Shower.Show_over_payment(overPayment);
        }
    }
}
