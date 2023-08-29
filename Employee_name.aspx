<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee_name.aspx.cs" Inherits="AssignmentWebApp.Employee_name" %>

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
        #CheckButton {
            margin-top:15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <h2>Enter Employee Name</h2>
            <div>
                <label for="EmployeeName">Enter Employee Name:</label>
                <asp:TextBox ID="EmployeeName" runat="server"></asp:TextBox></br>
                <asp:Button ID="CheckButton" runat="server" Text="Check Employee" OnClick="CheckButton_Click" />
            </div>
        </div>
    </form>
</body>
</html>
