using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssignmentWebApp
{
    public partial class Employee_name : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CheckButton_Click(object sender, EventArgs e)
        {            
            string employeeName = EmployeeName.Text.Trim();
            Session["EmployeeName"] = employeeName;

            // Get the stored selected option
            int selectedOption = Convert.ToInt32(Session["SelectedOption"]);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Employee WHERE Name = @EmployeeName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeName", employeeName);
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        switch (selectedOption)
                        {
                            case 1:
                                Response.Redirect("Add_Item.aspx");
                                break;
                            case 2:
                                Response.Redirect("Add_Quantity.aspx");
                                break;
                            case 3:
                                Response.Redirect("Take_Quantity.aspx");
                                break;
                            case 7:
                                Response.Redirect("Personal_Report.aspx");
                                break;
                            default:
                                // Redirect to a default page or show an error message
                                Response.Redirect("DefaultRedirectPage.aspx");
                                break;
                        }

                        // Employee exists, redirect to the "AddItem" page
                        Response.Redirect("AddItem.aspx");
                    }
                    else
                    {
                        // Employee does not exist, show an error message or take appropriate action
                        // For example, display a label with an error message
                        //ErrorLabel.Text = "Employee not found.";
                    }
                }
            }
        }
    }
}