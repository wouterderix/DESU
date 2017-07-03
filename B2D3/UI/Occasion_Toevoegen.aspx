<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Occasion_Toevoegen.aspx.cs" Inherits="B2D3.UI.Occasion_Toevoegen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        #Txtbox_Title {
            width: 201px;
            margin-left: 60px;
        }
        #Txtbox_Title0 {
            width: 201px;
            margin-left: 31px;
        }
        #Txtbox_Title0 {
            width: 201px;
            margin-left: 60px;
        }
        #Txtbox_Place {
            width: 199px;
            margin-left: 94px;
        }
        #Txtbox_Place0 {
            width: 199px;
            margin-left: 93px;
        }
        #Txtbox_Url {
            width: 200px;
            margin-left: 36px;
        }
        #Txtbox_description {
            height: 91px;
            width: 340px;
        }
        #TextArea1 {
            height: 107px;
            width: 302px;
        }
        #Text1 {
            height: 148px;
            width: 400px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Nieuw Evenement"></asp:Label>
        <br />
        <asp:Label ID="Error_Label" runat="server" Font-Bold="True" ForeColor="#990000"></asp:Label>
        </div>
        <p>
            Event naam:<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 46px" Width="275px"></asp:TextBox>
        </p>
        <p>
            Plaats:<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 81px" Width="275px"></asp:TextBox>
        </p>
        <p>
            Informatie URL:<asp:TextBox ID="TextBox3" placeholder="Vergeet http:// niet" runat="server" style="margin-left: 23px" Width="275px"></asp:TextBox>
        </p>
        <p>
            Beschrijving</p>
        <p>
            <asp:TextBox ID="TextBox4" runat="server" Height="147px" Width="393px"></asp:TextBox>
        </p>
        Datum<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
        <br />
        <asp:Button ID="btn_NewEvent" runat="server" Height="62px" OnClick="btn_NewEvent_Click" Text="Nieuw Event" Width="114px" />
        <asp:Button ID="btn_Cancel" runat="server" Height="61px" OnClick="btn_Cancel_Click" style="margin-top: 0px" Text="Annuleer" Width="114px" />
    </form>
</body>
</html>
