using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    public class AllrelationVm
    {
        public Tpenutupan Tpenutupan { get; set; }
        public Tcatatan Tcatatan { get; set; }
        public Mjenisasuransi Mjenisasuransi { get; set; }
        public Tfile Tfile { get; set; }
        public Mperusahaanasuransi Mperusahaanasuransi { get; set; }
        public Tkontrakasuransi Tkontrakasuransi { get; set; }
        public Tpenutupandetil Tpenutupandetil { get; set; }
        public Tperluasan Tperluasan { get; set; }
        public Tnasabah Tnasabah { get; set; }
        public Mokupasi Mokupasi { get; set; }
        public Mlookup Mlookup { get; set; }
        public Tbroker Tbroker { get; set; }
        public Tpertanggungan Tpertanggungan { get; set; }
        public List<Tpenutupandetil> Tpenutupandetils { get; set; }
        public List<Tperluasan> Tperluasans { get; set; }
        public List<Tpertanggungan> Tpertanggungans { get; set; }
        public List<Tcatatan> Tcatatans { get; set; }
    }
}
