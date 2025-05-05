using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Base;

namespace Web.Domain.Entities
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Description { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }


        public static User Create(string firstName, string lastName, string? description, string email) 
        {
            return new User
            {
                FirstName = firstName,
                LastName = lastName,
                Description = description,
                Email = email,
            };
        }

        public static User Update(int id, string firstName, string lastName, string? description, string email)
        {
            return new User
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Description = description,
                Email = email,
            };
        }

    }
}
