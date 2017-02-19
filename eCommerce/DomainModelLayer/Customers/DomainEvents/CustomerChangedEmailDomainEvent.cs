using eCommerce.Helpers.Domain;

namespace eCommerce.DomainModelLayer.Customers.DomainEvents
{
    public class CustomerChangedEmailDomainEvent : DomainEvent
    {
        public Customer Customer { get; set; }

        public override void Flatten()
        {
            this.Args.Add("CustomerId", this.Customer.Id);
            this.Args.Add("Email", this.Customer.Email);
        }
    }
}