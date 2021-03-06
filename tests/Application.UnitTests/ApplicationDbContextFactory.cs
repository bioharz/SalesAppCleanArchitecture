using System;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;

namespace CleanArchitecture.Application.UnitTests
{
    public static class ApplicationDbContextFactory
    {
        
        public static readonly DateTimeOffset DateTimeOffsetNow = DateTimeOffset.Now;
        
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(3001, 1, 1));

            var currentUserServiceMock = new Mock<ICurrentUserService>();
            currentUserServiceMock.Setup(m => m.UserId)
                .Returns("00000000-0000-0000-0000-000000000000");

            var context = new ApplicationDbContext(
                options, operationalStoreOptions);

            context.Database.EnsureCreated();

            SeedSampleData(context);

            return context;
        }

        public static void SeedSampleData(ApplicationDbContext context)
        {
            var sameArticle = new ArticleItem {ArticleNumber = "9IOkSWdpQO4NpPsYgsfBlCcLVO0NfVke"};
            
            context.SaleItems.AddRange(
                new SaleItem {ArticleItem = sameArticle, SalesPriceInEuro = 3.99m, DateTimeOffset = DateTimeOffsetNow},
                new SaleItem {ArticleItem = sameArticle, SalesPriceInEuro = 5.88m, DateTimeOffset = DateTimeOffsetNow},
                new SaleItem {ArticleItem = new ArticleItem{ArticleNumber = "XoLEU9UXv88hwLkDIS22D42NpgfJRrM8"}, SalesPriceInEuro = 1028.44m, DateTimeOffset = DateTimeOffsetNow.AddDays(1)},
                new SaleItem {ArticleItem = new ArticleItem{ArticleNumber = "tsSP6rjwmofYq1M7tWIvkQTDDdhNXSbT"}, SalesPriceInEuro = 66.33m, DateTimeOffset = DateTimeOffsetNow.AddDays(-1)},
                new SaleItem {ArticleItem = new ArticleItem{ArticleNumber = "yHmnIBDPWz6RZLPYO4XSpsAdKf8G3A2B"}, SalesPriceInEuro = 139.66m, DateTimeOffset = DateTimeOffsetNow.Date}
            );

            context.SaveChanges();
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}