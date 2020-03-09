using Dapper;
using InvestmentAspNetCoreWebApplication.DataProvider.Interfaces;
using InvestmentAspNetCoreWebApplication.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace InvestmentAspNetCoreWebApplication.DataProvider
{
    public class IrDataProvider : InvestmentProvider, IIrDataProvider
    {
        public IrDataProvider(IConfiguration configuration) : base(configuration) { }
        
        public async Task<IEnumerable<Ir>> GetIrReferences()
        {
            using (IDbConnection connection = Connection)
            {
                String sQuery = "select * from IRReference";
                var result = await connection.QueryAsync<Ir>(sQuery);
                return result;
            }

            
        }
    }
}
