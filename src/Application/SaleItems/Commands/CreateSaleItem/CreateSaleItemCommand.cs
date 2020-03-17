using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.SaleItems.Queries.GetSales;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.SaleItems.Commands.CreateSaleItem
{
    public class CreateSaleItemCommand : IRequest<SaleItemDto>
    {
        public string ArticleNumber { get; set; }

        public decimal SalesPriceInEuro { get; set; }
        
        public DateTimeOffset? DateTimeOffset { get; set; }

        public class CreateSaleItemCommandHandler : IRequestHandler<CreateSaleItemCommand, SaleItemDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CreateSaleItemCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SaleItemDto> Handle(CreateSaleItemCommand request, CancellationToken cancellationToken = default)
            {

                var articleItemTask = _context.ArticleItems.FindAsync(request.ArticleNumber);
                
                var entity = new SaleItem
                {
                    Id = new Guid(),
                    ArticleItem = await articleItemTask ?? new ArticleItem{ArticleNumber = request.ArticleNumber},
                    SalesPriceInEuro = request.SalesPriceInEuro,
                    DateTimeOffset = request.DateTimeOffset ?? System.DateTimeOffset.Now
                };
                
                _context.SaleItems.Add(entity);
                
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<SaleItemDto>(entity);
            }
        }
    }
}
