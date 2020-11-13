using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Epolis.Models
{
    public partial class Muser
    {
        public int ID { get; set; }
        [Display(Name = "User Grup ID")]
        public int? MUSERGROUPID { get; set; }
        [Display(Name = "Unit ID")]
        public int? MUNITID { get; set; }
        //public string Npp { get; set; }
        [Display(Name = "User ID")]
        public string USERID { get; set; }
        [Display(Name = "Username")]
        public string USERNAME { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Email")]
        public string Usermail { get; set; }
        public string? NPP { get; set; }
        //public string TempatLahir { get; set; }
        //public DateTime? TanggalLahir { get; set; }
        //public string Alamat { get; set; }
        //public string NoHp { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? LASTONLINE { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? CreatedById { get; set; }           
        //public bool? Ldaplogin { get; set; }

    }
}
