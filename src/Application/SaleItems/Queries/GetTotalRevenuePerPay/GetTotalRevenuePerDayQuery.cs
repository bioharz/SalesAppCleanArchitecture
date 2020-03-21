using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.SaleItems.Queries.GetTotalRevenuePerPay
{
    
    public class GetTotalRevenuePerDayQuery : IRequest<decimal>
    {
        public DateTime Date { get; set; }

        public class GetTotalRevenuePerDayHandler : IRequestHandler<GetTotalRevenuePerDayQuery, decimal>
        {
            private readonly IApplicationDbContext _context;

            public GetTotalRevenuePerDayHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<decimal> Handle(GetTotalRevenuePerDayQuery request,
                CancellationToken cancellationToken = default)
                // request.Date.Date == s.DateTimeOffset.Date will work with unit tests. But not with MS SQL... 
                => await _context.SaleItems
                    .Where(s => s.DateTimeOffset.Date >= request.Date.Date && s.DateTimeOffset.Date <= request.Date.Date.AddSeconds(86400-1))
                    .SumAsync(s => s.SalesPriceInEuro, cancellationToken);
            
        }
    }
}