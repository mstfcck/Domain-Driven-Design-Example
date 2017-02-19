using eCommerce.DomainModelLayer.Countries;
using eCommerce.DomainModelLayer.Customers.DomainEvents;
using eCommerce.DomainModelLayer.Customers.Specs;
using eCommerce.Helpers.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace eCommerce.DomainModelLayer.Customers
{
    public class Customer : IAggregateRoot
    {
        private List<CreditCard> creditCards = new List<CreditCard>();

        public virtual Guid Id { get; protected set; }
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual decimal Balance { get; protected set; }
        public virtual Guid CountryId { get; protected set; }

        public virtual ReadOnlyCollection<CreditCard> CreditCards { get { return this.creditCards.AsReadOnly(); } }

        public virtual void ChangeEmail(string email)
        {
            if (this.Email != email)
            {
                this.Email = email;
                DomainEventsHelper.Raise<CustomerChangedEmailDomainEvent>(new CustomerChangedEmailDomainEvent() { Customer = this });
            }
        }

        public static Customer Create(string firstname, string lastname, string email, Country country)
        {
            return Create(Guid.NewGuid(), firstname, lastname, email, country); ;
        }

        public static Customer Create(Guid id, string firstname, string lastname, string email, Country country)
        {
            if (string.IsNullOrEmpty(firstname))
                throw new ArgumentNullException("firstname");

            if (string.IsNullOrEmpty(lastname))
                throw new ArgumentNullException("lastname");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("email");

            if (country == null)
                throw new ArgumentNullException("country");

            Customer customer = new Customer()
            {
                Id = id,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                CountryId = country.Id
            };

            DomainEventsHelper.Raise<CustomerCreatedDomainEvent>(new CustomerCreatedDomainEvent() { Customer = customer });

            return customer;
        }

        public virtual ReadOnlyCollection<CreditCard> GetCreditCardsAvailble()
        {
            return this.creditCards.FindAll(new CreditCardAvailableSpec(DateTime.Today).IsSatisfiedBy).AsReadOnly();
        }

        public virtual void Add(CreditCard creditCard)
        {
            this.creditCards.Add(creditCard);

            DomainEventsHelper.Raise<CreditCardAddedDomainEvent>(new CreditCardAddedDomainEvent() { CreditCard = creditCard });
        }
    }
}