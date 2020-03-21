using System;
using System.Threading;
using CleanArchitecture.Application.Common.Behaviours;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.SaleItems.Commands.CreateSaleItem;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Common.Behaviours
{
    public class BehaviourTests
    {
        private const string UserId = "jasont";
        private const string UserName = "jason.taylor";
        
        private const string ArticleNumber = "M1Y9rHiEFr28d6bO1x5wGaHiZTkx5aqB";
        private const decimal SalesPriceInEuro = 9.33m;

        public BehaviourTests()
        {
        }

        [Fact]
        public void RequestLogger_Should_Call_GetUserNameAsync_Once_If_Authenticated()
        {
            var logger = new Mock<ILogger<CreateSaleItemCommand>>();
            var currentUserService = new Mock<ICurrentUserService>();
            var identityService = new Mock<IIdentityService>();

            currentUserService.Setup(x => x.UserId).Returns(UserId);

            IRequestPreProcessor<CreateSaleItemCommand> requestLogger = new RequestLogger<CreateSaleItemCommand>(logger.Object, currentUserService.Object, identityService.Object);

            requestLogger.Process(new CreateSaleItemCommand { ArticleNumber = ArticleNumber, SalesPriceInEuro = SalesPriceInEuro, DateTimeOffset = DateTimeOffset.Now.AddDays(-2)}, new CancellationToken());

            identityService.Verify(i => i.GetUserNameAsync(UserId), Times.Once);
        }

        [Fact]
        public void RequestLogger_Should_Not_Call_GetUserNameAsync_Once_If_Unauthenticated()
        {
            var logger = new Mock<ILogger<CreateSaleItemCommand>>();
            var currentUserService = new Mock<ICurrentUserService>();
            var identityService = new Mock<IIdentityService>();

            currentUserService.Setup(x => x.UserId).Returns((string)null);

            IRequestPreProcessor<CreateSaleItemCommand> requestLogger = new RequestLogger<CreateSaleItemCommand>(logger.Object, currentUserService.Object, identityService.Object);

            requestLogger.Process(new CreateSaleItemCommand { ArticleNumber = ArticleNumber, SalesPriceInEuro = SalesPriceInEuro }, new CancellationToken());


            identityService.Verify(i => i.GetUserNameAsync(null), Times.Never);
        }
    }
}
