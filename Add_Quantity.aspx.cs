using System;
using System.Configuration;
using System.Data.SqlClient;

namespace AssignmentWebApp
{
    public partial class Add_Quantity : System.Web.UI.Page
    {
        int Id;
        string Name;
        int Quantity;
        DateTime DateCreated;

        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FindButton_Click(object sender, EventArgs e)
        {
            string itemID = ItemID.Text.Trim();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Item WHERE Id = @ItemID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemID", itemID);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Id = Convert.ToInt32(reader["Id"]);
                        Name = reader["Name"].ToString();
                        Quantity = Convert.ToInt32(reader["Quantity"]);
                        DateCreated = (DateTime)reader["DateCreated"];

                        // Item found, show the update panel
                        UpdatePanel.Visible = true;
                    }
                    else
                    {
                        // Item not found, hide the update panel
                        UpdatePanel.Visible = false;
                    }

                    reader.Close();
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string itemID = ItemID.Text.Trim();
            int updatedQuantity = Convert.ToInt32(ItemQuantity.Text.Trim());
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Item WHERE Id = @ItemID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemID", itemID);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Id = Convert.ToInt32(reader["Id"]);
                        Name = reader["Name"].ToString();
                        Quantity = Convert.ToInt32(reader["Quantity"]);
                        DateCreated = (DateTime)reader["DateCreated"];

                        // Item found, show the update panel
                        UpdatePanel.Visible = true;
                    }
                    else
                    {
                        // Item not found, hide the update panel
                        UpdatePanel.Visible = false;
                    }

                    reader.Close();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE ITEM SET Quantity = Quantity + @NewQuantity WHERE Id = @ItemId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@NewQuantity", updatedQuantity));
                    command.Parameters.Add(new SqlParameter("@ItemId", itemID));

                    int quantityRowsAffected = command.ExecuteNonQuery();

                    if (quantityRowsAffected > 0)
                    {
                        string employeeName = (string)Session["EmployeeName"];

                        // Insert item transaction log
                        DateTime dateAdded = DateTime.Now;

                        string insertLogQuery = "INSERT INTO Transaction_Log (TypeOfTransaction, ItemName, ItemPrice, Quantity, EmployeeName, DateAdded) VALUES (@TypeOfTransaction, @ItemName, @ItemPrice, @Quantity, @employeeName, @DateAdded)";
                        using (SqlCommand logCommand = new SqlCommand(insertLogQuery, connection))
                        {
                            logCommand.Parameters.AddWithValue("@TypeOfTransaction", "Quantity Added");
                            logCommand.Parameters.AddWithValue("@ItemName", Name);
                            logCommand.Parameters.AddWithValue("@ItemPrice", ItemPrice.Text.Trim());
                            logCommand.Parameters.AddWithValue("@Quantity", Quantity);
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
    }
}