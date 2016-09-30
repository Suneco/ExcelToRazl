using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToRazl.Models
{
    enum CommandType
    {
        CopyHistory,
        CopyAll,
        CopyItem,
        CopyVersion,
        DeleteItem,
        MoveItem,
        SetFieldValue,
        SetPropertyValue,
        Unknown
    }
}
