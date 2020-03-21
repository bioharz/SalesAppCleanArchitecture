using System.Threading.Tasks;
using CleanArchitecture.Application.SaleItems.Queries.GetNumberOfSoldArticlesPerDay;
using CleanArchitecture.Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.SaleItems.Queries.GetNumberOfSoldArticlesPerDay
{
    
    [Collection("QueryTests")]
    public class GetNumberOfSoldArticlesPerDayTests
    {
        private readonly ApplicationDbContext _context;

        public GetNumberOfSoldArticlesPerDayTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            var query = new GetNumberOfSoldArticlesPerDayQuery
            {
                Date = ApplicationDbContextFactory.DateTimeOffsetNow.DateTime
            };




            var handler = new GetNumberOfSoldArticlesPerDayQuery.GetNumberOfSoldArticlesPerDayHandler(_context);

            var result = await handler.Handle(query);

            result.ShouldBeOfType<int>();
            result.ShouldBe(3);
            
        }
    }
}