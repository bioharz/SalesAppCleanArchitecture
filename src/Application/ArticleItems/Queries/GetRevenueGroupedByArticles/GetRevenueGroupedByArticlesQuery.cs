using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ArticleItems.Queries.GetRevenueGroupedByArticles
{
    
    public class GetRevenueGroupedByArticlesQuery : IRequest<RevenueArticleVm>
    {

        public class GetRevenueGroupedByArticlesHandler : IRequestHandler<GetRevenueGroupedByArticlesQuery, RevenueArticleVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;


            public GetRevenueGroupedByArticlesHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<RevenueArticleVm> Handle(GetRevenueGroupedByArticlesQuery request,
                CancellationToken cancellationToken = default)
            {
                
                //TODO: calculation should be within the DB, not in business logic!
                
                var dbResults = await _context.ArticleItems
                    .Include(a => a.SaleItems)
                    .ToListAsync(cancellationToken);
                
                var revenueArticleVm = new RevenueArticleVm{RevenueArticles =
                    dbResults.Select(dbResult =>
                        new RevenueArticleDto {
                            ArticleNumber = dbResult.ArticleNumber,
                            RevenueInEuro = dbResult.SaleItems.Sum(sale => sale.SalesPriceInEuro)
                        }).ToList()
                    
                };
                
                return revenueArticleVm;
            }

        }
    }
}