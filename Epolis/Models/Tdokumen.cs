using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    public class Tdokumen
    {
        public int ID { get; set; }

        [Display(Name = "Nama Dokumen")]
        public string NAMADOKUMEN { get; set; }
        public string NAMAGENDOKUMEN { get; set; }
        public string DOKUMENUNTUK { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
    }
}
