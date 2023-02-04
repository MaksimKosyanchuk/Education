
namespace CreditCalculator
{
    internal class DifferentialCalc
    {
        public static void Monthly_payment(int loanPrincipal, int periods, double interest)
        {
            List<int> monthlyPayments = new List<int>();
            for (int i = 1; i < periods+1; i++ )
            {
                int payment = LoanFormulas.Monthly_payment(loanPrincipal, periods, interest, i);
                monthlyPayments.Add(payment);
                Console.WriteLine($"Month {i}: payment is {payment}");
            }
            int overPayment = Shower.Over_payment_calculate(loanPrincipal, monthlyPayments);
            Shower.Show_over_payment(overPayment);
        }
    }
}
