using System;
using System.Collections.Generic;

namespace StoreWebApi.Models
{
    public partial class Message
    {
        public Message()
        {
            Units = new HashSet<Units>();
        }

        public string Id { get; set; }
        public string Company { get; set; }
        public string Tenant { get; set; }

        public ShippingInfo ShippingInfo { get; set; }
        public StatusTk StatusTk { get; set; }
        public ICollection<Units> Units { get; set; }
    }
}
