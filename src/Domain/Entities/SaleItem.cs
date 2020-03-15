using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public static class  SaleItemConstants
    {
        public const short ArticleNumberMaxLength = 32;
    }
    public class SaleItem : AuditableEntity
    {
        public string ArticleNumber { get; set; }
        
        public decimal SalesPriceInEuro { get; set; }
    }
}
