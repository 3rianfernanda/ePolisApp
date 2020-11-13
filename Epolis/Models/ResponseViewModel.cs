using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.ViewModels
{
    public class ResponseViewModel<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }

    public class ResponseListViewModel<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<T> data { get; set; }
    }
}
