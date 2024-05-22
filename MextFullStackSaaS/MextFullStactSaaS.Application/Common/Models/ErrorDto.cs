using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaaS.Application.Common.Models
{
    public class ErrorDto
    {
        public string PropertyName { get; set; }    
        public List<string> Message { get; set; }

        public ErrorDto(string propertName, List<string> message)
        {
            PropertyName=propertName;   
            Message = message;  
        }
    }
}
