<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveNews.aspx.cs" Inherits="B2D3.ApproveNews" %>



<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
    <meta name="author" content="Xavier van Egdom" />
    <meta name="UseCase" content="Nieuws goedkeuren" />
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:GridView ID="gvNews" runat="server">
                </asp:GridView>
                <asp:TextBox ID="tbId" runat="server"></asp:TextBox>
                <asp:Button ID="btnApprove" runat="server" OnClick="btnApprove_Click" Text="goedkeuren" />
            </div>
        </form>
    </body>
</html>
