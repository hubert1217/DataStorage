using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Base;

namespace Web.Domain.Entities
{
    public class Meter : IBaseEntity
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int TypeId { get; set; }
        public required string SerialNumber { get; set; }
        public required virtual Address Address { get; set; }
        public required virtual MeterType Type { get; set; }
    }
}
