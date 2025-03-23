using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.DataTransfer.Request
{
    public class UserRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
