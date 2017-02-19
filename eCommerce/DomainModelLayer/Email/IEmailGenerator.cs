using eCommerce.DomainModelLayer.Email.Enums;
using System.Net.Mail;

namespace eCommerce.DomainModelLayer.Email
{
    public interface IEmailGenerator
    {
        MailMessage Generate(object objHolder, EmailTemplate emailTemplate);
    }
}