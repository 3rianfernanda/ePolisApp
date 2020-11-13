using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.ViewModels
{
    public class RspLoginVM
    {

        public int ID { get; set; }
        public string USERID { get; set; }
        public string USERNAME { get; set; }
        public Boolean ISACTIVE { get; set; }
        public Boolean ISLOGIN { get; set; }
        public string UNITCODE { get; set; }
        public string UNITNAME { get; set; }
        public int MUSERGROUPID { get; set; }
        public string USERGROUPCODE { get; set; }
        public string USERGROUPNAME { get; set; }
        public string KODECABANG { get; set; }
        public string NAMACABANG { get; set; }
        public string KOTACABANG { get; set; }
        public string TOKEN { get; set; }
    }
}
