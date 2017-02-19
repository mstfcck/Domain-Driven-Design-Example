using eCommerce.Helpers.Specification;
using System;
using System.Linq.Expressions;

namespace eCommerce.DomainModelLayer.Customers.Specs
{
    public class CustomerRegisteredSpec : SpecificationBase<Customer>
    {
        private Guid id;

        public CustomerRegisteredSpec(Guid id)
        {
            this.id = id;
        }

        public override Expression<Func<Customer, bool>> SpecExpression
        {
            get
            {
                return customer => customer.Id == this.id;
            }
        }
    }
}