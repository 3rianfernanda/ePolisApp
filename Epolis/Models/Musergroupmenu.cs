using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.Models
{
    [Table("MUSERGROUPMENU")]
    public class Musergroupmenu
    {
        public int ID { get; set; }
        public int MMENUID { get; set; }
        public int MUSERGROUPID { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
        public int? ISACTIVED { get; set; }
    }
}
