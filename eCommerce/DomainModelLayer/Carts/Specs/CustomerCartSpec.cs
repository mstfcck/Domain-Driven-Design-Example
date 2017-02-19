using eCommerce.Helpers.Specification;
using System;
using System.Linq.Expressions;

namespace eCommerce.DomainModelLayer.Carts.Specs
{
    public class CustomerCartSpec : SpecificationBase<Cart>
    {
        private readonly Guid customerId;

        public CustomerCartSpec(Guid customerId)
        {
            this.customerId = customerId;
        }

        public override Expression<Func<Cart, bool>> SpecExpression
        {
            get
            {
                return cart => cart.CustomerId == this.customerId;
            }
        }
    }
}