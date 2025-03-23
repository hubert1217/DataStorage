using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string? input)
        { 
            return String.IsNullOrWhiteSpace(input);
        }

        public static bool IsNullOrEmpty(this string? input)
        {
            return String.IsNullOrEmpty(input);
        }
    }
}
