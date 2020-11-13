using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    [Table("TPENUTUPANDETIL")]
    public class Tpenutupandetil
    {
        public int ID { get; set; }

        [Display(Name = "ID")]
        public int TPENUTUPANID { get; set; }

        [Display(Name = "Kontrak Asuransi")]
        public int TKONTRAKASURANSIID { get; set; }

        [Display(Name = "Nama Objek Tertanggung")]
        public string NAMATERTANGGUNG { get; set; }

        [Display(Name = "Lokasi Objek")]
        public string LOKASIOBJEKTERTANGGUNG { get; set; }

        [Display(Name = "Valuta")]
        public string MATAUANG { get; set; }

        [Display(Name = "Nilai Pertanggungan")]
        public decimal JUMLAHPERTANGGUNGAN { get; set; }

        [Display(Name = "Tanggal Mulai")]
        public DateTime TANGGALMULAI { get; set; }

        [Display(Name = "Tanggal Akhir")]
        public DateTime TANGGALAKHIR { get; set; }
        [Display(Name = "Nilai Taksasi")]
        public decimal TAKSASI { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
        public string NAMAOKUPASI  { get; set; }
        [Display(Name = "Kelas Konstruksi")]
        public int KELAS { get; set; }
    }
}
