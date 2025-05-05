using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Base;

namespace Web.Domain.Entities
{
    public class Address : IBaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        public required virtual User User { get; set; }
    }
}
