<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckDate.aspx.cs" Inherits="B2D3.Classes.UI.CheckDate" %>

<!DOCTYPE html>
<!--
    +--------------------------------------------------+
    | Code written by Thom Kemp - 1534009kemp@zuyd.nl  |
    |          Zuyd Hogeschool - Faculteit ICT         |
    |     Leerjaar 2 / Casus blok 4 / Ergotherapie     |
    +--------------------------------------------------+
-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CheckDate - Casus Blok 4 - Ergotherapie</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- DataTable for query results -->
            <asp:GridView ID="DataTable" runat="server"></asp:GridView>

            <!-- Error message if no data available -->
            <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
        </div>
        <div>
            <!-- Info on deleting products -->
            <asp:Label ID="info1" runat="server">Om een product te verwijderen is het van belang om de waardes van het product dat verwijderd moet worden in de invoervelden in te voeren.</asp:Label>
            <br />
            <!-- Info on editing products -->
            <asp:Label ID="info2" runat="server">Om een product bij te werken is het van belang om de waardes van het product dat bijgewerkt moet worden in de invoervelden in te voeren, maar daarnaast ook een nieuwe houdbaarheidsdatum te selecteren.</asp:Label>
        </div>
        <p>
            <!-- ModifyID input and label -->
            <asp:Label ID="modLab" runat="server">ModifyID</asp:Label>
            <asp:TextBox ID="modifyID" runat="server"></asp:TextBox>

            <!-- VersionID input and label -->
            <asp:Label ID="verLab" runat="server">VersionID</asp:Label>
            <asp:TextBox ID="verID" runat="server"></asp:TextBox>

            <!-- DimensionID input and label -->
            <asp:Label ID="dimLab" runat="server">DimensionID</asp:Label>
            <asp:TextBox ID="dimID" runat="server" ></asp:TextBox>

            <br />
            <br />

            <!-- ExpirationDate input and label -->
            <asp:Label ID="dateLab" runat="server">ExpirationDate</asp:Label>
            <asp:Calendar ID="DatePicker" runat="server"></asp:Calendar>

            <br />

            <!-- Button for modify and delete event -->
            <asp:Button ID="btnModify" runat="server" Text="Modify" OnClick="btnModify_Click" /><asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />


            <!-- Error message if ID is not valid -->
            <asp:Label ID="ErrorMessage2" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
