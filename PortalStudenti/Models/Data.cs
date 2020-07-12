using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class Data
    {
        public string ColumnName = "";
        public int Value = 0;

        public Data(string columnName, int value)
        {
            ColumnName = columnName;
            Value = value;
        }
    }
}