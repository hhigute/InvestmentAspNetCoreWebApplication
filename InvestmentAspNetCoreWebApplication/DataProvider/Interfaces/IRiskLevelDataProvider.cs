using InvestmentAspNetCoreWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentAspNetCoreWebApplication.DataProvider.Interfaces
{
    public interface IRiskLevelDataProvider
    {

        Task<IEnumerable<RiskLevel>> GetRiskLevels();

        Task PostRiskLevel(RiskLevel riskLevel);

        Task PutRiskLevel(RiskLevel riskLevel);

    }
}
