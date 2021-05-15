using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace alissatis_proje
{
   public class uyeler
    {
        public string nick { get; set; }
        public string satici { get; set; }
        
        public decimal psfbakiye { get; set; }
        public decimal uyepsfbakiye { get; set; }
        
        public decimal onaylibakiye { get; set; }
        public decimal uyeonaylibakiye { get; set; }

        public decimal saticibakiye { get; set; }

        public decimal siparisfiyat { get; set; }
        public int cmbbox { get; set; }

        public int admincmbbox1 { get; set; }
        public int admincmbbox2 { get; set; }
        public string onaylanacakuye { get; set; }
    }
}
