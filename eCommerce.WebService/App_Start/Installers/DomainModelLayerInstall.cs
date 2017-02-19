using Castle.MicroKernel.Registration;
using eCommerce.DomainModelLayer;
using eCommerce.DomainModelLayer.Carts.DomainEvents;
using eCommerce.DomainModelLayer.Countries;
using eCommerce.DomainModelLayer.Countries.DomainEvents;
using eCommerce.DomainModelLayer.Customers.DomainEvents;
using eCommerce.DomainModelLayer.Products.DomainEvents;
using eCommerce.DomainModelLayer.Tax.DomainEvents;
using eCommerce.Helpers.Domain;
using System;

namespace eCommerce.WebService.Installers
{
    public class DomainModelLayerInstall : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("eCommerce")
                .BasedOn(typeof(Handles<>))
                .WithService.FromInterface(typeof(Handles<>))
                .Configure(c => c.LifestyleTransient()));

            container.Register(Classes.FromAssemblyNamed("eCommerce")
                .BasedOn<IDomainService>()
                .WithService.DefaultInterfaces()
                .Configure(c => c.LifestyleTransient()));

            container.Register(Component.For<Settings>()
                .Instance(new Settings(Country.Create(new Guid("229074BD-2356-4B5A-8619-CDEBBA71CC21"), "United Kingdom"))
                    )
               );

            container.Register(Component.For<Handles<CartCreatedDomainEvent>>().ImplementedBy<DomainEventHandle<CartCreatedDomainEvent>>().LifestyleSingleton());
            container.Register(Component.For<Handles<ProductAddedCartDomainEvent>>().ImplementedBy<DomainEventHandle<ProductAddedCartDomainEvent>>().LifestyleSingleton());
            container.Register(Component.For<Handles<ProductRemovedCartDomainEvent>>().ImplementedBy<DomainEventHandle<ProductRemovedCartDomainEvent>>().LifestyleSingleton());
            container.Register(Component.For<Handles<CountryCreatedDomainEvent>>().ImplementedBy<DomainEventHandle<CountryCreatedDomainEvent>>().LifestyleSingleton());
            container.Register(Component.For<Handles<CreditCardAddedDomainEvent>>().ImplementedBy<DomainEventHandle<CreditCardAddedDomainEvent>>().LifestyleSingleton());
            container.Register(Component.For<Handles<CustomerChangedEmailDomainEvent>>().ImplementedBy<DomainEventHandle<CustomerChangedEmailDomainEvent>>().LifestyleSingleton());
            container.Register(Component.For<Handles<CustomerCheckOutDomainEvent>>().ImplementedBy<DomainEventHandle<CustomerCheckOutDomainEvent>>().LifestyleSingleton());
            container.Register(Component.For<Handles<CustomerCreatedDomainEvent>>().ImplementedBy<DomainEventHandle<CustomerCreatedDomainEvent>>().LifestyleSingleton());
            container.Register(Component.For<Handles<ProductCodeCreatedDomainEvent>>().ImplementedBy<DomainEventHandle<ProductCodeCreatedDomainEvent>>().LifestyleSingleton());
            container.Register(Component.For<Handles<ProductCreatedDomainEvent>>().ImplementedBy<DomainEventHandle<ProductCreatedDomainEvent>>().LifestyleSingleton());
            container.Register(Component.For<Handles<CountryTaxCreatedDomainEvent>>().ImplementedBy<DomainEventHandle<CountryTaxCreatedDomainEvent>>().LifestyleSingleton());

            DomainEventsHelper.Init(container);
        }
    }
}