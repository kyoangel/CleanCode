namespace CleanCode.SwitchStatement;

public class StatementDetail
{
    public decimal AdminFee { get; set; }

    public decimal PayOutFee { get; set; }

    public decimal PayInFee { get; set; }

    public void Generate(MonthlyTransactions monthlyTransactions)
    {
        var customerType = monthlyTransactions.Customer.Type;

        switch (customerType)
        {
            case CustomerType.B2B:
                PayInFee = 0.2m * monthlyTransactions.PayInAmount;
                PayOutFee = 0.2m * monthlyTransactions.PayOutAmount;

                break;
            case CustomerType.B2C:
                PayInFee = 0.1m * monthlyTransactions.PayInAmount;
                PayOutFee = 0.1m * monthlyTransactions.PayOutAmount;
                AdminFee = (PayInFee + PayOutFee) * 0.1m;

                break;
            // case CustomerType.B2B2C:
            //     PayInFee = 0.3m * monthlyTransactions.PayInAmount;
            //     PayOutFee = 0.3m * monthlyTransactions.PayOutAmount;
            //     AdminFee = (PayInFee + PayOutFee) * 0.05m;
            //
            //     break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}