using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Catalog.Grpc;
using System;
using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;

namespace Catalog.Grpc
{
    public sealed class CatalogService : CatalogProtoService.CatalogProtoServiceBase
    {
        private readonly ILogger<CatalogService> _logger;


        public CatalogService(ILogger<CatalogService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));            
        }


        public override async Task GetAllProducts(GetAllProductsRequest request,
            IServerStreamWriter<ProductModel> responseStream,
            ServerCallContext context)
        {
            _logger.LogInformation("Fetching list of products with the stream...");
            var products = new List<ProductModel>{
                new ProductModel{ProductId = 1, Name = "some name"},
                new ProductModel{ProductId = 2, Name = "dadasd", Status = ProductStatus.Low, CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow)}
            };

            foreach (var product in products)
                await responseStream.WriteAsync(product);
        }
    }
}