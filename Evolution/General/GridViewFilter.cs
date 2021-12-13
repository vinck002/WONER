using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.General
{
   public class GridViewFilter
    {
        public DataTable dtgUserFilterFilter(string fiter, DataTable dt, string columnas)
        {

            string fieldName = dt.Columns[columnas].ColumnName;
            //string.Concat("[", dt.Columns[columnas].ColumnName, "]");

            dt.DefaultView.Sort = fieldName;

            DataView view;

            view = dt.DefaultView;
            view.RowFilter = string.Empty;

            view.RowFilter = columnas + " = '%" + fiter + "%'";
            dt = view.ToTable();

            return dt;
        }
    }
}
