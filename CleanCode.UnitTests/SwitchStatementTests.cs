using CleanCode.SwitchStatement;
using FluentAssertions;
using NUnit.Framework;

namespace CleanCode.UnitTests;

public class SwitchStatementTests
{
    [Test]
    public void B2bPlayer_ChargeTwentyPercentFee()
    {
        var customer = new Customer() { Type = CustomerType.B2B };
        var monthlyTransactions = new MonthlyTransactions(customer: customer, payInAmount: 100, payOutAmount: 500);
        var statementDetail = new StatementDetail();
        
        statementDetail.Generate(monthlyTransactions);

        statementDetail.Should().BeEquivalentTo(new StatementDetail
        {
            AdminFee = 0,
            PayOutFee = 100,
            PayInFee = 20
        });
    }

    [Test]
    public void B2cPlayer_ChargeTenPercentFeeAndTenPercentAdminFee()
    {
        var customer = new Customer() { Type = CustomerType.B2C };
        var monthlyTransactions = new MonthlyTransactions(customer: customer, payInAmount: 100, payOutAmount: 500);
        var statementDetail = new StatementDetail();
        
        statementDetail.Generate(monthlyTransactions);

        statementDetail.Should().BeEquivalentTo(new StatementDetail
        {
            AdminFee = 6,
            PayOutFee = 50,
            PayInFee = 10
        });
    }
}