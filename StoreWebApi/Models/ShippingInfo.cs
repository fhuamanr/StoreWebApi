using System;
using System.Collections.Generic;

namespace StoreWebApi.Models
{
    public partial class ShippingInfo
    {
        public int Id { get; set; }
        public string MessageId { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Rut { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Vin { get; set; }
        public string Patente { get; set; }
        public string Poliza { get; set; }
        public DateTime? FechaEmision { get; set; }

        public Message Message { get; set; }
    }
}
