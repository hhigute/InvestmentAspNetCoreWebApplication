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
    public class BankDataProvider: InvestmentProvider, IBankDataProvider
    {
        public BankDataProvider(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<Bank>> GetBanks()
        {
            using (IDbConnection conn = Connection)
            {
                String sQuery = "select * from Bank";
                var result = await conn.QueryAsync<Bank>(sQuery);
                return result;

            }
        }


        public async Task PostBank(Bank paramBank)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    await conn.ExecuteAsync(@"Insert into Bank (Code, Name, ContactName, ContactPhone)"
                                       + " values (@code, @name, @contactName, @contactPhone)",
                                       new Bank
                                       {
                                           code = paramBank.code,
                                           name = paramBank.name,
                                           contactName = paramBank.contactName,
                                           contactPhone = paramBank.contactPhone,
                                       });
                }
            }catch(SqlException exception)
            {
                throw exception;
            }
        }


        public async Task DeleteBank(String paramCode)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    await conn.ExecuteAsync(@"delete from Bank where Code = @paramCode",
                                       new {paramCode});
                }
            }
            catch (SqlException exception)
            {
                throw exception;
            }
        }

        public async Task PutBank(Bank bank)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    await conn.ExecuteAsync(@"update bank "
                                            + " set " 
                                            + " Name = @name,"
                                            + " ContactName = @contactName,"
                                            + " ContactPhone = @contactPhone "
                                            + " where "
                                            + " Code = @code",
                                            new Bank { 
                                                code = bank.code,
                                                name = bank.name,
                                                contactName = bank.contactName,
                                                contactPhone = bank.contactPhone
                                            });
                }
            }catch(Exception exception)
            {
                throw exception;
            }
        }

    }
}
