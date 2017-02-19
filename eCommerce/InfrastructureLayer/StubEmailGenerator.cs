using eCommerce.DomainModelLayer.Email;
using eCommerce.DomainModelLayer.Email.Enums;
using System.Net.Mail;

namespace eCommerce.InfrastructureLayer
{
    public class StubEmailGenerator : IEmailGenerator
    {
        public MailMessage Generate(object objHolder, EmailTemplate emailTemplate)
        {
            //Generate your email here
            return new MailMessage();
        }
    }
}