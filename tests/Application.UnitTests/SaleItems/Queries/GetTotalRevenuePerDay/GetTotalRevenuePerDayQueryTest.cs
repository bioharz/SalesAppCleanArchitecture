using System.Threading.Tasks;
using CleanArchitecture.Application.SaleItems.Queries.GetTotalRevenuePerPay;
using CleanArchitecture.Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.SaleItems.Queries.GetTotalRevenuePerDay
{
    
    [Collection("QueryTests")]
    public class GetTotalRevenuePerDayQueryTests
    {
        private readonly ApplicationDbContext _context;

        public GetTotalRevenuePerDayQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            var query = new GetTotalRevenuePerDayQuery()
            {
                Date = ApplicationDbContextFactory.DateTimeOffsetNow.DateTime
            };
            
            var handler = new GetTotalRevenuePerDayQuery.GetTotalRevenuePerDayHandler(_context);

            var result = await handler.Handle(query);

            result.ShouldBeOfType<decimal>();
            result.ShouldBe(149.53m);
        }
    }
}