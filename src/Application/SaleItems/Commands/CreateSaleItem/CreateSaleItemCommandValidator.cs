using CleanArchitecture.Domain.Entities;
using FluentValidation;

namespace CleanArchitecture.Application.SaleItems.Commands.CreateSaleItem
{
    public class CreateSaleItemCommandValidator : AbstractValidator<CreateSaleItemCommand>
    {
        public CreateSaleItemCommandValidator()
        {
            RuleFor(v => v.ArticleNumber)
                .MaximumLength(ArticleItemConstants.ArticleNumberMaxLength)
                .NotEmpty();

            RuleFor(v => v.SalesPriceInEuro)
                .ScalePrecision(SaleItemConstants.Scale, SaleItemConstants.Precision, SaleItemConstants.IgnoreTrailingZeros);
        }
    }
}
