using System;

namespace CleanArchitecture.Domain.Entities
{
    
    public static class  SaleItemConstants
    {
        public const int Scale = 2;
        public const int Precision = 15; //see: https://docs.microsoft.com/en-us/sql/t-sql/data-types/money-and-smallmoney-transact-sql?view=sql-server-ver15
        public const bool IgnoreTrailingZeros = true;
    }
    
    public class SaleItem
    {
        public Guid Id { get; set; }
        
        public decimal SalesPriceInEuro { get; set; }
        
        public ArticleItem ArticleItem { get; set; }
        public DateTimeOffset DateTimeOffset { get; set; }
    }
}
