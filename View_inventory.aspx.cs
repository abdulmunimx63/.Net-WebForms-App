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
    public partial class View_inventory : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FetchAndDisplayInventory();
            }
        }
        protected void MainMenuButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        private void FetchAndDisplayInventory()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ID,Name, Quantity FROM Item";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    StringBuilder inventoryTable = new StringBuilder();
                    inventoryTable.Append("<table>");
                    inventoryTable.Append("<tr><th>ID</th><th>Name</th><th>Quantity</th></tr>");

                    while (reader.Read())
                    {
                        int id = (int)reader["ID"];
                        string itemName = (string)reader["Name"];
                        int itemQuantity = (int)reader["Quantity"];

                        inventoryTable.Append("<tr>");
                        inventoryTable.AppendFormat("<td>{0}</td><td>{1}</td><td>{2}</td>", id, itemName, itemQuantity);
                        inventoryTable.Append("</tr>");
                    }

                    inventoryTable.Append("</table>");

                    reader.Close();

                    InventoryTableLiteral.Text = inventoryTable.ToString();
                }
            }
        }
    }
}
