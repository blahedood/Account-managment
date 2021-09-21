using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Withdraw : System.Web.UI.Page
{
    List<Account> accountList;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Add your code here to complete the implementation as required
        this.accountList = Session["List"] != null ? (List<Account>)Session["List"] : new List<Account>();
        if (drpAccount.Items.Count != this.accountList.Count)
        {
            this.drpAccount.Items.Clear();
            foreach (var item in accountList)
            {
                drpAccount.Items.Add(item.ToString());
            }
        }
    }
    protected void drpAccount_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Add your code here to complete the implementation as required
        if(drpAccount.SelectedIndex >= 0 && drpAccount.Items.Count > drpAccount.SelectedIndex)
        {
            Account account = accountList[drpAccount.SelectedIndex];
            txtCurrentBalance.Text = account.Balance.ToString();
        }
    }

    protected void btnWithdraw_Click(object sender, EventArgs e)
    {       
        try
        {
            //Add your code here to complete the implementation as required
            if (drpAccount.SelectedIndex >= 0 && drpAccount.Items.Count > drpAccount.SelectedIndex)
            {
                Account account = accountList[drpAccount.SelectedIndex];
                account.Withdraw(Convert.ToDouble(txtWithdrawAmount.Text));
                lblInfo.Text = "The transaction Complete: $" + txtWithdrawAmount.Text + " deducted from the balance";
            }else
            {
                lblInfo.Text = "";
            }
        }
        catch (Exception ex)
        {
            //Add your code here to complete the implementation as required
            lblInfo.Text = ex.Message;

        }
    }

}