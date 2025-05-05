using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.DataTransfer.Response
{
    public record ReadingResponseDto(
        int Id,
        DateTime Date,
        decimal Value,
        string Type,
        string Unit,
        string SerialNumber);
}