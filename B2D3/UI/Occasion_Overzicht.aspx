<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Occasion_Overzicht.aspx.cs" Inherits="B2D3.Classes.UI.Occasion_Overzicht" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 40px">
        
        <h1>Alle Evenementen</h1>
        <asp:Button ID="btn_Back" runat="server" OnClick="btn_Back_Click" Text="Terug" />
        <asp:GridView ID="AllOccasionsView" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AutoGenerateSelectButton="True" OnSelectedIndexChanged="AllOccasionsView_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="HistoryID">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />

            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Titel" />
                <asp:BoundField DataField="Description" HeaderText="Beschrijving" />
                <asp:BoundField DataField="Date" HeaderText="Datum" />
                <asp:BoundField DataField="Location" HeaderText="Plaats" />
                <asp:BoundField DataField="MoreInformationUrl" HeaderText="Meer Informatie" />
            </Columns>
        </asp:GridView>
        
    </div>
    </form>
</body>
</html>
