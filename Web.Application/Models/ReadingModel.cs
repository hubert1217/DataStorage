using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DataTransfer.Response;
using Web.Domain.Entities;

namespace Web.Application.Models
{
    public class ReadingModel
    {
        public int Id { get; set; }
        public int MeterId { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }


        public static List<ReadingModel> ToList(List<Reading> readings) 
        { 
            return readings.Select(r=> new ReadingModel 
            { 
                Id = r.Id,
                MeterId = r.MeterId,
                Date = r.Date,
                Value = r.Value
            }).ToList();
        }

        public static ReadingModel From(Reading reading) 
        {
            return new ReadingModel
            {
                Id = reading.Id,
                MeterId = reading.MeterId,
                Date = reading.Date,
                Value = reading.Value
            };
        }

        public ReadingResponseDto ToResponseDto() 
        {
            return new ReadingResponseDto(
                Id,
                MeterId,
                Date,
                Value);
        }
    }
}
