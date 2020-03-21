using System.Reflection;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) { }

        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<ArticleItem> ArticleItems { get; set; }
        
        /*
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<SaleItem>())
            {
                if (entry.State != EntityState.Added) continue;
                
                if (entry.Entity.DateTimeOffset == DateTimeOffset.MinValue)
                    entry.Entity.DateTimeOffset = DateTimeOffset.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        */
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SaleItem>()
                .HasOne(s => s.ArticleItem)
                .WithMany(a => a.SaleItems)
                .IsRequired();
            
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
