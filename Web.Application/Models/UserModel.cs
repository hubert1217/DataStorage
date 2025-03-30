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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }


        public UserResponseDto ToDto() 
        {
            return new UserResponseDto          
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Description = Description,
                Email = Email
            };
        }

        public static List<UserModel> ToList(List<User> users) 
        { 
            return users.Select(x => new UserModel 
            { 
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Description = x.Description,
                Email = x.Email

            }).ToList();
        }

        public static UserModel From(User user) 
        {
            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Description = user.Description,
                Email= user.Email
            };
        } 

        //public UserResponseDto ToResponseDto() 
        //{
        //    return new UserResponseDto(Id, Name, Surname, Description, Email);
        //}
    }
}
