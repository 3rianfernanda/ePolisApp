using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    [Table("MTEMP")]
    public class Mtemp
    {
        public int ID { get; set; }
        public string NAMA { get; set; }
        public string ORDERKOTA { get; set; }
        public string NAMACABANG { get; set; }
        public string NOSKKPREV { get; set; }
        public string NOSKKNOW { get; set; }
        public DateTime TGLSKK { get; set; }
        public string NOSKK { get; set; }
        public string CIF { get; set; }
        
    }
}
