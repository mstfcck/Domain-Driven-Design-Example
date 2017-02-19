using eCommerce.DomainModelLayer.Customers.DomainEvents;
using eCommerce.DomainModelLayer.Email;
using eCommerce.DomainModelLayer.Newsletter;
using eCommerce.Helpers.Domain;
using System.Net.Mail;

namespace eCommerce.DomainModelLayer.Customers.Handles
{
    public class CustomerCreatedHandle : Handles<CustomerCreatedDomainEvent>
    {
        private readonly INewsletterSubscriber newsletterSubscriber;
        private readonly IEmailDispatcher emailDispatcher;

        public CustomerCreatedHandle(INewsletterSubscriber newsletterSubscriber, IEmailDispatcher emailDispatcher)
        {
            this.newsletterSubscriber = newsletterSubscriber;
            this.emailDispatcher = emailDispatcher;
        }

        public void Handle(CustomerCreatedDomainEvent args)
        {
            //example #1 calling an interface email dispatcher this can have differnet kind of implementation depending on context, e.g
            // smtp = SmtpEmailDispatcher, exchange = ExchangeEmailDispatcher, msmq = MsmqEmailDispatcher, etc...
            this.emailDispatcher.Dispatch(new MailMessage());

            //example #2 calling an interface newsletter subscriber  this can differnet kind of implementation e.g
            // web service = WSNewsletterSubscriber (current), msmq = MsmqNewsletterSubscriber, Sql = SqlNewsletterSubscriber, etc...
            this.newsletterSubscriber.Subscribe(args.Customer);
        }
    }
}