<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductToevoegen.aspx.cs" Inherits="B2D3.ProductToevoegen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 350px;
            height: 26px;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Product Toevoegen</h3>
            <br />
        </div>
        <div>
            <table style="width:100%">
                <tr>
                    <th style="width:350px;text-align:left;">Naam Product: </th>
                    <th style="text-align:left;"><asp:TextBox ID="Naam" runat="server" width="540px"></asp:TextBox></th>
                    <th style="text-align:left;"><asp:Label ID="NameControl" runat="server" Visible="False" style="color:red;font-size:small;">Een productnaam moet tussen de 1 en 100 karakters bevatten.</asp:Label></th>
                </tr>
                <tr>
                    <th style="width:350px;text-align:left;vertical-align:top;">Omschrijving: </th>
                    <th style="text-align:left;"><asp:TextBox ID="Omschrijving" runat="server" width="405px"  height="100px" textmode="MultiLine"></asp:TextBox></th>
                    <th style="text-align:left;"><asp:Label ID="OmschrijvingControl" runat="server" Visible="False" style="color:red;font-size:small;">De omschrijving moet tussen de 1 en 5000 karakters bevatten.</asp:Label></th>
                </tr>
                <tr>
                    <th style="width:350px;text-align:left;vertical-align:top;">Handelingsgebieden: </th>
                    <th>
                        <table>
                            <tr>
                                <th style="text-align:left;"><asp:CheckBox ID="Eten_en_Drinken" text="Eten en Drinken" width="200px" runat="server" /></th>
                                <th style="text-align:left;"><asp:CheckBox ID="Huishouden" text="Huishouden" width="200px" runat="server" /></th>
                                <th style="text-align:left;"><asp:CheckBox ID="Veilig_Wonen" text="Veilig Wonen" width="200px" runat="server" /></th>
                            </tr>
                            <tr>
                                <th style="text-align:left;"><asp:CheckBox ID="Wassen_en_Drogen" text="Wassen en Drogen" width="200px" runat="server" /></th>
                                <th style="text-align:left;"><asp:CheckBox ID="Maaltijden_Verzorgen" text="Maaltijden Verzorgen" width="200px" runat="server" /></th>
                                <th style="text-align:left;"><asp:CheckBox ID="Woning_Bedienen" text="Woning Bedienen" width="200px" runat="server" /></th>
                            </tr>
                            <tr>
                                <th style="text-align:left;"><asp:CheckBox ID="Toiletgang" text="Toiletgang" width="200px" runat="server" /></th>
                                <th style="text-align:left;"><asp:CheckBox ID="Boodschappen" text="Boodschappen" width="200px" runat="server" /></th>
                            </tr>
                            <tr>
                                <th style="text-align:left;"><asp:CheckBox ID="Slapen_en_Rust" text="Slapen en Rust" width="200px" runat="server" /></th>
                            </tr>
                            <tr>
                                <th style="text-align:left;"><asp:CheckBox ID="Medicatie" text="Medicatie" width="200px" runat="server" /></th>
                            </tr>
                            <tr>
                                <th><br /></th>
                            </tr>
                            <tr>
                                <th style="text-align:left;"><asp:CheckBox ID="Transfers" text="Transfers" width="200px" runat="server" /></th>
                                <th style="text-align:left;"><asp:CheckBox ID="Communictatie" text="Communictatie" width="200px" runat="server" /></th>
                                <th style="text-align:left;"><asp:CheckBox ID="Vrijetijd_en_Ontspanning" text="Vrijetijd en Ontspanning" width="200px" runat="server" /></th>
                            </tr>
                            <tr>
                                <th style="text-align:left;"><asp:CheckBox ID="Verplaatsen" text="Verplaatsen" width="200px" runat="server" /></th>
                            </tr>
                            <tr>
                                <th><br /></th>
                            </tr>
                            <tr>
                                <th style="text-align:left;"><asp:CheckBox ID="Plannen_en_Organiseren" text="Plannen en Organiseren" width="200px" runat="server" /></th>
                            </tr>
                        </table>
                    </th>
                    <th style="text-align:left;"><asp:Label ID="HandelingControl" runat="server" Visible="False" style="color:red;font-size:small;">Er moet op zijn minst een handelingsgebied aangevinkt zijn.</asp:Label></th>
                </tr>
                <tr>
                    <th style="text-align:left;vertical-align:top;" class="auto-style1">Productcategorie: </th>
                    <th style="text-align:left;" class="auto-style2">
                                    <asp:DropDownList ID="Categorie" runat="server" Width="410px">
                                        <asp:ListItem>Apps en Software</asp:ListItem>
                                        <asp:ListItem>Sociale Robots</asp:ListItem>
                                        <asp:ListItem>Zorg op Afstand en eHealth</asp:ListItem>
                                        <asp:ListItem>Domotica</asp:ListItem>
                                        <asp:ListItem>Huishoudsrobots</asp:ListItem>
                                        <asp:ListItem>Service Robots</asp:ListItem>
                                        <asp:ListItem>Wearables</asp:ListItem>
                                    </asp:DropDownList>
                                </th>
                </tr>
                <tr>
                    <th style="width:350px;text-align:left;vertical-align:top;">Specificaties:<br /><h5>Gelieve de specificaties te scheiden met '-'<br /> bijv: "Test-Test"</h5></th>
                    <th style="text-align:left;"><asp:TextBox ID="Specificaties" runat="server" width="405px"  height="100px"></asp:TextBox></th>
                    <th style="text-align:left;"><asp:Label ID="SpecsControl" runat="server" Visible="False" style="color:red;font-size:small;">De specificaties moeten totaal tussen de 1 en 1000 karakters bevatten.</asp:Label></th>
                </tr>
                <tr>
                    <th style="width:350px;text-align:left;vertical-align:top;">Hanteerbaarheid: </th>
                    <th>
                        <table>
                            <tr>
                                <th style="width:100px;text-align:left;vertical-align:top;">Lengte: </th>
                                <th style="text-align:left;"><asp:TextBox ID="Lengte" runat="server" width="330px"></asp:TextBox></th>
                            </tr>
                            <tr>
                                <th style="width:100px;text-align:left;vertical-align:top;">Breedte: </th>
                                <th style="text-align:left;"><asp:TextBox ID="Breedte" runat="server" width="330px"></asp:TextBox></th>
                            </tr>
                            <tr>
                                <th style="width:100px;text-align:left;vertical-align:top;">Hoogte: </th>
                                <th style="text-align:left;"><asp:TextBox ID="Hoogte" runat="server" width="330px"></asp:TextBox></th>

                            </tr>
                            <tr>
                                <th style="width:100px;text-align:left;vertical-align:top;">Gewicht: </th>
                                <th style="text-align:left;"><asp:TextBox ID="Gewicht" runat="server" width="330px"></asp:TextBox></th>
                            </tr>
                        </table>
                    </th>
                    
                                <th style="text-align:left;">
                                    <asp:Label id="LengteControl" runat="server" Visible="False" style="color:red;font-size:small;">De lengte moet tussen de 1 en 10 cijfers bevatten.</asp:Label>
                                    <br /><br />
                                    <asp:Label id="BreedteControl" runat="server" Visible="False" style="color:red;font-size:small;">De breedte moet tussen de 1 en 10 cijfers bevatten.</asp:Label>
                                    <br /><br />
                                    <asp:Label id="HoogteControl" runat="server" Visible="False" style="color:red;font-size:small;">De hoogte moet tussen de 1 en 10 cijfers bevatten.</asp:Label>
                                    <br /><br />
                                    <asp:Label id="GewichtControl" runat="server" Visible="False" style="color:red;font-size:small;">Het gewicht moet tussen de 1 en 10 cijfers bevatten.</asp:Label>
                                </th>
                </tr>
                <tr>
                    <th style="width:350px;text-align:left;vertical-align:top;">Eisen aan de gebruiker:<br /><h5>Gelieve de eisen te scheiden met '-'<br /> bijv: "Test-Test"</h5></th>
                    <th style="text-align:left;"><asp:TextBox ID="Eisen" runat="server" width="300px"  height="100px"></asp:TextBox></th>
                    <th style="text-align:left;"><asp:Label id="EisenControl" runat="server" Visible="False" style="color:red;font-size:small;">De eisen moeten totaal tussen de 1 en 1000 karakters bevatten.</asp:Label></th>
                </tr>
                <tr>
                    <th style="width:350px;text-align:left;vertical-align:top;">Kosten en Vergoeding: </th>
                    <th>
                        <table>
                            <tr>
                                <th style="width:100px;text-align:left;vertical-align:top;">Kosten: </th>
                                <th style="text-align:left;"><asp:TextBox ID="Kosten" runat="server" width="330px"></asp:TextBox></th>
                            </tr>
                            <tr>
                                <th style="width:100px;text-align:left;vertical-align:top;">Vergoeding: </th>
                                <th style="text-align:left;">
                                    <asp:DropDownList ID="Vergoeding" runat="server" Width="340px">
                                        <asp:ListItem>Vergoeding</asp:ListItem>
                                        <asp:ListItem>Geen Vergoeding</asp:ListItem>
                                    </asp:DropDownList>
                                </th>
                            </tr>
                        </table>
                    </th>
                    <th style="text-align:left;"><asp:Label runat="server" Visible="False" style="color:red;font-size:small;">De kosten moeten tussen de 1 en 10 cijfers bevatten.</asp:Label></th>
                </tr>
                <tr>
                    <th style="width:350px;text-align:left;">Afbeelding:<h5>(Link)</h5></th>
                    <th style="text-align:left;"><asp:TextBox ID="Afbeelding" runat="server" width="540px"></asp:TextBox></th>
                    <th style="text-align:left;"><asp:Label ID="AfbeeldingControl" runat="server" Visible="False" style="color:red;font-size:small;">De link naar de afbeelding moet tussen de 1 en 100 karakters bevatten.</asp:Label></th>
                </tr>
                <tr>
                    <th style="width:350px;text-align:left;">Video:<h5>(Link)</h5></th>
                    <th style="text-align:left;"><asp:TextBox ID="Vid" runat="server" width="540px"></asp:TextBox></th>
                    <th style="text-align:left;"><asp:Label ID="VideoControl" runat="server" Visible="False" style="color:red;font-size:small;">De link naar de video moet tussen de 1 en 100 karakters bevatten.</asp:Label></th>
                </tr>
                <tr>
                    <th style="width:350px;text-align:left;">Beschikbaarheid:<h5>(Link)</h5></th>
                    <th style="text-align:left;"><asp:TextBox ID="Beschikbaarheid" runat="server" width="540px"></asp:TextBox></th>
                    <th style="text-align:left;"><asp:Label ID="BeschikbaarheidControl" runat="server" Visible="False" style="color:red;font-size:small;">De link naar de website moet tussen de 1 en 100 karakters bevatten.</asp:Label></th>
                </tr>
                <tr>
                    <th style="width:350px;text-align:left;">Handleiding:<h5>(Link)</h5></th>
                    <th style="text-align:left;"><asp:TextBox ID="Handleiding" runat="server" width="540px"></asp:TextBox></th>
                    <th style="text-align:left;"><asp:Label ID="HandleidingControl" runat="server" Visible="False" style="color:red;font-size:small;">De link naar de handleiding moet tussen de 1 en 100 karakters bevatten.</asp:Label></th>
                </tr>
            </table>
        </div>
        <div>
            <h3><asp:Button ID="Product_toevoegen" runat="server" Text="Product toevoegen" OnClick="AddProduct_Click" style="width:200px;height:30px;font-size:large;"/>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Terug" />
            </h3>
        </div>
        <div>
            <asp:Label id="Result" runat="server" Visible="False" style="color:red;font-size:small;">Product toegevoegd</asp:Label>
        </div>
    </form>
</body>
</html>

