<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_Item.aspx.cs" Inherits="AssignmentWebApp.Add_Item" %>

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
            width: 400px; /* You can adjust the width as needed */
        }
        .form-group {
            margin-bottom: 15px;
        }
        label {
            display: inline-block;
            width: 120px; /* Adjust the width as needed for alignment */
            margin-right: 10px;
        }
        input[type="text"] {
            width: 200px; /* Adjust the width as needed for alignment */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <h2>Add Item</h2>
            <div class="form-group">
                <label for="ItemID">Item ID:</label>
                <asp:TextBox ID="ItemID" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ItemIDValidator" runat="server" ControlToValidate="ItemID"
                    ErrorMessage="Item ID is required" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="ItemIDFormatValidator" runat="server" ControlToValidate="ItemID"
                    ErrorMessage="Invalid Item ID format" ValidationExpression="^\d+$" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="ItemIDCheckValidator" runat="server" ControlToValidate="ItemID"
                    OnServerValidate="ItemIDCheckValidator_ServerValidate" ErrorMessage="Item ID already exists"
                    ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
            </div>

            <div class="form-group">
                <label for="ItemName">Item Name:</label>
                <asp:TextBox ID="ItemName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ItemNameValidator" runat="server" ControlToValidate="ItemName"
                    ErrorMessage="Item Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="ItemQuantity">Item Quantity:</label>
                <asp:TextBox ID="ItemQuantity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ItemQuantityValidator" runat="server" ControlToValidate="ItemQuantity"
                    ErrorMessage="Item Quantity is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="ItemPrice">Item Price:</label>
                <asp:TextBox ID="ItemPrice" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ItemPriceValidator" runat="server" ControlToValidate="ItemPrice"
                    ErrorMessage="Item Price is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <asp:Button ID="AddItemButton" runat="server" Text="Add Item" OnClick="AddItemButton_Click" />
        </div>
    </form>
</body>
</html>
