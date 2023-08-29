<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Take_Quantity.aspx.cs" Inherits="AssignmentWebApp.Take_Quantity" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            margin: 0;
        }
        .content {
            text-align: left;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: #f9f9f9;
            width: 400px; /* Adjust the width as needed */
        }
        .form-group {
            margin-bottom: 15px;
        }
        label {
            display: inline-block;
            width: 220px; /* Adjust the width as needed for alignment */
            margin-right: 10px;
        }
        input[type="text"] {
            width: 150px; /* Adjust the width as needed for alignment */
        }
        .button-container {
            margin-top: 10px;
            text-align: center;
        }
         #UpdateButton {
            margin-top: 15px;
        }

        #FindButton {
            margin-top: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <div class="form-group">
                <label for="ItemID">Enter Item ID:</label>
                <asp:TextBox ID="ItemID" runat="server"></asp:TextBox>
                <asp:Button ID="FindButton" runat="server" Text="Find" OnClick="FindButton_Click" />
            </div>
            <hr />
            <asp:Panel ID="UpdatePanel" runat="server" Visible="false">
                <div class="form-group">
                    <label for="ItemQuantity">Item Quantity to remove:</label>
                    <asp:TextBox ID="ItemQuantity" runat="server"></asp:TextBox>
                </div>

                <div class="button-container">
                    <asp:Button ID="UpdateButton" runat="server" Text="Update" OnClick="UpdateButton_Click" />
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
