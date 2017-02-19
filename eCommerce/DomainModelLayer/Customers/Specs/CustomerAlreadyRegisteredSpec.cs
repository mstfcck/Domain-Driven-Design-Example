using eCommerce.Helpers.Specification;
using System;
using System.Linq.Expressions;

namespace eCommerce.DomainModelLayer.Customers.Specs
{
    public class CustomerAlreadyRegisteredSpec : SpecificationBase<Customer>
    {
        private string email;

        public CustomerAlreadyRegisteredSpec(string email)
        {
            this.email = email;
        }

        public override Expression<Func<Customer, bool>> SpecExpression
        {
            get
            {
                return customer => customer.Email == this.email;
            }
        }
    }
}