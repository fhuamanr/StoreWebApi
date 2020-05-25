using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StoreWebApi.DTOs
{
    public class MessageDTO
    {
        public string Id { get; set; }
        public string Company { get; set; }
        public string Tenant { get; set; }
        public List<UnitsDTO> Units { get; set; }
        public ShippingInfoDTO ShippingInfo { get; set; }

    }
}
