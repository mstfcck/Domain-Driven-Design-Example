using eCommerce.Helpers.Specification;
using System;
using System.Linq.Expressions;

namespace eCommerce.DomainModelLayer.Purchases.Specs
{
    public class CustomerPurchasesSpec : SpecificationBase<Purchase>
    {
        private readonly Guid customerId;

        public CustomerPurchasesSpec(Guid customerId)
        {
            this.customerId = customerId;
        }

        public override Expression<Func<Purchase, bool>> SpecExpression
        {
            get
            {
                return purchase => purchase.CustomerId == this.customerId;
            }
        }
    }
}