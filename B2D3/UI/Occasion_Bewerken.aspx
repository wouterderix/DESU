<%@ Page Language="C#" CodeFile="Occasion_Bewerken.aspx.cs" AutoEventWireup="true" Inherits="B2D3.Classes.UI._Occasion_Bewerken" %>

<!DOCTYPE html>
<html>
<head>
    <title>Occasion Bewerken</title>
	<meta charset="utf-8" />
</head>
<body>
    <form runat="server">
    <div aria-orientation="horizontal" style="margin-left: 40px" >
        <asp:Label ID="EventTitel" runat="server" style="font-size: xx-large; font-weight: 700" Text="EventName"></asp:Label>
        <br />
        Event naam&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TBTitle" runat="server" Height="17px" Width="178px"></asp:TextBox>
        <br />
        beschrijving&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;<asp:TextBox ID="TBBeschrijving" runat="server" TextMode="MultiLine" Height="323px" Width="766px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        plaats&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TBPlaats" runat="server" Height="16px" Width="183px"></asp:TextBox>
        <br />
        datum&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TBDatum" runat="server" Height="16px" Width="184px" TextMode="Date"></asp:TextBox>
        <br />
        informatie url&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TBUrl" runat="server" Height="16px" Width="184px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnBewerk" runat="server" Height="50px" Text="Bewerk" Width="160px" OnClick="btnBewerk_Click" />
        <asp:Button ID="btnVerwijderen" runat="server" Height="50px" Text="Verwijderen" Width="160px" OnClick="btnVerwijderen_Click" />
        <asp:Button ID="btnCancel" runat="server" Height="50px" Text="Cancel" Width="160px" OnClick="btnCancel_Click" />
        <br />
    </div>
    </form>
</body>
</html>
