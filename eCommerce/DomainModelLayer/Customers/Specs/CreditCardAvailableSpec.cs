using eCommerce.Helpers.Specification;
using System;
using System.Linq.Expressions;

namespace eCommerce.DomainModelLayer.Customers.Specs
{
    public class CreditCardAvailableSpec : SpecificationBase<CreditCard>
    {
        private readonly DateTime dateTime;

        public CreditCardAvailableSpec(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public override Expression<Func<CreditCard, bool>> SpecExpression
        {
            get
            {
                return creditCard => creditCard.Active && creditCard.Expiry >= this.dateTime;
            }
        }
    }
}