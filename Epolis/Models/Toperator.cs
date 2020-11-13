using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    public class Toperator
    {

        public int ID { get; set; }
        public int? TPENUTUPANID { get; set; }
        public int? INPUTERID { get; set; }
        public DateTime? INPUTERMULAI { get; set; }
        public DateTime? INPUTERSELESAI { get; set; }
        [Display(Name = "Pilih Reviewer")]
        public int? REVIEWERID { get; set; }
        public DateTime? REVIEWERMULAI { get; set; }
        public DateTime? REVIEWERSELESAI { get; set; }
        [Display(Name = "Pilih Approval")]
        public int? APPROVERID { get; set; }
        public DateTime? APPROVERMULAI { get; set; }
        public DateTime? APPROVERSELESAI { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
    }
}
