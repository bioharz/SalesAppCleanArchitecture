using System.Threading.Tasks;
using CleanArchitecture.Application.ArticleItems.Queries.GetRevenueGroupedByArticles;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    //[Authorize]
    public class GetRevenueGroupedByArticlesController : ApiController
    {
        [HttpGet()]
        public async Task<ActionResult<RevenueArticleVm>> GetRevenueGroupedByArticles()
        {
            return await Mediator.Send(new GetRevenueGroupedByArticlesQuery());
        }
    }
}