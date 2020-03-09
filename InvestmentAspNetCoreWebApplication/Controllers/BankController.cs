
using InvestmentAspNetCoreWebApplication.DataProvider.Interfaces;
using InvestmentAspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InvestmentAspNetCoreWebApplication.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class BankController: ControllerBase
    {

        IBankDataProvider _bankDataProvider;
        public BankController(IBankDataProvider bankDataProvider)
        {
            this._bankDataProvider = bankDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<Bank>> GetBanks()
        {
            

            return await _bankDataProvider.GetBanks();
        }

        [HttpPost]
        public async Task<ResponseMessage> PostBank([FromBody]Bank bank)
        {
            ResponseMessage responseMessage = new ResponseMessage(bank);

            try
            {
                await _bankDataProvider.PostBank(bank);
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                responseMessage.serviceMessage.code = -1;
                responseMessage.serviceMessage.message = ex.Message;
            }
            return responseMessage;
            
        }

        
        [HttpDelete("{code}")]       
        public async Task<ResponseMessage> DeleteBank(String code)
        {
            ResponseMessage responseMessage = new ResponseMessage(code);

            try
            {
                await _bankDataProvider.DeleteBank(code);

            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                responseMessage.serviceMessage.code = -1;
                responseMessage.serviceMessage.message = ex.Message;
            }

            return responseMessage;
        }

        
        [HttpPut]
        public async Task<ResponseMessage> PutBank([FromBody]Bank bank)
        {
            ResponseMessage responseMessage = new ResponseMessage(bank);

            try
            {
                await _bankDataProvider.PutBank(bank);

            }catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                responseMessage.serviceMessage.code = -1;
                responseMessage.serviceMessage.message = ex.Message;
            }


            return responseMessage;
        }
       
    }
}
