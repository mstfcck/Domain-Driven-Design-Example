using eCommerce.DomainModelLayer.Customers;
using eCommerce.DomainModelLayer.Newsletter;

namespace eCommerce.InfrastructureLayer
{
    public class WSNewsletterSubscriber : INewsletterSubscriber
    {
        public void Subscribe(Customer customer)
        {
            //call a third party web service here...
        }
    }
}