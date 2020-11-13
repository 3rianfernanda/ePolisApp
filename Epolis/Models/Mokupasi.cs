using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.Models
{
    [Table("MOKUPASI")]
    public class Mokupasi
    {
        public int ID { get; set; }
        [Display(Name = "Kode Okupasi")]
        [Required(ErrorMessage = "Kode Okupasi harus diisi.")]
        public string KODEOKUPASI { get; set; }
        [Display(Name = "Nama Okupasi")]
        [Required(ErrorMessage = "Nama Okupasi harus diisi.")]
        public string NAMAOKUPASI { get; set; }
        [Display(Name = "Standar Kelas 1")]
        //[Required(ErrorMessage = "Standar Kelas 1 harus diisi.")]
        public decimal? KELAS1 { get; set; }
        [Display(Name = "Standar Kelas 2")]
        //[Required(ErrorMessage = "Standar Kelas 2 harus diisi.")]
        public decimal? KELAS2 { get; set; }

        [Display(Name = "Standar Kelas 3")]
        //[Required(ErrorMessage = "Standar Kelas 3 harus diisi.")]
        public decimal? KELAS3 { get; set; }

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
