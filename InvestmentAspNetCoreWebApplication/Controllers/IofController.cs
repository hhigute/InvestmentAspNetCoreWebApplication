using InvestmentAspNetCoreWebApplication.DataProvider;
using InvestmentAspNetCoreWebApplication.DataProvider.Interfaces;
using InvestmentAspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace InvestmentAspNetCoreWebApplication.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/[controller]")]

    public class IofController: ControllerBase
    {
        private IIofDataProvider _iofDataProvider;

        public IofController(IIofDataProvider iofDataProvider)
        {
            this._iofDataProvider = iofDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<Iof>> GetIofReferences()
        {
            
            return await _iofDataProvider.GetIofReferences();
            
        }



    }
}
