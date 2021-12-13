using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.General
{
    public class ColumnExportModel
    {
        public Int64 Id { get; set; }
        public int FormCode { get; set; }
        public string ColumnName { get; set; }
        public string Description { get; set; }
        public int Visible { get; set; }

        public int ColumnNumber { get; set; }
        public bool DefaultColumns { get; set; }



    }
}
