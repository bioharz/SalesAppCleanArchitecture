using System.Net;
using System.Threading.Tasks;
using CleanArchitecture.Application.SaleItems.Commands.CreateSaleItem;
using Shouldly;
using Xunit;

namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.SaleItems
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateSaleItemCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateSaleItemCommand
            {
                ArticleNumber = "GMzECR1jyuVOk32pekQeOZsYfMcukhfV",
                SalesPriceInEuro = 18.99m
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync($"/api/saleitems", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidCreateSaleItemCommand_ReturnsBadRequest()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateSaleItemCommand
            {
                ArticleNumber = "This description of this thing will exceed the maximum length. This description of this thing will exceed the maximum length. This description of this thing will exceed the maximum length. This description of this thing will exceed the maximum length.",
                SalesPriceInEuro = 139.66m
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync($"/api/saleitems", content);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }
    }
}
