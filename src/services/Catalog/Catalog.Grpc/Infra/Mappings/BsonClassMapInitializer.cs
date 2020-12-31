using MongoDB.Bson.Serialization;

namespace Catalog.Grpc.Infra.Mappings
{
    public static class BsonClassMapInitializer
    {
        public static void Initialize()
        {
            BsonClassMap.RegisterClassMap(new ProductAggregateBsonMappingConfiguration());
        }
    }
}