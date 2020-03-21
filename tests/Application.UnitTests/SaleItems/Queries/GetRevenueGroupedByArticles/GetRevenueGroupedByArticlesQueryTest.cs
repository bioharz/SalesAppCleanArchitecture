using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.ArticleItems.Queries.GetRevenueGroupedByArticles;
using CleanArchitecture.Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.SaleItems.Queries.GetRevenueGroupedByArticles
{
    [Collection("QueryTests")]
    public class GetRevenueGroupedByArticlesQueryTest
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRevenueGroupedByArticlesQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            var query = new GetRevenueGroupedByArticlesQuery();

            var handler = new GetRevenueGroupedByArticlesQuery.GetRevenueGroupedByArticlesHandler(_context, _mapper);

            var result = await handler.Handle(query);

            result.ShouldBeOfType<RevenueArticleVm>();

            //TODO: need further tests
            result.RevenueArticles.Single(ra => ra.ArticleNumber == "9IOkSWdpQO4NpPsYgsfBlCcLVO0NfVke").RevenueInEuro.ShouldBe(9.87m);
            
        }
    }
}