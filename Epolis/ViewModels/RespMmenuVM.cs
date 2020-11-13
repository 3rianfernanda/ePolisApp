using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epolis.ViewModels
{

    public class RespMmenuVM
    {
        public int MUSERGROUPID { get; set; }
        public int MENUORDERNO { get; set; }

        public string MENUGROUP { get; set; }

        public string MENUGROUPICON { get; set; }

        public string MENUSUBGROUP { get; set; }

        public string MENUSUBGROUPICON { get; set; }

        public string MENUNAME { get; set; }

        public string MENUICON { get; set; }

        public string MENUPATH { get; set; }
        public string MENUVIEW { get; set; }
        public string MENUCONTROLLER { get; set; }
        public string MENUPARAMNAME { get; set; }

        public string MENUPARAMVALUE { get; set; }


    }
}
