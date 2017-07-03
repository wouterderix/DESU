using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using B2D3.Classes;
using System.Data;
using B2D3.GlobalClasses;

namespace B2D3.Classes.CC
{
    [Author("Thom Kemp", "Houdbaarheidsdatum Controleren", Version = 1)]
    public class CheckDateCC
    {
        /// <summary>
        /// Generate DataTable with results from query
        /// </summary>
        /// <returns>DataTable with results from query</returns>
        public DataTable CheckDate()
        {
            CheckDateBC BC = new CheckDateBC();

            return BC.ReturnDates();
        }

        /// <summary>
        /// Delete product with expired ExpirationDate
        /// </summary>
        /// <param name="id">The HistoryID of the product given in the DataTable</param>
        /// <param name="vid">The Version of the product given in the DataTable</param>
        /// <param name="dim">The DimensionID of the product given in the DataTable</param>
        /// <returns></returns>
        public string DeleteProduct(int id, int vid, int dim)
        {
            CheckDateBC BC = new CheckDateBC();

            return BC.DeleteByID(id, vid, dim);
        }

        /// <summary>
        /// Modify ExpirationDate on product with expired ExpirationDate
        /// </summary>
        /// <param name="id">The HistoryID of the product given in the DataTable</param>
        /// <param name="vid">The Version of the product given in the DataTable</param>
        /// <param name="dim">The DimensionID of the product given in the DataTable</param>
        /// <param name="date">The date selected on the datepicker</param>
        /// <returns></returns>
        public string ModifyProduct(int id, int vid, int dim, DateTime date)
        {
            CheckDateBC BC = new CheckDateBC();

            return BC.ModifyByID(id, vid, dim, date);
        }
    }
}