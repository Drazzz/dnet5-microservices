namespace Catalog.Grpc.Domain.Rules
{
    internal sealed class ProductDescriptionCannotBeNullEmptyOrWhitespace : ProductNameCannotBeNullEmptyOrWhitespace
    {
        public ProductDescriptionCannotBeNullEmptyOrWhitespace(string fieldValue) : base(fieldValue)
        { }

        public override string Message => "Product.Description filed cannot be null, empty or whitespace";
    }
}