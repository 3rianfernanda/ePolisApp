using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.Models
{
    [Table("MUNIT")]
    public partial class Munit
    {
        public int ID { get; set; }
        public string UNITCODE { get; set; }
        public string UNITNAME { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public string TELEPON { get; set; }
        public bool? ISACTIVE { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
        public DateTime? CREATEDTIME { get; set; }

    }
}
