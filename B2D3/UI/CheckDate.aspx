<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckDate.aspx.cs" Inherits="B2D3.Classes.UI.CheckDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="DataTable" runat="server"></asp:GridView>
        <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
    </div>
        <p>
        <asp:TextBox ID="modifyID" runat="server"></asp:TextBox>
        <asp:Button ID="btnModify" runat="server" Text="Modify" OnClick="btnModify_Click" /><asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <asp:Calendar ID="DatePicker" runat="server"></asp:Calendar>
        <asp:Label ID="ErrorMessage2" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
