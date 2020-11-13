using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.Models
{
    [Table("MPERUSAHAANASURANSI")]
    public class Mperusahaanasuransi
    {
        public int ID { get; set; }
        [Display(Name = "Kode Perusahaan")]
        [Required(ErrorMessage = "Kode Perusahaan harus diisi.")]
        public string KODEPERUSAHAAN { get; set; }
        [Display(Name = "Nama Perusahaan")]
        [Required(ErrorMessage = "Nama Perusahaan harus diisi.")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Nama Perusahaan harus kurang dari 40 Karakter.")]
        public string NAMAPERUSAHAAN { get; set; }
        [Display(Name = "Alamat")]
        //[Required(ErrorMessage = "Alamat harus diisi.")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Alamat harus kurang dari 200 Karakter.")]
        public string ALAMAT { get; set; }
        [Display(Name = "No. Tlp")]
        //[Required(ErrorMessage = "Nomor Telepon harus diisi.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Nomor Telepon harus kurang dari 20 Karakter.")]
        public string NOTLP { get; set; }
        [Display(Name = "No. Fax")]
        //[Required(ErrorMessage = "Nomor Fax harus diisi.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Nomor Fax harus kurang dari 20 Karakter.")]
        public string NOFAX { get; set; }
        [Display(Name = "Contact Person")]
        //[Required(ErrorMessage = "Contact Person harus diisi.")]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "Contact Person harus kurang dari 35 Karakter.")]
        public string CONTACTPERSON { get; set; }
        [Display(Name = "Email")]
        //[Required(ErrorMessage = "Email harus diisi.")]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "Email harus kurang dari 35 Karakter.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail tidak valid")]
        public string EMAIL { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
    }
}
