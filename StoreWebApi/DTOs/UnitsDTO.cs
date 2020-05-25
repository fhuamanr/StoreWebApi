using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApi.DTOs
{
    public class UnitsDTO
    {
        public int Id { get; set; }
        public string MessageId { get; set; }
        public string Imei { get; set; }
        public string SerialNumber { get; set; }
        public string Stock { get; set; }
        public string Model { get; set; }
        public string Warehouse { get; set; }
        public string RefType { get; set; }
        public string RefId { get; set; }

        //public MessageDTO Message { get; set; }
    }
}
