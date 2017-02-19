using eCommerce.Helpers.Domain;

namespace eCommerce.DomainModelLayer.Customers.DomainEvents
{
    public class CustomerCreatedDomainEvent : DomainEvent
    {
        public Customer Customer { get; set; }

        public override void Flatten()
        {
            this.Args.Add("FirstName", this.Customer.FirstName);
            this.Args.Add("LastName", this.Customer.LastName);
            this.Args.Add("Email", this.Customer.Email);
            this.Args.Add("Country", this.Customer.CountryId);
        }
    }
}