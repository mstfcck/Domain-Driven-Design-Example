using eCommerce.DomainModelLayer.Customers;

namespace eCommerce.DomainModelLayer.Newsletter
{
    public interface INewsletterSubscriber
    {
        void Subscribe(Customer customer);
    }
}