using B2D3.Classes;
using B2D3.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    [Author("Xavier van Egdom", "Nieuws goedkeuren")]
    public class UpdateNewsCC
    {
        public void UpdateNews(int historyId, int versionId, string title, string description,
            bool approved, int authorId)
        {
            new News().UpdateNews(historyId, versionId, title, description, approved, authorId);
        }
    }
}