using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<SaleItem> SaleItems { get; set; }
        
        DbSet<ArticleItem> ArticleItems { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
