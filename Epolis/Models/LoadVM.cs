using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.ViewModels
{
    public class LoadVM
    {
        public string Column { get; set; }
        public string Filter { get; set; }
        public string Orderby { get; set; }
        public int Firstrow { get; set; }
        public int Secondrow { get; set; }
    }
}
