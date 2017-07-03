<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveProduct.aspx.cs" Inherits="B2D3._ApproveProductCC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Lijst met producten:<asp:GridView ID="gvProduct" runat="server">
        </asp:GridView>
        <br />
        HistoryID:<asp:TextBox ID="HistoryID" runat="server"></asp:TextBox>
        <br />
        Version:<asp:TextBox ID="Version" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="SendApproveProduct" runat="server" Text="Verzenden!" OnClick="SendApproveProduct_Click" />
        <br />
    </div>
    <div>
        <asp:Label ID="ConfirmLabel" runat="server" Text="SampleText" 
            Enabled="false" Visible="false"></asp:Label>
        <asp:Button ID="ConfirmButton" runat="server" Text="OK" OnClick="ConfirmButton_Click"
            Enabled="false" Visible="false" />
    </div>
    </form>
</body>
</html>
