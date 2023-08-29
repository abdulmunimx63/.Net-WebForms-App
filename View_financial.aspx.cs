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
    public partial class View_financial : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateFinancialReport();
            }
        }
        protected void MainMenuButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        private void GenerateFinancialReport()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "  SELECT ItemName, CAST(SUM(CAST(Quantity AS float) * ItemPrice) AS float) AS TotalPrice                   FROM Transaction_Log               GROUP BY ItemName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    StringBuilder financialReportTable = new StringBuilder();
                    financialReportTable.Append("<table>");
                    financialReportTable.Append("<tr><th>Product Name</th><th>Total Price</th></tr>");

                    while (reader.Read())
                    {
                        string itemName = (string)reader[0];
                        var totalPrice = reader[1];

                        financialReportTable.Append("<tr>");
                        financialReportTable.AppendFormat("<td>{0}</td><td>{1:C}</td>", itemName, totalPrice);
                        financialReportTable.Append("</tr>");
                    }

                    financialReportTable.Append("</table>");

                    reader.Close();

                    FinancialReportTableLiteral.Text = financialReportTable.ToString();
                }
            }
        }
    }
}