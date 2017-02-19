using eCommerce.DomainModelLayer.Customers.DomainEvents;
using eCommerce.DomainModelLayer.Email;
using eCommerce.DomainModelLayer.Email.Enums;
using eCommerce.Helpers.Domain;

namespace eCommerce.DomainModelLayer.Customers.Handles
{
    public class CustomerCheckedOutHandle : Handles<CustomerCheckOutDomainEvent>
    {
        private readonly IEmailDispatcher emailDispatcher;
        private readonly IEmailGenerator emailGenerator;
        private readonly ICustomerRepository customerRepository;

        public CustomerCheckedOutHandle(IEmailGenerator emailGenerator, IEmailDispatcher emailSender, ICustomerRepository customerRepository)
        {
            this.emailDispatcher = emailSender;
            this.emailGenerator = emailGenerator;
            this.customerRepository = customerRepository;
        }

        public void Handle(CustomerCheckOutDomainEvent args)
        {
            Customer customer = this.customerRepository.FindById(args.Purchase.CustomerId);

            this.emailDispatcher.Dispatch(this.emailGenerator.Generate(customer, EmailTemplate.PurchaseMade));

            //send notifications, update third party systems, etc
        }
    }
}