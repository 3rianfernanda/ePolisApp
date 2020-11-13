using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    public class ViewModel
    {
        public Mokupasi okupasi { get; set; }
        public Msysparam sysparam { get; set; }
        public Mpertanggungan pertanggungan { get; set; }

        public Mperluasan perluasan { get; set; }
        public Mjenisasuransi jenisasuransi { get; set; }
        public Mperusahaanasuransi perusahaanasuransi { get; set; }
        public Munit unit{ get; set; }
        public MuserGroup grup { get; set; }
        public Tkontrakasuransi kontrak { get; set; }
        public Muser user { get; set; }
        public Mlookup lookup { get; set; }
    }
}
