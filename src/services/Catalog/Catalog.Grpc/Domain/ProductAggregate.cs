using System;
using Catalog.Grpc.Domain.Rules;
using DDDNETBB.Core;
using DDDNETBB.Domain;
using Newtonsoft.Json;

namespace Catalog.Grpc.Domain
{
    public sealed class ProductAggregate : EventedAggregateRoot<ProductId>
    {
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get;}
        public ProductStatus Status { get; }
        public DateTime CreationDate { get; init; }


        [JsonConstructor]
        private ProductAggregate(ProductId id, string name, string description, decimal price, ProductStatus status)
        {
            Check(new ProductNameCannotBeNullEmptyOrWhitespace(name));
            Check(new ProductDescriptionCannotBeNullEmptyOrWhitespace(description));
            Check(new ProductPriceCannotBeLessOrEqualsToZero(price));

            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Status = status;
            CreationDate = DateTime.UtcNow;
        }
        public static ProductAggregate For(ProductId id, string name, string description, decimal price, ProductStatus status)
            => new (id ?? ProductId.New(), name, description, price, status ?? ProductStatus.None);

        public static ProductAggregate For(Guid id, string name, string description, decimal price, int statusId)
        {
            var productId = id.IsEmpty() ? ProductId.New() : ProductId.For(id);
            var status = statusId < 0 ? ProductStatus.None : ProductStatus.From(statusId);

            return new ProductAggregate(productId, name, description, price, status);
        }
    }
}