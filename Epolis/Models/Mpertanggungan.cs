using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.Models
{
    [Table("MPERTANGGUNGAN")]
    public class Mpertanggungan
    {
        public int ID { get; set; }
        [Display(Name = "Kode Okupasi")]
        [Required(ErrorMessage = "Kode Okupasi harus diisi.")]
        public int MOKUPASIID { get; set; }

        [Display(Name = "Kode Pertanggungan")]
        [Required(ErrorMessage = "Kode Pertanggungan harus diisi.")]
        [StringLength(10, MinimumLength = 1)]
        public string KODEPERTANGGUNGAN { get; set; }
        [Display(Name = "Deskripsi")]
        [Required(ErrorMessage = "Deskripsi harus diisi.")]
        [StringLength(10, MinimumLength = 1)]
        public string DESKRIPSI { get; set; }
        //[Display(Name = "Rate")]
        //[Column(TypeName = "decimal(10,4)")]
        //public decimal RATEPERTANGGUNGAN { get; set; }
        //[Display(Name = "Resiko")]
        //[StringLength(15, MinimumLength = 1)]
        //public string RESIKO { get; set; }

        [StringLength(50, MinimumLength = 0)]
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
    }
}
