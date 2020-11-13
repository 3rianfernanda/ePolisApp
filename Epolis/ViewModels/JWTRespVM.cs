using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.ViewModels
{
    public class JWTRespVM
    {
        public int code { get; set; }
        public string message { get; set; }      
        public RspLoginVM data { get; set; }
    }

    public class JWT_Data
    {
        public string jwT_Token { get; set; }
        public string refresh_Token { get; set; }
        public object error { get; set; }
    }

    public class RespMenuSingleVM<T>
    {
        public int code { get; set; }
        public string message { get; set; }

        public T data { get; set; }
    }

    public class RespMenuDataTableVM<T>
    {
        public int recordsTotals { get; set; }
        public List<T> data { get; set; }

    }
}
