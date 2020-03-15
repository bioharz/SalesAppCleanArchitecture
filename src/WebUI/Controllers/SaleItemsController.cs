using System.Threading.Tasks;
using CleanArchitecture.Application.SaleItems.Commands.CreateSaleItem;
using CleanArchitecture.Application.SaleItems.Queries.GetSales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    [Authorize]
    public class SaleItemsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateSaleItemCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpGet]
        public async Task<ActionResult<SalesVm>> Get()
        {
            return await Mediator.Send(new GetSalesQuery());
        }
        
    }
}
