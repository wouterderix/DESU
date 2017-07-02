using B2D3.Classes;
using B2D3.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace B2D3.Classes.CC
{
    [Author("Xavier van Egdom", "Nieuws goedkeuren")]
    public class ApprovedNewsCC
    {
        public void ApprovedNews(int historyId, int versionId)
        {
            new News().Approve(historyId, versionId);
        }
    }
}