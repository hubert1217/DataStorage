﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.DataTransfer.Response
{
    public record UserResponseDto(
        int Id,
        string FirstName,
        string LastName,
        string? Description,
        string Email);
}
