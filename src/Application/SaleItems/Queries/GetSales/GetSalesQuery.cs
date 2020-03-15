using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.SaleItems.Queries.GetSales
{
    public class GetSalesQuery : IRequest<SalesVm>
    {
        public class GetSalesQueryHandler : IRequestHandler<GetSalesQuery, SalesVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetSalesQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SalesVm> Handle(GetSalesQuery request, CancellationToken cancellationToken)
            {
                var vm = new SalesVm
                {
                    Lists = await _context.SaleItems
                        .ProjectTo<SaleItemDto>(_mapper.ConfigurationProvider)
                        .OrderBy(t => t.ArticleNumber)
                        .ToListAsync(cancellationToken)
                };


                return vm;
            }
        }
    }
}