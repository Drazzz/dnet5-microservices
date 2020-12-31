using System.Collections.Generic;
using DDDNETBB.Core;
using Newtonsoft.Json;

namespace Catalog.Grpc.Domain
{
    public sealed class ProductStatus : Enumeration
    {
        [JsonConstructor]
        private ProductStatus(int id, string name)
            : base(id, name) { }

        public static ProductStatus InStock = new(0, nameof(InStock).ToUpperInvariant());
        public static ProductStatus Low = new(0, nameof(Low).ToUpperInvariant());
        public static ProductStatus None = new(0, nameof(None).ToUpperInvariant());


        public static ProductStatus From(string name) => FromDisplayName<ProductStatus>(name?.ToUpperInvariant());
        public static ProductStatus From(int id) => FromValue<ProductStatus>(id);
        public static IReadOnlyCollection<ProductStatus> List() => new[] { InStock, Low, None };
    }
}