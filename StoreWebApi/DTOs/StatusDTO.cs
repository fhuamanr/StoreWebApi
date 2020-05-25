using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApi.DTOs
{
    public class StatusDTO
    {
        internal int Id { get; set; }
        internal string MessageId { get; set; }
        public string Status { get; set; }

        public virtual MessageDTO Message { get; set; }
    }
}
