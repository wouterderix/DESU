<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateNews.aspx.cs" Inherits="B2D3.UpdateNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gvNews" runat="server">
        </asp:GridView>
        <asp:TextBox ID="tbHistoryId" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="History Id"></asp:Label>
    
    </div>
        <p>
            <asp:TextBox ID="tbVersionId" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Version Id"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Titel"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Omschrijving"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Goed Gekeurt"></asp:Label>
            <asp:RadioButtonList ID="rblApproved" runat="server">
                <asp:ListItem Selected="True" Value="true">Goedgekeurt</asp:ListItem>
                <asp:ListItem Value="false">Afgekeurt</asp:ListItem>
            </asp:RadioButtonList>
        </p>
    </form>
</body>
</html>
