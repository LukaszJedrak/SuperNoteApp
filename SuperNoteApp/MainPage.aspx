<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="SuperNoteApp.MainPage" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="grid-container">
        <div>
            <asp:Label Text="" CssClass="welcomeUser" ID="welcomeUser" runat="server" />
            <br />
            <b><asp:Button Text="Logout" CssClass="logout" ID="logout" OnClick="logout_Click" runat="server" /></b>
        </div>

        <div>
            <b><asp:Label Text="Subject:" runat="server" /></b>
            <textarea style="resize:none" id="textArea" class="textArea2" runat="server" />
            <b><asp:Label Text="Message:" runat="server" /></b>
            <textarea style="resize:none" id="textArea2" class="textArea" runat="server" />
            <b><asp:Button runat="server" ID="addNoteButton" Height="50px"
                Width="400px" CssClass="addNoteButton" Text="Add Note" OnClick="addNoteButton_Click" /></b>
        </div>

        <div>
            <b><asp:Label Text="Your Saved Notes" runat="server"/></b>
            <br />
            <asp:ListBox AutoPostBack="True" OnSelectedIndexChanged="listItems_SelectedIndexChanged" 
                Width="200px" Height="250px"  ID="listItems" runat="server" />
        </div>

    </div>

</asp:Content>


