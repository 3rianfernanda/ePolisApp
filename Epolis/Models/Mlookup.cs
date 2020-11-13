using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    public class Mlookup
    {
        public int ID { get; set; }
        [Display(Name = "Tipe")]
        [Required(ErrorMessage = "Tipe lookup harus diisi")]
        public string TYPE { get; set; }
        [Display(Name = "Nama")]
        [Required(ErrorMessage = "Nama lookup harus diisi")]
        public string NAME { get; set; }
        [Display(Name = "Nilai")]
        [Required(ErrorMessage = "Nilai lookup harus diisi")]
        public string VALUE { get; set; }
        [Display(Name = "Urutan")]
        [Required(ErrorMessage = "Urutan lookup harus diisi")]
        public int? ORDERBY { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }

        public bool? ISACTIVE { get; set; }
    }
}
