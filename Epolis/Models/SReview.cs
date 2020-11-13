using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    public class SReview
    {
        public int ID { get; set; }
        public Tpenutupan tpenutupan { get; set; }
        public Tcatatan tcatatan { get; set; }
        public List<Tcatatan> tcatatans { get; set; }
    }
}
