using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Base;

namespace Web.Domain.Entities
{
    public class Reading : IBaseEntity
    {
        public int Id { get; set; }
        public int MeterId { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }

        public virtual Meter Meter { get; set; }
    }
}
