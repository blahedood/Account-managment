using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerManage : System.Web.UI.Page
{
    List<Account> AccountList;

    protected void Page_Load(object sender, EventArgs e)
    {
        AccountList = Session["List"] != null ? (List<Account>)Session["List"] : new List<Account>();
    }
    protected override void OnLoadComplete(EventArgs e)
    {
        txtCustomerName.Text = "";
        txtInitialDeposit.Text = "";
        drpAccountType.SelectedIndex = -1;

        ShowAccounts(this.AccountList);
        base.OnLoadComplete(e);
    }
    protected override void OnUnload(EventArgs e)
    {
        Session["List"] = this.AccountList;

        base.OnUnload(e);
    }

    protected void btnAddAccount_Click(object sender, EventArgs e)
    {
        //Add your code here to complete the implementation as required
        Account account = null;
        double balance = Convert.ToDouble(txtInitialDeposit.Text);
        if (drpAccountType.SelectedValue == "CheckingAccount")
        {
            account = new CheckingAccount(txtCustomerName.Text, balance);
        }
        if (drpAccountType.SelectedValue == "SavingAccount")
        {
            account = new SavingAccount(txtCustomerName.Text, balance);
        }
        this.AccountList.Add(account);


    } 

#region Helpers: Use ShowAccounts(...) method to display a list of accounts.
    private void ShowAccounts(List<Account> accounts)
    {
        if (accounts.Count == 0)
        {
            TableRow row = new TableRow();
            tblCourses.Rows.Add(row);

            TableCell cell = new TableCell();
            row.Cells.Add(cell);

            cell.Text = "No account in the system yet";
            cell.ForeColor = System.Drawing.Color.Red;
            cell.ColumnSpan = 4;   
        }
        else
        {
            foreach (Account ac in accounts)
            {
                TableRow row = new TableRow();
                tblCourses.Rows.Add(row);

                TableCell cell = new TableCell();
                cell.Text = ac.AccountNumber;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ac.OwnerName;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ac.AccountType;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ac.Balance.ToString("C2");
                row.Cells.Add(cell);
            }
        }
    }

#endregion
}