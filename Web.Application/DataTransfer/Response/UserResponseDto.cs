﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.DataTransfer.Response
{

    //public record UserResponseDto(
    //    int Id,
    //    string Name,
    //    string Surname,
    //    string Description,
    //    string Email);



    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }

    }
}
