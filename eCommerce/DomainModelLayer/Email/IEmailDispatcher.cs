using System.Net.Mail;

namespace eCommerce.DomainModelLayer.Email
{
    public interface IEmailDispatcher
    {
        void Dispatch(MailMessage mailMessage);
    }
}