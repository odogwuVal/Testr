using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testr.Domain.DTOs
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Payload { get; set; }
    }
}
