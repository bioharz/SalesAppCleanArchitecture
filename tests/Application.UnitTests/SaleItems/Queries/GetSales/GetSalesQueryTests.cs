using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.SaleItems.Queries.GetSales;
using CleanArchitecture.Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.SaleItems.Queries.GetSales
{
    [Collection("QueryTests")]
    public class GetSalesQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSalesQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            var query = new GetSalesQuery();

            var handler = new GetSalesQuery.GetSalesQueryHandler(_context, _mapper);

            var result = await handler.Handle(query);

            result.ShouldBeOfType<SalesVm>();
            result.Lists.Count.ShouldBe(5);
            
        }
    }
}
