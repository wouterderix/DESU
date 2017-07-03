<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkItemUI.aspx.cs" Inherits="B2D3.UI.WorkItemUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    
        <asp:Button ID="Button" runat="server" OnClick="Button_Click" Text="Button" />
    
    </div>
    </form>
</body>
</html>
