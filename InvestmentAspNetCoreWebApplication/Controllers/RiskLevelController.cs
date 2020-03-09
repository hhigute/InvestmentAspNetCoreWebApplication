using InvestmentAspNetCoreWebApplication.DataProvider.Interfaces;
using InvestmentAspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InvestmentAspNetCoreWebApplication.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/[controller]")]
    public class RiskLevelController: ControllerBase
    {

        IRiskLevelDataProvider _riskLevelDataProvider;
        
        public RiskLevelController(IRiskLevelDataProvider riskLevel)
        {
            this._riskLevelDataProvider = riskLevel;
        }

        [HttpGet]
        public async Task<IEnumerable<RiskLevel>> GetRiskLevels()
        {
            return await _riskLevelDataProvider.GetRiskLevels();
        }


        [HttpPost]
        public async Task<ResponseMessage> PostRiskLevel([FromBody]RiskLevel riskLevel)
        {
            ResponseMessage response = new ResponseMessage(riskLevel);

            try
            {
                await _riskLevelDataProvider.PostRiskLevel(riskLevel);

            }catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.serviceMessage.code = -1;
                response.serviceMessage.message = ex.Message;
            }

            return response;
        }


        [HttpPut]
        public async Task<ResponseMessage> PutRiskLevel([FromBody]RiskLevel riskLevel)
        {
            ResponseMessage response = new ResponseMessage(riskLevel);

            try
            {
                await _riskLevelDataProvider.PutRiskLevel(riskLevel);

            }catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.serviceMessage.code = -1;
                response.serviceMessage.message = ex.Message;
            }

            return response;
        }

    }
}
