using System;
using System.Threading.Tasks;
using CleanArchitecture.Application.SaleItems.Queries.GetTotalRevenuePerPay;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    
    //[Authorize]
    public class GetTotalRevenuePerDayController : ApiController
    {
        [HttpGet("{date}")]
        public async Task<ActionResult<decimal>> GetTotalRevenuePerDay(DateTime date)
        {
            return await Mediator.Send(new GetTotalRevenuePerDayQuery{Date = date});
        }
    }
}