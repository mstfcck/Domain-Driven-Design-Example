using eCommerce.DomainModelLayer.Purchases;
using eCommerce.Helpers.Domain;

namespace eCommerce.DomainModelLayer.Customers.DomainEvents
{
    public class CustomerCheckOutDomainEvent : DomainEvent
    {
        public Purchase Purchase { get; set; }

        public override void Flatten()
        {
            this.Args.Add("CustomerId", this.Purchase.CustomerId);
            this.Args.Add("PurchaseId", this.Purchase.Id);
            this.Args.Add("TotalCost", this.Purchase.TotalCost);
            this.Args.Add("TotalTax", this.Purchase.TotalTax);
            this.Args.Add("NumberOfProducts", this.Purchase.Products.Count);
        }
    }
}