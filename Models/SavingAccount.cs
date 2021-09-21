using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SavingAccount : Account
{
    public SavingAccount(string Name, double balance) : base(Name)
    {
        base.Deposit(balance);
    }
    public static double WithdrawPenaltyAmount { get; set; }
    public static double WithdrawPenaltyWaiverBalance { get; set; }

    //Add your code here to complete the definition of the class as required
    public override double GetWithdrawPenaltyAmount()
    {
        if(Balance < WithdrawPenaltyWaiverBalance)
        {
            return WithdrawPenaltyAmount;
        }
        else if(Balance > WithdrawPenaltyWaiverBalance)
        {
            return 0.0;
        }

        return base.GetWithdrawPenaltyAmount();
    }

}

