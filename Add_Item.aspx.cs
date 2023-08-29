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
    public partial class Add_Item : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ItemIDCheckValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string itemID = ItemID.Text.Trim();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Item WHERE Id = @ItemID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemID", itemID);
                    int count = (int)command.ExecuteScalar();

                    args.IsValid = (count == 0);
                }
            }
        }

        protected void AddItemButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string itemID = ItemID.Text.Trim();
                string itemName = ItemName.Text.Trim();
                int itemQuantity = Convert.ToInt32(ItemQuantity.Text.Trim());
                decimal itemPrice = Convert.ToDecimal(ItemPrice.Text.Trim());

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Item ( Name, Quantity, DateCreated) VALUES ( @ItemName, @ItemQuantity, @DateCreated)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ItemName", itemName);
                        command.Parameters.AddWithValue("@ItemQuantity", itemQuantity);
                        command.Parameters.AddWithValue("@DateCreated", DateTime.Now);

                        int itemRowsAffected = command.ExecuteNonQuery();

                        if (itemRowsAffected > 0)
                        {
                            string employeeName = (string)Session["EmployeeName"];

                            // Insert item transaction log
                            DateTime dateAdded = DateTime.Now;

                            string insertLogQuery = "INSERT INTO Transaction_Log (TypeOfTransaction, ItemName, ItemPrice, Quantity, EmployeeName, DateAdded) VALUES (@TypeOfTransaction, @ItemName, @ItemPrice, @Quantity, @employeeName, @DateAdded)";
                            using (SqlCommand logCommand = new SqlCommand(insertLogQuery, connection))
                            {
                                logCommand.Parameters.AddWithValue("@TypeOfTransaction", "Item Added");
                                logCommand.Parameters.AddWithValue("@ItemName", itemName);
                                logCommand.Parameters.AddWithValue("@ItemPrice", itemPrice);
                                logCommand.Parameters.AddWithValue("@Quantity", itemQuantity);
                                logCommand.Parameters.AddWithValue("@EmployeeName", employeeName);
                                logCommand.Parameters.AddWithValue("@DateAdded", dateAdded);

                                int logRowsAffected = logCommand.ExecuteNonQuery();

                                if (logRowsAffected > 0)
                                {
                                    // Transaction log inserted successfully
                                    Response.Redirect("Default.aspx");
                                }
                                else
                                {
                                    // Transaction log insertion failed, show an error message or handle it accordingly
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // Validation failed, do not insert into database
            }
        }
    }
}