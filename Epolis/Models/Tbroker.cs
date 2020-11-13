using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    [Table("TBROKER")]
    public class Tbroker
    {
        public int ID { get; set; }
        public int MBROKERID { get; set; }
        public int MPERUSAHAANASURANSIID { get; set; }
        public int MJENISASURANSIID { get; set; }
        public int MOKUPASIID { get; set; }

        [Display(Name = "Nama Broker")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Nama asuradur harus kurang dari 40 Karakter.")]
        [Required(ErrorMessage = "Nama Broker harus diisi.")]
        public string NAMABROKER { get; set; }
        [Display(Name = "Alamat Broker")]
        [StringLength(500)]
        public string ALAMATBROKER { get; set; }
        [Display(Name = "e-mail Broker")]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "e-mail harus kurang dari 35 Karakter.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail tidak valid")]
        public string EMAILBROKER { get; set; }
        [Display(Name = "Telepon Broker")]
        [StringLength(20, MinimumLength = 1)]
        public string TELEPONBROKER { get; set; }
        
        [Display(Name = "Nama Asuradur")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Nama asuradur harus kurang dari 40 Karakter.")]
        public string NAMAASURADUR { get; set; }
        [Display(Name = "Alamat Asuradur")]
        public string ALAMATASURADUR { get; set; }
        [Display(Name = "e-mail Asuradur")]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "e-mail harus kurang dari 35 Karakter.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail tidak valid")]
        public string EMAILASURADUR { get; set; }
        [Display(Name = "Telepon Asuradur")]
        public string TELEPONASURADUR { get; set; }
        [Display(Name = "Contact Person Asuradur")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Contact Person harus kurang dari 20 Karakter.")]
        public string CONTACTPERSONASURADUR { get; set; }
        [Display(Name = "MINIMUM CBC")]
        public decimal NOMINALCBC { get; set; }

        public int? RESIKO { get; set; }
        public DateTime? TANGGALMULAI { get; set; }
        public DateTime? TANGGALSELESAI { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
        public bool? ISACTIVED { get; set; }
    }
}
