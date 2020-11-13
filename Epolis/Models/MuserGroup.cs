using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.Models
{
    [Table("MUSERGROUP")]
    public class MuserGroup
    {
        public int ID { get; set; }
        [Display(Name = "Kode Grup User")]
        [Required(ErrorMessage = "Kode Grup User harus diisi.")]
        public string USERGROUPCODE { get; set; }
        [Display(Name = "Nama Grup User")]
        [Required(ErrorMessage = "Nama Grup User harus diisi.")]
        public string USERGROUPNAME { get; set; }
        [Display(Name = "Deskripsi")]
        public string USERGROUPDESC { get; set; }
        [Display(Name = "Status")]
        //[Required(ErrorMessage = "Status harus diisi.")]
        //public string STATUS { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
        [Display(Name = "ISACTIVE")]
        public Boolean ISACTIVE { get; set; }
    }
}
