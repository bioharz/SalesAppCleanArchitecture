using System;
using System.Threading.Tasks;
using CleanArchitecture.Application.SaleItems.Queries.GetNumberOfSoldArticlesPerDay;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    //[Authorize]
    public class GetNumberOfSoldArticlesPerDayController : ApiController
    {
        [HttpGet("{date}")]
        public async Task<ActionResult<int>> GetNumberOfSoldArticlesPerDay(DateTime date)
        {
            return await Mediator.Send(new GetNumberOfSoldArticlesPerDayQuery{Date = date});
        }
    }
}