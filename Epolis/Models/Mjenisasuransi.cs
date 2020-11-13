using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.Models
{
    [Table("MJENISASURANSI")]
    public class Mjenisasuransi
    {
        public int ID { get; set; }
        [Display(Name = "Kode Jenis Asuransi")]
        [Required(ErrorMessage = "Kode Jenis Asuransi harus diisi")]
        public string KODEJENISASURANSI { get; set; }
        [Display(Name = "Jenis Asuransi")]
        [StringLength(100, MinimumLength = 1)]
        [Required(ErrorMessage = "Jenis Asuransi harus diisi")]
        public string JENISASURANSI { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
    }
}
