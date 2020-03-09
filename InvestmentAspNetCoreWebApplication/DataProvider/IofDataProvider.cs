using Dapper;
using InvestmentAspNetCoreWebApplication.DataProvider.Interfaces;
using InvestmentAspNetCoreWebApplication.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace InvestmentAspNetCoreWebApplication.DataProvider
{
    public class IofDataProvider : InvestmentProvider, IIofDataProvider
    {
        public IofDataProvider(IConfiguration configuration) : base(configuration) { }
        
        public async Task<IEnumerable<Iof>> GetIofReferences()
        {
            using (IDbConnection conn = Connection)
            {

                string sQuery = "select * from IofRference";
                var result = await conn.QueryAsync<Iof>(sQuery);
                return result;

            }
        }
    }
}
