using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToRazl.Models
{
    class Error
    {
        public int RowNumber { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
