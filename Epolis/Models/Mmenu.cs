using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.Models
{
    [Table("MMENU")]
    public class Mmenu
    {
        public int ID { get; set; }
        [Display(Name = "Urutan No.")]
        public int MENUORDERNO { get; set; }
        [Display(Name = "Grup")]
        public string MENUGROUP { get; set; }
        [Display(Name = "Icon")]
        public string MENUGROUPICON { get; set; }
        [Display(Name = "Sub-Grup")]
        public string MENUSUBGROUP { get; set; }
        [Display(Name = "Sub-Grup Icon")]
        public string MENUSUBGROUPICON { get; set; }
        [Display(Name = "Nama Menu")]
        public string MENUNAME { get; set; }
        [Display(Name = "Icon Menu")]
        public string MENUICON { get; set; }
        [Display(Name = "Path")]
        public string MENUPATH { get; set; }
        [Display(Name = "Nama Parameter")]
        public string MENUPARAMNAME { get; set; }
        [Display(Name = "Nilai Parameter")]
        public string MENUPARAMVALUE { get; set; }
        [Display(Name = "Deskripsi")]
        public string MENUDESC { get; set; }

        public string MENUACTION { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
    }
}
