using System;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Infrastructure.IntegrationTests.Persistence
{
    public class ApplicationDbContextTests : IDisposable
    {
        private readonly string _userId;
        private readonly DateTime _dateTime;
        private readonly Mock<IDateTime> _dateTimeMock;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;
        private readonly ApplicationDbContext _sut;

        private const string ArticleNumber = "eKrb52cNxkPITAOrL4LHTpKy2pWDQJ6f";
        private const decimal SalesPriceInEuro = 51035.87m; 

        public ApplicationDbContextTests()
        {
            _dateTime = new DateTime(3001, 1, 1);
            _dateTimeMock = new Mock<IDateTime>();
            _dateTimeMock.Setup(m => m.Now).Returns(_dateTime);

            _userId = "00000000-0000-0000-0000-000000000000";
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _currentUserServiceMock.Setup(m => m.UserId).Returns(_userId);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            _sut = new ApplicationDbContext(options, operationalStoreOptions);

            _sut.SaleItems.Add(new SaleItem
            {
                ArticleItem = new ArticleItem{ArticleNumber = ArticleNumber},
                SalesPriceInEuro = SalesPriceInEuro

            });

            _sut.SaveChanges();
        }

        /*
        [Fact]
        public async Task SaveChangesAsync_GivenNewSaleItem_ShouldSetCreatedProperties()
        {
            var item = new SaleItem
            {
                ArticleNumber = "TwUyLuB35720fiVaRgPMt7mcJzc90A0H",
                SalesPriceInEuro = 156.45m
            };

            _sut.SaleItems.Add(item);

            await _sut.SaveChangesAsync();

            item.Created.ShouldBe(_dateTime);
            item.CreatedBy.ShouldBe(_userId);
        }
        */
        
        public void Dispose()
        {
            _sut?.Dispose();
        }
    }
}
