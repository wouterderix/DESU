<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteProductTest.aspx.cs" Inherits="B2D3.Classes.UI.DeleteProductTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBoxDelete" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonDelete" runat="server" Text="Button" OnClick="dltBtn_Click"/>
    </div>
    <div>
        <asp:Label ID="LableError" Text="This product does not exist. . ." runat="server"
             Visible="false" Enabled="false"></asp:Label>
        <asp:Button ID="ButtonError" Text="OK" runat ="server" 
            Visible="false" Enabled="false" OnClick="errorBtn_Click"/>
    </div>
    <div>
        <asp:Label ID="LableConfirm" Text="The product has been deleted. . ." runat="server"
            Visible="false" Enabled="false"></asp:Label>
        <asp:Button ID="ButtonConfirm" Text="OK" runat ="server" 
            Visible="false" Enabled="false" OnClick="confirmBtn_click"/>
    </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Terug" />
        </p>
    </form>
</body>
</html>