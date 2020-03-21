using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        
        private const string MoneyTypeMsSql = "money";
        
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.HasKey(t => t.Id);
            
            
            builder.Property(t => t.SalesPriceInEuro)
                .IsRequired();
            
            builder.Property(t => t.SalesPriceInEuro)
                .HasColumnType(MoneyTypeMsSql);
        }
    }
}
