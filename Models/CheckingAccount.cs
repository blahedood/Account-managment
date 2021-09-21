using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CheckingAccount : Account
{
    public CheckingAccount(string Name,double balance): base(Name)
    {
        base.Deposit(balance);
    }
    public static double MaxWithdrawAmount { get; set; }

    //Add your code here to complete the definition of the class as required

    public override void Withdraw(double amount)
    {
        if (amount > MaxWithdrawAmount)
        {
            throw new Exception($"Exceed Max Withdraw Amount: ${MaxWithdrawAmount}");

        }

        else
        {
            base.Withdraw(amount);
        }
    }
}

