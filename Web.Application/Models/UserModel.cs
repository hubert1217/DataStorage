using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DataTransfer.Response;
using Web.Domain.Entities;

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

        public static List<UserModel> ToList(List<User> users) 
        { 
            return users.Select(x => new UserModel 
            { 
                Id = x.Id,
                Name = x.FirstName,
                Surname = x.LastName,
                Email = x.Email

            }).ToList();
        }

        public static UserModel From(User user) 
        {
            return new UserModel
            {
                Id = user.Id,
                Name = user.FirstName,
                Surname = user.LastName
            };
        } 

        //public UserResponseDto ToResponseDto() 
        //{
        //    return new UserResponseDto(Id, Name, Surname, Description, Email);
        //}
    }
}
