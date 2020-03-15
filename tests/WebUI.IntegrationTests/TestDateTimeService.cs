using System;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.WebUI.IntegrationTests
{
    public class TestDateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
