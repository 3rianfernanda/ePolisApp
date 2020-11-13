using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.Models
{
    [Table("MPERLUASAN")]
    public class Mperluasan
    {
        public int ID { get; set; }
        [Display(Name = "Kode Okupasi")]
        [Required(ErrorMessage = "Kode Okupasi harus diisi.")]
        public int MOKUPASIID { get; set; }
        [Display(Name = "Kode Perluasan")]
        [Required(ErrorMessage = "Kode Perluasan harus diisi.")]
        public string KODEPERLUASAN { get; set; }
        [Display(Name = "Deskripsi")]
        [Required(ErrorMessage = "Deskripsi harus diisi.")]
        public string DESKRIPSI { get; set; }
        [Display(Name = "Rate Perluasan")]
        [Required(ErrorMessage = "Rate Perluasan harus diisi.")]
        public decimal RATEPERLUASAN { get; set; }
        [Display(Name = "Resiko")]
        [Required(ErrorMessage = "Resiko harus diisi.")]
        public int RESIKO { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
    }
}
