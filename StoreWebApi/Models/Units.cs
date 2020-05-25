using System;
using System.Collections.Generic;

namespace StoreWebApi.Models
{
    public partial class Units
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

        public Message Message { get; set; }
    }
}
