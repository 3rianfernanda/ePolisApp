using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Epolis.Models;

namespace Epolis.Models
{
    [Table("TKONTRAKASURANSI")]
    public class Tkontrakasuransi
    {
        public int ID { get; set; }
        [Display(Name = "Perusahaan Asuransi")]
        public int MPERUSAHAANASURANSIID { get; set; }
        [Display(Name = "Jenis Asuransi")]
        public int MJENISASURANSIID { get; set; }
        [Display(Name = "Okupasi")]
        public int MOKUPASIID { get; set; }
        [Display(Name = "Kelas 1")]
        public decimal STDKELAS1 { get; set; }
        [Display(Name = "Kelas 2")]
        public decimal STDKELAS2 { get; set; }
        [Display(Name = "Resiko")]
        public int RESIKO { get; set; }
        [Display(Name = "Tanggal Mulai")]
        public DateTime TANGGALMULAI { get; set; }
        [Display(Name = "Tanggal Selesai")]
        public DateTime TANGGALSELESAI { get; set; }

        public decimal NOMINALCBC { get; set; }
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
