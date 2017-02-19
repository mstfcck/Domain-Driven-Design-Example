using eCommerce.Helpers.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace eCommerce.DomainModelLayer.Customers.Specs
{
    public class CustomerBulkIdFindSpec : SpecificationBase<Customer>
    {
        private readonly IEnumerable<Guid> customerIds;

        public CustomerBulkIdFindSpec(IEnumerable<Guid> customerIds)
        {
            this.customerIds = customerIds;
        }

        public override Expression<Func<Customer, bool>> SpecExpression
        {
            get
            {
                return customer => this.customerIds.Contains(customer.Id);
            }
        }
    }
}