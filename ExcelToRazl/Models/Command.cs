using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToRazl.Models
{
    class Command
    {
        public CommandType Type { get; set; }
        public string TypeText
        {
            get
            {
                switch(Type)
                {
                    case CommandType.CopyAll:
                        return "CopyAll";
                    case CommandType.CopyHistory:
                        return "CopyHistory";
                    case CommandType.CopyItem:
                        return "CopyItem";
                    case CommandType.CopyVersion:
                        return "CopyVersion";
                    case CommandType.DeleteItem:
                        return "DeleteItem";
                    case CommandType.MoveItem:
                        return "MoveItem";
                    case CommandType.SetFieldValue:
                        return "SetFieldValue";
                    case CommandType.SetPropertyValue:
                        return "SetPropertyValue";
                    default:
                        return "Unknown";
                }
            }
        }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool Recycle { get; set; }
        public bool LightningMode { get; set; }
        public List<string> Include { get; set; }
        public List<string> Exclude { get; set; }
        public Guid ItemId { get; set; }
        public bool Overwrite { get; set; }
        public string NewItemPath { get; set; }
        public string newParentId { get; set; }
        public Guid FieldId { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string LanguageID { get; set; }
        public string VersionNumber { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }
}
