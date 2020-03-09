using Dapper;
using InvestmentAspNetCoreWebApplication.DataProvider.Interfaces;
using InvestmentAspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentAspNetCoreWebApplication.DataProvider
{
    public class RiskLevelDataProvider: InvestmentProvider, IRiskLevelDataProvider
    {

        public RiskLevelDataProvider(IConfiguration configuration) : base(configuration) { }
        public async Task<IEnumerable<RiskLevel>> GetRiskLevels()
        {

            using (IDbConnection conn = Connection)
            {
                var result = await conn.QueryAsync<RiskLevel>("spSelectRiskLevel",
                                                                null,           
                                                                commandType: CommandType.StoredProcedure);
                return result;
            }
            
        }

        public async Task PostRiskLevel(RiskLevel riskLevel)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    var dynamicParamenters = new DynamicParameters();
                    dynamicParamenters.Add("@paramId", riskLevel.id);
                    dynamicParamenters.Add("@paramDescription", riskLevel.description);
                    await conn.ExecuteAsync("dbo.spInsertRiskLevel",
                                            dynamicParamenters,
                                            commandType: CommandType.StoredProcedure);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task PutRiskLevel(RiskLevel riskLevel)
        {
            try {

                using (IDbConnection conn = Connection)
                {

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@paramId", riskLevel.id);
                    parameters.Add("@paramDescription", riskLevel.description);
                    await conn.ExecuteAsync("dbo.spUpdateRiskLevel",
                                            parameters,
                                            commandType: CommandType.StoredProcedure);
                }

            }catch(SqlException ex)
            {
                throw ex;
            }
        }

    }
}
