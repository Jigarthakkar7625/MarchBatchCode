<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MyFirstAspNetWebFormApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" />
        <%: Title %>.<input id="Text1" type="text" /></h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>

