using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToRazl.Models
{
    class ItemWebApiResult
    {
        public int statusCode { get; set; }

        public ItemWebApiError error { get; set; }

        public Result result { get;set; }
    }

    class Result
    {
        public int totalCount { get; set; }
        public int resultCount { get; set; }
        public List<ItemWebApiItem> items { get; set; }
    }

    class ItemWebApiItem
    {
        public string ID { get; set; }
    }

    class ItemWebApiError
    {
        public string message { get; set; }
    }
}
