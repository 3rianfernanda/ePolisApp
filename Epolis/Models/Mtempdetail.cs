using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.Models
{
    [Table("MTEMPDETAIL")]
    public class Mtempdetail
    {
        public int ID { get; set; }      
        public int MTEMPID { get; set; }
        public string NAMAOKUPASI { get; set; }       
        public string KELAS { get; set; }       
        public int RESIKO { get; set; }
        public decimal NILAIOKUPASI { get; set; }
        public string DESKRIPSIPERLUASAN { get; set; }
        public string DESKRIPSIPERTANGGUNGAN { get; set; }
        public decimal NILAIPERTANGGUNGAN { get; set; }
    }
}
