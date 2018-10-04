using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        //Validates card
        protected void Pay_Click(object sender, EventArgs e)
        {
            char firstdigit = cardnumber.Text[0];
            string type, month, year;
            DateTime expdate;

            // check if fields are empty
            if (string.IsNullOrWhiteSpace(cardnumber.Text) || string.IsNullOrWhiteSpace(expirydate.Text) || string.IsNullOrWhiteSpace(cvcnumber.Text))
            {
                lblError.Text = "Fields cannot be empty";
            }
            else
            {
                Regex regex16 = new Regex(@"\d{16}"); // regex for 16 digits
                Regex regex15 = new Regex(@"\d{15}"); // regex for 15 digits
                Match result16 = regex16.Match(cardnumber.Text);
                Match result15 = regex15.Match(cardnumber.Text);
                if (result16.Success)
                {
                    if (firstdigit == '3') // JCB 
                    {
                        type = "jcb";
                        lblError.Text = "JCB Card is Vaild";
                    }
                    else if (firstdigit == '4') // VISA
                    {
                        //Formatting Date 
                        if (expirydate.Text.Length == '7')
                        {
                            month = expirydate.Text.Substring(0, 2);
                            year = expirydate.Text.Substring(expirydate.Text.Length - 2);
                            expdate = Convert.ToDateTime("01-" + month + "-" + year);
                        }
                        else
                        {
                            month = expirydate.Text.Substring(0, 1);
                            year = expirydate.Text.Substring(expirydate.Text.Length - 2);
                            expdate = Convert.ToDateTime("01-" + month + "-" + year);
                        }

                        if (DateTime.IsLeapYear(Convert.ToInt32(year))) //checks if the exp year is on a leap year
                        {
                            lblError.Text = "Visa Card is Vaild";
                        }
                        else

                            lblError.Text = "Visa Card is Invalid";

                    }
                    else if (firstdigit == '5') // Mastercard
                    {
                        //Formatting Date 
                        if (expirydate.Text.Length == 7)
                        {
                            month = expirydate.Text.Substring(0, 2);
                            year = expirydate.Text.Substring(expirydate.Text.Length - 2);
                            expdate = Convert.ToDateTime("01-" + month + "-" + year);
                        }
                        else
                        {
                            month = expirydate.Text.Substring(0, 1);
                            year = expirydate.Text.Substring(expirydate.Text.Length - 2);
                            expdate = Convert.ToDateTime("01-" + month + "-" + year);
                        }

                        if (Prime(year) == false)
                        {
                            lblError.Text = "Mastercard Card is Vaild";
                        }
                        else
                        {
                            lblError.Text = "Mastercard Card is not Vaild";
                        }
                    }
                    else
                        lblError.Text = "Credit Card is Invalid";

                }
                else
                if (result15.Success && firstdigit == '3') // Amex
                {
                    type = "Amex";
                    lblError.Text = "Amex Card is Vaild";
                }
                else
                    lblError.Text = "Credit Card is Invalid";
            }
        }

        // function that checks prime
        protected bool Prime(string year)
        {
            int i;
            bool Flag = false;
            int number = Convert.ToInt32(year);
            for (i = 2; i <= number; i++)
            {
                if ((i == number))      
                    i = i + 1;
                if ((number % i == 0)) //if remainder = 0
                {
                    Flag = true;
                    break;
                }
            }
            if ((Flag == false)) //Prime
            {
                return false;
            }
            else
                return true;    // Not prime
        }
    }

}