using Castle.MicroKernel.Registration;

namespace eCommerce.WebService.Installers
{
    public class ApplicationLayerInstall : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Classes.FromAssembly(typeof(eCommerce.ApplicationLayer.Customers.ICustomerService).Assembly)
                .Where(x => !x.IsInterface && !x.IsAbstract && !x.Name.EndsWith("Dto") && x.Namespace.Contains("ApplicationLayer"))
                .WithService.DefaultInterfaces()
                .Configure(c => c.LifestyleTransient()));
        }
    }
}