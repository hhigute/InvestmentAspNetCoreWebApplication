using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace InvestmentAspNetCoreWebApplication.DataProvider
{
    
    public class InvestmentProvider
    {
        private readonly IConfiguration _configuration;

        public InvestmentProvider(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("InvestmentConnection"));
            }
        }

        public Message ServiceMessage()
        {
            return new Message();
        }
    }

    public class Message 
    {
        public int code { get; set; }
        public String message { get; set; }
    }
}
