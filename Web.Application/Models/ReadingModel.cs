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
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public string SerialNumber { get; set; }


        public static List<ReadingModel> ToList(List<Reading> readings) 
        { 
            return readings.Select(r=> new ReadingModel 
            { 
                Id = r.Id,
                Date = r.Date,
                Value = r.Value,
                Type = r.Meter.Type.Name,
                Unit = r.Meter.Type.Unit,
                SerialNumber = r.Meter.SerialNumber,
            }).ToList();
        }

        public static ReadingModel From(Reading reading) 
        {
            return new ReadingModel
            {
                Id = reading.Id,
                Date = reading.Date,
                Value = reading.Value
            };
        }

        public ReadingResponseDto ToResponseDto() 
        {
            return new ReadingResponseDto(
                Id,
                Date,
                Value,
                Type,
                Unit,
                SerialNumber);
        }
    }
}
