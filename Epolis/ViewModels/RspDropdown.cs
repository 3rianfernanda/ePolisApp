using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.ViewModels
{
    public class RspDropdownList<T>
    {
        public int id { get; set; }
        public string value { get; set; }
        public List<T> data { get; set; }
    }

    public class RspDropdown
    {
        public int id { get; set; }
        public string value { get; set; }
       
    }
    public class ReqDropdown
    {
       
        public string TYPE { get; set; }

    }
}

