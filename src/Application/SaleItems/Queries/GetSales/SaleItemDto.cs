using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.SaleItems.Queries.GetSales
{
    public class SaleItemDto : IMapFrom<SaleItem>
    {
        public string ArticleNumber { get; set; }
        
        public decimal SalesPriceInEuro { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaleItem, SaleItemDto>();
        }
    }
}
