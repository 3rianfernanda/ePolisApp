using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    [Table("MSYSPARAM")]
    public class Msysparam
    {
        public int ID { get; set; }
        [Display(Name = "Kode Parameter")]
        [Required(ErrorMessage = "Kode Parameter harus diisi")]
        public string PARAMCODE { get; set; }
        [Display(Name = "Nama Parameter")]
        [Required(ErrorMessage = "Nama Parameter harus diisi")]
        public string PARAMNAME { get; set; }
        [Display(Name = "Nilai Parameter")]
        [Required(ErrorMessage = "Nilai Parameter harus diisi")]
        public string PARAMVALUE { get; set; }
        [Display(Name = "Deskripsi")]
        public string PARAMDESC { get; set; }
        public string ISMASKED { get; set; }
        [Display(Name = "Grup")]
        [Required(ErrorMessage = "Grup Parameter harus diisi")]
        public string PARAMGROUP { get; set; }
        [Display(Name = "Urutan")]
        [Required(ErrorMessage = "Urutan Parameter harus diisi")]
        public int ORDERNO { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
        [Display(Name = "ISACTIVE")]
        public Boolean ISACTIVED { get; set; }
    }
}
