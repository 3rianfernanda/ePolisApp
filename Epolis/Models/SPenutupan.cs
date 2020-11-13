using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    public class SPenutupan
    {
        public int ID { get; set; }
        public Tpenutupan penutupan { get; set; }
        public Tcatatan tcatatan { get; set; }
        public Tpenutupandetil tpenutupandetil { get; set; }
        public List<Tpenutupandetil> penutupandetil { get; set; }
        public Tperluasan tperluasan { get; set; }
        public Tpertanggungan tpertanggungan { get; set; }
        public Tkontrakasuransi kontrakasuransi { get; set; }
        public Tnasabah nasabah { get; set; }
        public Mjenisasuransi jenisasuransi { get; set; }
        public Mperusahaanasuransi perusahaanasuransi { get; set; }
        public List<Tdokumen> dokumen { get; set; }
        public List<Tcatatan> catatan { get; set; }
        public Epolis.Models.Tfile tfile { get; set; }
}
}
    