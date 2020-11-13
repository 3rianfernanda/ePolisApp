using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.ViewModels
{
    public class DataTableViewModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string draw { get; set; }
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
        public TableViewModel data { get; set; }
    }

    public class TableViewModel
    { 
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
        public int recordTotals { get; set; }
        public object data { get; set; }
    }

    public class ServiceResult<T>
    {
        public int Code { get; set; } = 1;
        public string Message { get; set; }
        public T Data { get; set; }
    }
    public class ResponseGetData<T, S>
    {
        public S Temp { get; set; }
        public List<T> Tempdetails { get; set; }
    }

    public class TableViewModel<T>
    {
        public int recordTotals { get; set; }
        public IEnumerable<T> data { get; set; }
    }

    public class Datatable<T>
    {
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
    public class GetData
    {
        public int Id { get; set; }
        public string Filter { get; set; }
    }
}
