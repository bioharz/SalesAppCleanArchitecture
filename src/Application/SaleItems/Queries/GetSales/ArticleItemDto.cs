using System.Collections.Generic;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.SaleItems.Queries.GetSales
{
    public class ArticleItemDto : IMapFrom<ArticleItem>
    {
        public ArticleItemDto()
        {
            SaleItems = new List<SaleItemDto>();
        }
        
        public string ArticleNumber { get; set; }
        
        public IList<SaleItemDto> SaleItems { get; set; }
    }
}