namespace CleanCode.SwitchStatement;

public class MonthlyTransactions
{
    public MonthlyTransactions(Customer customer, decimal payOutAmount, decimal payInAmount)
    {
        Customer = customer;
        PayOutAmount = payOutAmount;
        PayInAmount = payInAmount;
    }

    public Customer Customer { get; set; }
    public decimal PayOutAmount { get; set; }
    public decimal PayInAmount { get; set; }
}