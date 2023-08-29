<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personal_Report.aspx.cs" Inherits="AssignmentWebApp.Personal_Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            margin: 0;
        }

        table {
            border-collapse: collapse;
            width: 80%;
            max-width: 800px;
            border: 1px solid #333;
            margin: 20px;
        }

        th, td {
            border: 1px solid #333;
            padding: 10px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }

        #MainMenuButton {
            margin-top: 15px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <div class="menu-container">
                <asp:Button ID="MainMenuButton" runat="server" Text="Main Menu" OnClick="MainMenuButton_Click" />
            </div>

            <h2>Personal Usage Report</h2>

            <asp:Literal ID="LogDetailsLiteral" runat="server"></asp:Literal>
        </div>
    </form>

</body>
</html>
