using System;
using System.Collections.Generic;

namespace StoreWebApi.Models
{
    public partial class StatusTk
    {
        public int Id { get; set; }
        public string MessageId { get; set; }
        public string Status { get; set; }

        public Message Message { get; set; }
    }
}
