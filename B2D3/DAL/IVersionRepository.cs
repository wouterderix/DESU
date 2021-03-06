﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.DAL
{
    public interface IVersionRepository<T> where T : Classes.History
    {
        IEnumerable<T> GetAllLatest();
        T FindLatestByID(int historyID);
        Tid GetNextID<Tid>() where Tid : struct;
        Tid GetNextVersion<Tid>(T history) where Tid : struct;
    }
}