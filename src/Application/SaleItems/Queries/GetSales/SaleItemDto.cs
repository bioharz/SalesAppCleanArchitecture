using System;
using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.SaleItems.Queries.GetSales
{
    public class SaleItemDto : IMapFrom<SaleItem>
    {
        public Guid id { get; set; }
        public string ArticleNumber { get; set; }
        
        public decimal SalesPriceInEuro { get; set; }
        
        public DateTimeOffset DateTimeOffset { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaleItem, SaleItemDto>()
                .ForMember(s => s.ArticleNumber, a => a.MapFrom(s => s.ArticleItem.ArticleNumber));
        }
    }
}
