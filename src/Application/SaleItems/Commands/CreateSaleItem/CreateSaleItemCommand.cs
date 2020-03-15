using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.SaleItems.Commands.CreateSaleItem
{
    public class CreateSaleItemCommand : IRequest<string>
    {
        public string ArticleNumber { get; set; }

        public decimal SalesPriceInEuro { get; set; }

        public class CreateSaleItemCommandHandler : IRequestHandler<CreateSaleItemCommand, string>
        {
            private readonly IApplicationDbContext _context;

            public CreateSaleItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(CreateSaleItemCommand request, CancellationToken cancellationToken)
            {
                var entity = new SaleItem
                {
                    ArticleNumber = request.ArticleNumber,
                    SalesPriceInEuro = request.SalesPriceInEuro
                };

                _context.SaleItems.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.ArticleNumber;
            }
        }
    }
}
