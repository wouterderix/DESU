<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viewproduct.aspx.cs" Inherits="B2D3.UI.viewProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Terug" />
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateEditButton="True" Height="267px" Width="720px" OnRowEditing="GridView1_RowEditing">
        </asp:GridView>
    </form>
</body>
</html>
