﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetNews.aspx.cs" Inherits="B2D3.GetNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lDocentNaam" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" SelectMethod="GridViewSelectEventHandler">
            </asp:GridView>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Terug" />
    </form>
</body>
</html>
