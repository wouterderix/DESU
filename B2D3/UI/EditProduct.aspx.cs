using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;
using B2D3.Classes;
using B2D3.GlobalClasses;

namespace B2D3
{
    public partial class EditProduct : System.Web.UI.Page
    {
        bool ControleBool = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString["HistoryID"] != "" && Request.QueryString["HistoryID"] != null)
            //{
            //    //Get Occasion by HistoryID from link
            //    int history = Convert.ToInt32(Request.QueryString["ID="]);
            //}
        }

        [Author("Wouter Derix", "ProductZoeken", Version = 1)]
        public void AddProduct_Click(object sender, EventArgs e)
        {
            ControlProductDataCC Controle = new ControlProductDataCC();

            var Name = Naam.Text;
            var Description = Omschrijving.Text;
            var Category = Categorie.Text;
            var Specifications = Specificaties.Text;
            var Width = Breedte.Text;
            var Length = Lengte.Text;
            var Height = Hoogte.Text;
            var Weight = Gewicht.Text;
            var Requirements = Eisen.Text;
            var Price = Kosten.Text;
            var Compensation = Vergoeding.Text;
            var Image_1 = Afbeelding.Text;
            var Video = Vid.Text;
            var Availability = Beschikbaarheid.Text;
            var UserManual = Handleiding.Text;

            List<string> ProductGegevens = new List<string>() { Name, Description, Category, Specifications, Length, Width, Height, Weight, Requirements, Price, Compensation, Image_1, Video, Availability, UserManual };

            List<bool> Handelingsgebied_1 = new List<bool>() { Eten_en_Drinken.Checked, Wassen_en_Drogen.Checked, Toiletgang.Checked, Slapen_en_Rust.Checked, Medicatie.Checked, Huishouden.Checked, Maaltijden_Verzorgen.Checked, Boodschappen.Checked, Veilig_Wonen.Checked, Woning_Bedienen.Checked, Transfers.Checked, Verplaatsen.Checked, Communictatie.Checked, Vrijetijd_en_Ontspanning.Checked, Plannen_en_Organiseren.Checked };
            List<string> Handelingsgebied_2 = new List<string>() { Eten_en_Drinken.Text, Wassen_en_Drogen.Text, Toiletgang.Text, Slapen_en_Rust.Text, Medicatie.Text, Huishouden.Text, Maaltijden_Verzorgen.Text, Boodschappen.Text, Veilig_Wonen.Text, Woning_Bedienen.Text, Transfers.Text, Verplaatsen.Text, Communictatie.Text, Vrijetijd_en_Ontspanning.Text, Plannen_en_Organiseren.Text };

            List<string> OperationAreas = new List<string>();

            int i = 0;
            foreach (bool value in Handelingsgebied_1)
            {
                if (value == true)
                {
                    OperationAreas.Add(Handelingsgebied_2[i]);
                }
                i++;
            }

            List<bool> ControlResults = Controle.ControlData(Name, Description, OperationAreas, Specifications, Length, Width, Height, Weight, Requirements, Price, Image_1, Video, Availability, UserManual);
            ControleFeedback(ControlResults);
            if (ControleBool == true)
            {
                string Success = Controle.ConvertData(Name, Description, OperationAreas, Category, Specifications, Length, Width, Height, Weight, Requirements, Price, Compensation, Image_1, Video, Availability, UserManual);
                if (Success == "Product Toegevoegd")
                {
                    Result.Visible = true;
                }
            }
        }

        [Author("Nigel Croese", "ProductZoeken", Version = 1)]
        public void ControleFeedback(List<bool> Results)
        {
            int i = 0;
            ControleBool = true;
            foreach (bool value in Results)
            {
                if (value == true)
                {
                    if (i == 0)
                    {
                        NameControl.Visible = false;
                    }
                    if (i == 1)
                    {
                        OmschrijvingControl.Visible = false;
                    }
                    if (i == 2)
                    {
                        HandelingControl.Visible = false;
                    }
                    if (i == 3)
                    {
                        SpecsControl.Visible = false;
                    }
                    if (i == 4)
                    {
                        LengteControl.Visible = false;
                    }
                    if (i == 5)
                    {
                        BreedteControl.Visible = false;
                    }
                    if (i == 6)
                    {
                        HoogteControl.Visible = false;
                    }
                    if (i == 7)
                    {
                        GewichtControl.Visible = false;
                    }
                    if (i == 8)
                    {
                        EisenControl.Visible = false;
                    }
                    if (i == 9)
                    {
                        HandleidingControl.Visible = false;
                    }
                    if (i == 10)
                    {
                        AfbeeldingControl.Visible = false;
                    }
                    if (i == 11)
                    {
                        VideoControl.Visible = false;
                    }
                    if (i == 12)
                    {
                        BeschikbaarheidControl.Visible = false;
                    }
                    if (i == 13)
                    {
                        HandleidingControl.Visible = false;
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        NameControl.Visible = true;
                    }
                    if (i == 1)
                    {
                        OmschrijvingControl.Visible = true;
                    }
                    if (i == 2)
                    {
                        HandelingControl.Visible = true;
                    }
                    if (i == 3)
                    {
                        SpecsControl.Visible = true;
                    }
                    if (i == 4)
                    {
                        LengteControl.Visible = true;
                    }
                    if (i == 5)
                    {
                        BreedteControl.Visible = true;
                    }
                    if (i == 6)
                    {
                        HoogteControl.Visible = true;
                    }
                    if (i == 7)
                    {
                        GewichtControl.Visible = true;
                    }
                    if (i == 8)
                    {
                        EisenControl.Visible = true;
                    }
                    if (i == 9)
                    {
                        HandleidingControl.Visible = true;
                    }
                    if (i == 10)
                    {
                        AfbeeldingControl.Visible = true;
                    }
                    if (i == 11)
                    {
                        VideoControl.Visible = true;
                    }
                    if (i == 12)
                    {
                        BeschikbaarheidControl.Visible = true;
                    }
                    if (i == 13)
                    {
                        HandleidingControl.Visible = true;
                    }
                    ControleBool = false;
                }
            }
        }
    }
}