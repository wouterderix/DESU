<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="B2D3._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Usecases Evenementen"></asp:Label>
        <br />
        <asp:Button ID="btn_allEvents" runat="server" Height="26px" OnClick="btn_allEvents_Click1" Text="Evenementen Overzicht" Width="157px" />
        <asp:Button ID="btn_newEvent" runat="server" Height="26px" OnClick="btn_newEvent_Click" Text="Nieuw Evenement" Width="157px" />
    </div>
    </form>
</body>
</html>
