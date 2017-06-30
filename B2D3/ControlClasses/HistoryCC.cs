using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using B2D3.Classes;
using System.Data;
using B2D3.GlobalClasses;

namespace B2D3.Classes.CC
{
    [Author("Yannic van de kuit & Ramon Cremers", "Audit Log", Version = 1.0f)]
    public class HistoryCC
    {

        public DataSet GetData(DateTime StartDate)
        {
            HistoryBU BU = new HistoryBU();
            return BU.ReturnData(StartDate);
        }
    }
}