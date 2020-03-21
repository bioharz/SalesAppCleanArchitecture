using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public static class  ArticleItemConstants
    {
        public const short ArticleNumberMaxLength = 32;
    }
    
    public class ArticleItem
    {
        public ArticleItem()
        {
            SaleItems = new List<SaleItem>();
        }
        
        public string ArticleNumber { get; set; }
        
        public IList<SaleItem> SaleItems { get; set; }
    }
}