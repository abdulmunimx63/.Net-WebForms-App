<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AssignmentWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <b><p class="lead">Select the Option.</p></b>
        </section>

        <div class="row">
            <section class="col-md-6" aria-labelledby="gettingStartedTitle">
                <p>1. Add item to stock</p>
                <p>2. Add quantity to item</p>
                <p>3. Take quantity from item</p>
                <p>4. View inventory report</p>
                <p>5. View financial report</p>
                <p>6. View transaction log</p>
                <p>7. View personal usage report</p>

                <hr />
                    <div>
                        <label for="Input_option">Enter any number from 1 to 7   :  </label>
                        <asp:TextBox ID="Input_option" runat="server"></asp:TextBox>
                        <asp:Button ID="RedirectButton" runat="server" Text="Redirect" OnClick="RedirectButton_Click" />
                    </div>
                    <asp:HiddenField ID="SelectedOption" runat="server" />


            </section>
        </div>
    </main>

</asp:Content>
