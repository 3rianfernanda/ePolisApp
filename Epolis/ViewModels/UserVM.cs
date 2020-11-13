using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.ViewModels
{
    public class UserVM
    {
        public string Username { get; set; }
        public string IpAddress { get; set; }
        public string ClientId { get; set; }
        public string Password { get; set; }
    }
    public class IdUserGroupVM
    {
        public int Id { get; set; }
        public string Orderby { get; set; }
    }
}
