using eCommerce.Helpers.Domain;

namespace eCommerce.DomainModelLayer.Customers.DomainEvents
{
    public class CreditCardAddedDomainEvent : DomainEvent
    {
        public CreditCard CreditCard { get; set; }

        public override void Flatten()
        {
            this.Args.Add("CustomerId", this.CreditCard.Customer.Id);
            this.Args.Add("NameOnCard", this.CreditCard.NameOnCard);
            this.Args.Add("Last3Digits", this.CreditCard.CardNumber.Substring(this.CreditCard.CardNumber.Length - 3, 3));
        }
    }
}