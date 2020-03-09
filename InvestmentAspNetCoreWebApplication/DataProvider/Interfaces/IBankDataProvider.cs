using InvestmentAspNetCoreWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentAspNetCoreWebApplication.DataProvider.Interfaces
{
    public interface IBankDataProvider
    {
        Task<IEnumerable<Bank>> GetBanks();

        Task PostBank(Bank bank);

        Task DeleteBank(String code);

        Task PutBank(Bank bank);

    }
}
