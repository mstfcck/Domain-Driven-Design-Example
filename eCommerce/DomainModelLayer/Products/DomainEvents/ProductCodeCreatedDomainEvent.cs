using eCommerce.Helpers.Domain;

namespace eCommerce.DomainModelLayer.Products.DomainEvents
{
    public class ProductCodeCreatedDomainEvent : DomainEvent
    {
        public ProductCode ProductCode { get; set; }

        public override void Flatten()
        {
            this.Args.Add("ProductCodeId", this.ProductCode.Id);
            this.Args.Add("ProductCodeName", this.ProductCode.Name);
        }
    }
}