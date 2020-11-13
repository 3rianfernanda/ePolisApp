using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    [Table("MBROKER")]
    public class Mbroker
    {
        public int ID { get; set; }
        [Display(Name = "Kode Broker")]
        [Required(ErrorMessage = "Kode Broker harus diisi.")]
        public string KODEBROKER { get; set; }
        [Display(Name = "Nama Broker")]
        [Required(ErrorMessage = "Nama Broker harus diisi.")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Nama Broker harus kurang dari 40 Karakter.")]
        public string NAMABROKER { get; set; }
        [Display(Name = "Alamat")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Alamat harus kurang dari 200 Karakter.")]
        public string ALAMAT { get; set; }
        [Display(Name = "No. Tlp")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Nomor Telepon harus kurang dari 20 Karakter.")]
        public string NOTLP { get; set; }
        [Display(Name = "No. Fax")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Nomor Fax harus kurang dari 20 Karakter.")]
        public string NOFAX { get; set; }

        [Display(Name = "Contact Person")]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "Contact Person harus kurang dari 35 Karakter.")]
        public string CONTACTPERSON { get; set; }
        [Display(Name = "Email")]
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
    //public class Broker
    //{
    //    public int Id { get; set; }
    //    public Mbroker[] Data { get; set; }
    //}
}
