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
    public partial class View_transections : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayTransactionLog();
            }

        }
        protected void MainMenuButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        
        private void DisplayTransactionLog()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Transaction_Log";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    StringBuilder transactionLogTable = new StringBuilder();
                    transactionLogTable.Append("<table>");
                    transactionLogTable.Append("<tr><th>ID</th><th>Type</th><th>Item Name</th><th>Item Price</th><th>Quantity</th><th>Employee Name</th><th>Date Added</th></tr>");

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string transactionType = (string)reader["TypeOfTransaction"];
                        string itemName = (string)reader["ItemName"];
                        var itemPrice = reader["ItemPrice"];
                        var quantity = reader["Quantity"];
                        string employeeName = (string)reader["EmployeeName"];
                        DateTime dateAdded = (DateTime)reader["DateAdded"];

                        transactionLogTable.Append("<tr>");
                        transactionLogTable.AppendFormat("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3:C}</td><td>{4}</td><td>{5}</td><td>{6}</td>",
                            id, transactionType, itemName, itemPrice, quantity, employeeName, dateAdded);
                        transactionLogTable.Append("</tr>");
                    }

                    transactionLogTable.Append("</table>");

                    reader.Close();

                    TransactionLogTableLiteral.Text = transactionLogTable.ToString();
                }
            }
        }
    }
}