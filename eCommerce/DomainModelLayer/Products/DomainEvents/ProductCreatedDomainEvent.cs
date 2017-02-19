using eCommerce.Helpers.Domain;

namespace eCommerce.DomainModelLayer.Products.DomainEvents
{
    public class ProductCreatedDomainEvent : DomainEvent
    {
        public Product Product { get; set; }

        public override void Flatten()
        {
            this.Args.Add("ProductId", this.Product.Id);
            this.Args.Add("ProductName", this.Product.Name);
            this.Args.Add("ProductQuantity", this.Product.Quantity);
            this.Args.Add("ProductCode", this.Product.Code.Id);
            this.Args.Add("ProductCost", this.Product.Cost);
        }
    }
}