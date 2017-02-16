using eCommerce.Helpers.Repository;
using System.Collections.Generic;

namespace eCommerce.DomainModelLayer.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<CustomerPurchaseHistoryReadModel> GetCustomersPurchaseHistory();
    }
}
