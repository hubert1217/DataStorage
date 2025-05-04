using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Base;

namespace Web.Domain.Entities
{
    public class MeterType : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    }
}
