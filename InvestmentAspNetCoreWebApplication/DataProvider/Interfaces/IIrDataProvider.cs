using InvestmentAspNetCoreWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentAspNetCoreWebApplication.DataProvider.Interfaces
{
    public interface IIrDataProvider
    {
        Task<IEnumerable<Ir>> GetIrReferences();
    }
}
