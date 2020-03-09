using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentAspNetCoreWebApplication.Controllers
{
    public class ResponseMessage
    {
        public ResponseMessage(Object customObject)
        {
            this.request = customObject;
            this.serviceMessage = new ServiceMessage();
        }

        public ServiceMessage serviceMessage { get; set; }
        public Object request { get; set; }

       
    }

    public class ServiceMessage
    {
        public int code { get; set; }

        public String _message;
        public String message {
            get
            {
                return (_message == null) ? "Success" : _message;
            }
            set
            {
                this._message = value;
            }
        }
    }

}
