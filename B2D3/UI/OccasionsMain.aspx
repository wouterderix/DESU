<!DOCTYPE html>
<script runat="server">

    Protected Sub btnControleren_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/UI/Occasion_Controlleren.aspx")
    End Sub

    Protected Sub btnToevoegen_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/UI/Occasion_Toevoegen.aspx")
    End Sub

    Protected Sub btnOverzicht_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/UI/Occasion_Overzicht.aspx")
    End Sub
</script>

<html>
<head>
    <title></title>
	<meta charset="utf-8" />
</head>
<body style="font-size: xx-large">

    <form id="form1" runat="server">
        <p>
            OccaOccasions</p>
        <asp:Button ID="btnControleren" runat="server" Text="Controleren" OnClick="btnControleren_Click" />
        <asp:Button ID="btnToevoegen" runat="server" Text="Toevoegen" OnClick="btnToevoegen_Click" />
        <asp:Button ID="btnOverzicht" runat="server" Text="Overzicht" OnClick="btnOverzicht_Click" />
    </form>

</body>
</html>
