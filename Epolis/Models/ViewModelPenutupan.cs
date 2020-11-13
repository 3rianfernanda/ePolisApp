using Epolis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    public class ViewModelPenutupan
    {
        public Tnasabah Tnasabah { get; set; }
        public Tpenutupan Tpenutupan { get; set; }
        public Tkontrakasuransi Tkontrakasuransi { get; set; }
        public Mjenisasuransi Mjenisasuransi { get; set; }
        public Mlookup Mlookup { get; set; }
        public Tpenutupandetil Tpenutupandetil { get; set; }
        public Tfile Tfile { get; set; }
        public Tcatatan Tcatatan { get; set; }
        public List<Tcatatan> Tcatatans { get; set; }
        public Toperator Toperator { get; set; }
        public Tbroker Tbroker { get; set; }
    }
}
