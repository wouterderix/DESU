using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.ControlClasses;

public partial class _Occasions_Bewerken : Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //get event information when page gets loaded

    }
    
    protected void btnBewerk_Click(object sender, EventArgs e)
    {
        //edit the currently loaded event

    }
    protected void btnVerwijderen_Click(object sender, EventArgs e)
    {
        //delete the current event ( isDeleted = 1 )

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //cancel the operation and return to main page
        Response.Redirect("~/default.aspx");
    }
}


