using System;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Application.UnitTests
{
    public class CommandTestBase : IDisposable
    {
        public CommandTestBase()
        {
            Context = ApplicationDbContextFactory.Create();
        }

        public ApplicationDbContext Context { get; }

        public void Dispose()
        {
            ApplicationDbContextFactory.Destroy(Context);
        }
    }
}