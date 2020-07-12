using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class Books
    {
       

        public string Month { get; set; }
        public int SalesFigure { get; set; }
        public Books(string month, int salesFigure)
        {
            this.Month = month;
            this.SalesFigure = salesFigure;
        }
    }
}