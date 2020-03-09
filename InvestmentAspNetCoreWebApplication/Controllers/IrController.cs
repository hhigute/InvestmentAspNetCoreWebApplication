using InvestmentAspNetCoreWebApplication.DataProvider;
using InvestmentAspNetCoreWebApplication.DataProvider.Interfaces;
using InvestmentAspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentAspNetCoreWebApplication.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class IrController: ControllerBase
    {
        IIrDataProvider _irDataProvider;

        public IrController(IIrDataProvider irDataProvider)
        {
            this._irDataProvider = irDataProvider;
        }


        [HttpGet]
        public async Task<IEnumerable<Ir>> GetIrReferences()
        {
            return await _irDataProvider.GetIrReferences();
        }

    }
}
