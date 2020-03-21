using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.SaleItems.Queries.GetNumberOfSoldArticlesPerDay
{
    public class GetNumberOfSoldArticlesPerDayQuery : IRequest<int>
    {
        public DateTime Date { get; set; }

        public class GetNumberOfSoldArticlesPerDayHandler : IRequestHandler<GetNumberOfSoldArticlesPerDayQuery, int>
        {
            private readonly IApplicationDbContext _context;

            public GetNumberOfSoldArticlesPerDayHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(GetNumberOfSoldArticlesPerDayQuery request,
                CancellationToken cancellationToken = default)
                =>
                    // request.Date.Date == s.DateTimeOffset.Date will work with unit tests. But not with MS SQL... 
                    await _context.ArticleItems
                        .SelectMany(a => a.SaleItems)
                        .Where(s => s.DateTimeOffset.Date >= request.Date.Date &&
                                    s.DateTimeOffset.Date <= request.Date.Date.AddSeconds(86400 - 1))
                        .CountAsync(cancellationToken);
        }
    }
}