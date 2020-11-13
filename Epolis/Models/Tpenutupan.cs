using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.Models
{
    [Table("TPENUTUPAN")]
    public class Tpenutupan
    {
        
        public int ID { get; set; }

        [Display(Name = "Nama Debitur")]
        public int? tnasabahID { get; set; }

        [Display(Name = "Ditutup Asuransi?")]
        public string JENISPENUTUPAN { get; set; }

        [Display(Name = "Kondisi Polis")]
        public int? ISUPDATEPENUTUPANRENEWAL { get; set; }

        [Display(Name = "Nomor Surat Order Penutupan")]
        public string NOREGPENUTUPAN { get; set; }

        [Display(Name = "Order Dari Bank (Nama Kota)")]
        public string ORDERDARIKOTA { get; set; }

        [Display(Name = "Tanggal Order")]
        [DataType(DataType.Date)]
        public DateTime? TGLINPUT { get; set; }

        [Display(Name = "Kode Unit")]
        public int? USERUNITBISNISID { get; set; }

        public string CIF { get; set; }

        [Display(Name = "Tanggal Otorisasi")]
        public DateTime? TGLOTORISASI { get; set; }

        [Display(Name = "Status")]
        public int? STATUS { get; set; }

        [Display(Name = "No. Perjanjian Kredit Sebelumnya")]
        public string NOSKK { get; set; }

        [Display(Name = "Tanggal SKK")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? TGLSKK { get; set; }

        [Display(Name = "No. PK")]
        public string NOPK { get; set; }

        [Display(Name = "Banker's Clause")]
        public bool? BANKERSCLAUSE { get; set; }
        [Display(Name = "Pengajuan Angsuran (Berapa kali)")]
        public int? JUMLAHANGSURAN { get; set; }
        [Display(Name = "Periode (Bulan)")]
        public string PERIODEBULAN { get; set; }
        [Display(Name = "Validasi Unit")]
        public bool? VALIDASIUNITBISNIS { get; set; }
        [Display(Name = "Catatan")]
        public string CATATAN { get; set; }
        [Display(Name = "Menggunakan")]
        public bool? ISBROKER { get; set; }
        public int? UPDATEDBYID { get; set; }
        public DateTime? UPDATEDTIME { get; set; }
        public DateTime? CREATEDTIME { get; set; }
        public int? CREATEDBYID { get; set; }
        public bool? ISDELETED { get; set; }
        public int? DELETEDBYID { get; set; }
        public DateTime? DELETEDTIME { get; set; }

        [Display(Name = "No. Perjanjian Kredit Saat Ini")]
        public string NOSKKNOW { get; set; }

        [Display(Name = "Dari")]
        public DateTime? JANGKAWAKTUMULAI { get; set; }

        [Display(Name = "Sampai")]
        public DateTime? JANGKAWAKTUSELESAI { get; set; }

        [Display(Name = "Pembayaran")]
        public string PEMBAYARAN { get; set; }

        public string NOPOLIS { get; set; }

        //[Display(Name = "Nama Pejabat")]
        //public string? NAMAPEJABAT { get; set; }
    }
}

//sekaligus, installment, partial
