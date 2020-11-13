using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    [Table("TPERTANGGUNGAN")]
    public class Tpertanggungan
    {
        public int ID { get; set; }
        public int? tpenutupandetilID { get; set; }
       
        public string KODEPERTANGGUNGAN { get; set; }
       
        public string DESKRIPSI { get; set; }

        public decimal RATEPERTANGGUNGAN { get; set; }

        public string RESIKO { get; set; }

        public decimal NILAIPERTANGGUNGAN { get; set; }


        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
        public int? ISACTIVED { get; set; }
        public int? TPENUTUPANDETILID { get; set; }
    }
}
