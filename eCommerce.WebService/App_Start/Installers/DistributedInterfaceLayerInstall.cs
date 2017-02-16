using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using eCommerce.Helpers.Logging;

namespace eCommerce.WebService.Installers
{
    public class DistributedInterfaceLayerInstall : Castle.MicroKernel.Registration.IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
               .BasedOn<IHttpController>()
               .Configure(c => c.LifestyleTransient()));

            container.Register(Component.For<IRequestCorrelationIdentifier>().ImplementedBy<W3CWebRequestCorrelationIdentifier>().LifeStyle.PerWebRequest);
        }
    }
}