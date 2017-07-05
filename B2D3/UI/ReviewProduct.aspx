<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReviewProduct.aspx.cs" Inherits="B2D3.Classes.UI.ReviewProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="ReviewLabel" runat="server" Text="Beoordeel hier het product" /><br />
        <asp:TextBox ID="Review" runat="server" TextMode="MultiLine" Rows="5" ></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Review" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="H">Review moet ingevuld zijn</asp:RequiredFieldValidator>        
    </div>    
    <div id="RatingDiv" style="margin-top:10px">
        <asp:Label ID="RatingLabel" runat="server" Text="Puntbeoorlding product: 1=laagst 5=hoogst"></asp:Label>
        <asp:RadioButtonList ID="Rating" runat="server" RepeatDirection="Horizontal" >
            <asp:ListItem Text="1" Value="1" />
            <asp:ListItem Text="2" Value="2" />
            <asp:ListItem Text="3" Value="3" />
            <asp:ListItem Text="4" Value="4" />
            <asp:ListItem Text="5" Value="5" />
        </asp:RadioButtonList>
    </div>
    <div id="AnoniemPlaatsen" style="margin-top:10px">
        <asp:Label ID="AnoniemLabel" runat="server" Text="Anoniem beoordelen"></asp:Label>
        <asp:CheckBox ID="Anoniem" runat="server" Checked="false" />
    </div>
    <div style="margin-top:10px">
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Terug" />
        <asp:Button ID="Button1" runat="server" Text="Verzenden" OnClick="Button1_Click" ValidationGroup="H"  />  
    </div>
    </form>
</body>
</html>
