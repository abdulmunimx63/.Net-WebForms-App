using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssignmentWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RedirectButton_Click(object sender, EventArgs e)
        {

            string userInput = Input_option.Text.Trim();

            int option;
            if (int.TryParse(userInput, out option))
            {
                Session["SelectedOption"]=option;

                switch (option)
                {
                    case 1:
                        Response.Redirect("Employee_name.aspx");
                        break;
                    case 2:
                        Response.Redirect("Employee_name.aspx");
                        break;
                    case 3:
                        Response.Redirect("Employee_name.aspx");
                        break;
                    case 4:
                        Response.Redirect("View_inventory.aspx");
                        break;
                    case 5:
                        Response.Redirect("View_financial.aspx");
                        break;
                    case 6:
                        Response.Redirect("View_transections.aspx");
                        break;
                    case 7:
                        Response.Redirect("Employee_name.aspx");
                        break;
                    // Add more cases for other options
                    default:
                        // Redirect to a default page or show an error message
                        Response.Redirect("DefaultRedirectPage.aspx");
                        break;
                }
            }
            else
            {
                // Handle invalid input, show error message, etc.
            }
        }

    }
}

