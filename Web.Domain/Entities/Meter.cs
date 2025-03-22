using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Entities
{
    public class Meter
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int TypeId { get; set; }
        public string SerialNumber { get; set; }

        public virtual Address Address { get; set; }
        public virtual MeterType MeterTypes { get; set; }
    }
}
