using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DataTransfer.Response;

namespace Web.Application.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }


        public UserResponseDto ToDto() 
        {
            return new UserResponseDto          
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                Description = Description,
                Email = Email
            };
        }

        //public UserResponseDto ToResponseDto() 
        //{
        //    return new UserResponseDto(Id, Name, Surname, Description, Email);
        //}
    }
}
