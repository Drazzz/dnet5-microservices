using DDDNETBB.Domain.Abstractions;

namespace Catalog.Grpc.Domain.Rules
{
    internal sealed class ProductPriceCannotBeLessOrEqualsToZero : IBusinessRule
    {
        private readonly decimal _price;


        public ProductPriceCannotBeLessOrEqualsToZero(decimal price) => _price = price;


        public bool IsBroken() => _price <= 0.0m;

        public string Message => $"Product.Price cannot be less or equals to zero. Current value: {_price}";
    }
}