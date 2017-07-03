<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditLogUI.aspx.cs" Inherits="B2D3.Classes.UI.AuditLogUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>
        <br />
        <asp:Label ID="ErrorLabel" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <asp:Button ID="Generate" runat="server" Text="Generate" OnClick="Generate_Click"/>
    
    </div>
        <asp:GridView ID="GridView" runat="server"/>
    </form>
</body>
</html>
