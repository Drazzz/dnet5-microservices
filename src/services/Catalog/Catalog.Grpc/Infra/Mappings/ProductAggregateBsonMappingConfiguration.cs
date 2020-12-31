using System;
using Catalog.Grpc.Domain;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Catalog.Grpc.Infra.Mappings
{
    public sealed class ProductAggregateBsonMappingConfiguration : BsonClassMap<ProductAggregate>
    {
        public ProductAggregateBsonMappingConfiguration()
        {
            MapIdMember(p => p.Id)
                .SetElementName("_id")
                .SetIdGenerator(GuidGenerator.Instance)
                ;

            MapMember(p => p.Name)
                .SetElementName("productName")
                ;

            MapMember(p => p.Description)
                .SetElementName("description")
                ;

            //TODO:Status & CreationDate configuration
        }
    }
}