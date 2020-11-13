using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.Models
{
    [Table("TNASABAH")]
    public class Tnasabah
    {
        public int ID { get; set; }
        public string NAMA { get; set; }   
        public string NOREGBANK { get; set; }  
        public string NOFASILITAS { get; set; }     
        public string NOREKENING { get; set; }   
        public string ADMINID { get; set; }     
        public DateTime TGLINPUT { get; set; }     
        public DateTime TGLOTORISASI { get; set; }   
        public string STATUS { get; set; }    
        public string JENISKELAMIN { get; set; }      
        public DateTime TGLLAHIR { get; set; }   
        public string TEMPATLAHIR { get; set; }    
        public string NOTLPRUMAH { get; set; }      
        public string NOHP { get; set; }      
        public string CONTACTPERSON { get; set; }      
        public string PEKERJAAN { get; set; }      
        public string KODEAREA { get; set; }     
        public string NOTLPKANTOR { get; set; }       
        public string NOFAX { get; set; }       
        public string EMAIL { get; set; } 
        public string ALAMAT { get; set; }       
        public string NOURUTFASILITAS { get; set; }     
        public string NOBASE { get; set; }
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
