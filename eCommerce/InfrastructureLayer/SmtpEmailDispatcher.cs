﻿using eCommerce.DomainModelLayer.Email;
using System.Net.Mail;

namespace eCommerce.InfrastructureLayer
{
    public class SmtpEmailDispatcher : IEmailDispatcher
    {
        public void Dispatch(MailMessage mailMessage)
        {
            //send an email here...
        }
    }
}
