using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class ArticleItemConfiguration : IEntityTypeConfiguration<ArticleItem>
    {
        public void Configure(EntityTypeBuilder<ArticleItem> builder)
        {
            builder.HasKey(t => t.ArticleNumber);

            builder.Property(t => t.ArticleNumber)
                .IsRequired();
                
            builder.Property(t => t.ArticleNumber)
                .HasMaxLength(ArticleItemConstants.ArticleNumberMaxLength);
        }
    }
}