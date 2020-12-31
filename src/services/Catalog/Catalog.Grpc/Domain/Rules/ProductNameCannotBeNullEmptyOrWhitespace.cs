using DDDNETBB.Core;
using DDDNETBB.Domain.Abstractions;

namespace Catalog.Grpc.Domain.Rules
{
    internal class ProductNameCannotBeNullEmptyOrWhitespace : IBusinessRule
    {
        protected string FieldValue;


        public ProductNameCannotBeNullEmptyOrWhitespace(string fieldValue) => FieldValue = fieldValue;


        public bool IsBroken() => FieldValue.IsNullEmptyOrWhitespace();

        public virtual string Message => "Product.Name filed cannot be null, empty or whitespace";
    }
}