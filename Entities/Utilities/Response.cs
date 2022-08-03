using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Utilities
{
    public class Response
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }

        public Response()
        {
            IsValid = true;
            Message = "Valid";
        }

        public void SetError(string message)
        {
            IsValid = false;
            Message = message;
        }
    }
}
