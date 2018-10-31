<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SuperNoteApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="Position">
        <br />
        <br />
        <div>
            <asp:Label runat="server" Font-Size="20px" Text="Username:" />
        </div>
        <div>
            <asp:TextBox Height="35px" Font-Size="16px" Width="250" ID="username1" Text="" runat="server" />
        </div>

        <div>
            <br />
            <asp:Label runat="server" Font-Size="20px" Text="Password:" />
        </div>

        <div>

            <asp:TextBox Height="35px" Font-Size="16px" TextMode="Password" Width="250" ID="password1" Text="" runat="server" />
        </div>

        <div>
            <br />
            <asp:Label ForeColor="Red" Font-Size="18px" CssClass="info" ID="info" runat="server" Text="" />
        </div>

        <div id="button">
            <br />
            <asp:Button Width="200" Height="35px" BackColor="Black" ForeColor="White" runat="server" Text="Login" ID="loginBtn" OnClick="loginBtn_Click" />
            <asp:Button Width="200" Height="35px" BackColor="Black" ForeColor="White" runat="server" Text="Register" ID="register" OnClick="register_Click" />

        </div>



    </div>


</asp:Content>
