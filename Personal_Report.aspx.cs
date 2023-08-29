using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssignmentWebApp
{
    public partial class Personal_Report : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            FetchAndDisplayTransactionDetails();
        }
        protected void MainMenuButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        private void FetchAndDisplayTransactionDetails()
        {

            string employeeName = (string)Session["EmployeeName"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DateAdded, Id, ItemName, Quantity FROM Transaction_Log WHERE TypeOfTransaction = 'Quantity Removed' AND EmployeeName = @EmployeeName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeName", employeeName);
                    SqlDataReader reader = command.ExecuteReader();

                    StringBuilder logDetails = new StringBuilder();
                    logDetails.Append("<table>");
                    logDetails.Append("<tr><th>Date</th><th>ID</th><th>Item Name</th><th>Quantity</th></tr>");

                    while (reader.Read())
                    {
                        DateTime dateAdded = (DateTime)reader["DateAdded"];
                        int id = (int)reader["ID"];
                        string itemName = (string)reader["ItemName"];
                        string quantity = (string)reader["Quantity"];

                        logDetails.Append("<tr>");
                        logDetails.AppendFormat("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", dateAdded, id, itemName, quantity);
                        logDetails.Append("</tr>");
                    }

                    logDetails.Append("</table>");

                    reader.Close();

                    LogDetailsLiteral.Text = logDetails.ToString();
                }
            }
        }
    }
}