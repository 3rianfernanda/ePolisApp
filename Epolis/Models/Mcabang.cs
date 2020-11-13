using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    public class Mcabang
    {
        public int ID { get; set; }
        [Display(Name = "Kode Cabang")]
        [Required(ErrorMessage = "Kode Cabang harus diisi")]
        public string KODECABANG { get; set; }
        [Display(Name = "Nama Cabang")]
        [Required(ErrorMessage = "Nama Cabang harus diisi")]
        public string NAMACABANG { get; set; }
        [Display(Name = "Alamat")]
        [Required(ErrorMessage = "Alamat Cabang harus diisi")]
        public string ALAMATCABANG { get; set; }
        [Display(Name = "Kota Cabang")]
        //[Required(ErrorMessage = "Kota harus diisi")]
        public string KOTACABANG { get; set; }
        [Display(Name = "Kode ZIP")]
        //[Required(ErrorMessage = "Kode ZIP harus diisi")]
        public string KODEZIPCABANG { get; set; }
        [Display(Name = "PIC Cabang")]
        //[Required(ErrorMessage = "PIC Cabang harus diisi")]
        public string PICCABANG { get; set; }
        [Display(Name = "Email")]
        //[Required(ErrorMessage = "Email Cabang harus diisi")]
        public string EMAILCABANG { get; set; }
        [Display(Name = "Telepon")]
        [Required(ErrorMessage = "Telepon Cabang harus diisi")]
        public string TELEPONCABANG { get; set; }
        [Display(Name = "Head Office")]
        public int? ISHEADOFFICE { get; set; }

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
