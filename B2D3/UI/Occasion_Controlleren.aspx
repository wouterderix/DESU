<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Occasion_Controlleren.aspx.cs" Inherits="B2D3.Classes.UI.OccasionControlleren" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 536px;
            width: 1316px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="BOccasionGoedkeuren" runat="server" Text="verzend" style="position:absolute; top: 373px; left: 33px; width: 122px;" OnClick="BOccasionGoedkeuren_Click" />

        <asp:Button ID="BReturn" runat="server" Text="Terug" style="position:absolute; top: 373px; left: 159px; right: 1249px; width:122px" OnClick="BGoedkeurenReturn_Click" />

        <asp:GridView ID="UnapproveOccasions" runat="server" AutoGenerateColumns ="false">
            <Columns> 
                <asp:TemplateField HeaderText="goedgekeurd" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="SelectCheckBox" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:Boundfield datafield ="Title" headertext="Titel" />
                <asp:Boundfield datafield ="Description" headertext="Beschrijving" />
                <asp:Boundfield datafield ="Date" headertext="Datum" />
                <asp:Boundfield datafield ="Location" headertext="Locatie" />
            </Columns>
            
        </asp:GridView>
    </form>
</body>
</html>
