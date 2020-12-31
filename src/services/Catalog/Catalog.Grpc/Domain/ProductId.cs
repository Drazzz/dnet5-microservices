using System;
using DDDNETBB.Core;
using DDDNETBB.Domain;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Catalog.Grpc.Domain
{
    public sealed record ProductId : Identity
    {
        [JsonConstructor]
        [BsonConstructor]
        private ProductId(Guid value) : base(value)
        { }

        public static ProductId For(Guid id) => new(id);
        public static ProductId New() => new(Guid.NewGuid());

        public override bool IsTransient() => Value.IsNotEmpty();
    }
}