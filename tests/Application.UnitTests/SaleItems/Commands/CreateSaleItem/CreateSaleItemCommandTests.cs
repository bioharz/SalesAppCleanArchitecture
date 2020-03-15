using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.SaleItems.Commands.CreateSaleItem;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.SaleItems.Commands.CreateSaleItem
{
    public class CreateSaleItemCommandTests : CommandTestBase
    {
        private const string ArticleNumber = "M1Y9rHiEFr28d6bO1x5wGaHiZTkx5aqB";
        private const decimal SalesPriceInEuro = 9.33m;
        
        [Fact]
        public async Task Handle_ShouldPersistSaleItem()
        {
            var command = new CreateSaleItemCommand
            {
                ArticleNumber = ArticleNumber,
                SalesPriceInEuro = SalesPriceInEuro
            };

            var handler = new CreateSaleItemCommand.CreateSaleItemCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.SaleItems.Find(result);

            entity.ShouldNotBeNull();
            entity.ArticleNumber.ShouldBe(command.ArticleNumber);
            entity.SalesPriceInEuro.ShouldBe(command.SalesPriceInEuro);
        }
    }
}
