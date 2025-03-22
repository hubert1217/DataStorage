using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Entities
{
    public class Reading
    {
        public int Id { get; set; }
        public string MeterId { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }

        public virtual Meter Meter { get; set; }
    }
}
