using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.SaleItems.Commands.CreateSaleItem;
using CleanArchitecture.Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.SaleItems.Commands.CreateSaleItem
{
    [Collection("QueryTests")]
    public class CreateSaleItemCommandTests : CommandTestBase
    {
        private const string ArticleNumber = "M1Y9rHiEFr28d6bO1x5wGaHiZTkx5aqB";
        private const decimal SalesPriceInEuro = 9.33m;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateSaleItemCommandTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ShouldPersistSaleItem()
        {
            var command = new CreateSaleItemCommand
            {
                ArticleNumber = ArticleNumber,
                SalesPriceInEuro = SalesPriceInEuro,
            };

            var handler = new CreateSaleItemCommand.CreateSaleItemCommandHandler(_context, _mapper);

            var result = await handler.Handle(command);

            var entity = _context.SaleItems.Find(result.id);

            entity.ShouldNotBeNull();
            entity.ArticleItem.ArticleNumber.ShouldBe(command.ArticleNumber);
            entity.SalesPriceInEuro.ShouldBe(command.SalesPriceInEuro);
        }
    }
}
