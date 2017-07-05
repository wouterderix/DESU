<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="B2D3._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Menu ID="Menu1" runat="server" BorderStyle="None" OnMenuItemClick="Menu1_MenuItemClick">
            <Items>
                <asp:MenuItem Text="Occasions" Value="" Enabled="true">
                    <asp:MenuItem Text="Occasion Overzicht" Value="" Enabled="True" NavigateUrl="~/UI/Occasion_Overzicht.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Occasion Controlleren" Value="" Enabled="True" NavigateUrl="~/UI/Occasion_Controlleren.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Occasion Toevoegen" Value="" Enabled="True" NavigateUrl="~/UI/Occasion_Toevoegen.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Producten" Value="" Enabled="true">
                    <asp:MenuItem Text="Product Overzicht/Product Aanpasen" Value="" Enabled="True" NavigateUrl="~/UI/Viewproduct.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Product Reviewen" Value="" Enabled="True" NavigateUrl="~/UI/ReviewProduct.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Product Verwijderen" Value="" Enabled="True" NavigateUrl="~/UI/DeleteProductTest.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Product Toevoegen" Value="" Enabled="True" NavigateUrl="~/UI/ProductToevoegen.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Nieuws" Value="" Enabled="true">
                    <asp:MenuItem Text="Nieuws Goedkeuren" Value="" Enabled="True" NavigateUrl="~/ApproveNews.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Nieuws Inzien" Value="" Enabled="True" NavigateUrl="~/GetNews.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Nieuws Bewerken" Value="" Enabled="True" NavigateUrl="~/UpdateNews.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Contact" Value="" Enabled="true" NavigateUrl="~/UI/Contact.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Check Date" Value="" Enabled="true" NavigateUrl="~/UI/CheckDate.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Audit Log" Value="" Enabled="true" NavigateUrl="~/UI/AuditLogUI.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </div>
    </form>
</body>
</html>
