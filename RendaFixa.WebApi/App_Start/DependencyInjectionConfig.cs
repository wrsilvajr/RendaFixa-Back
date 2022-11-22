using RendaFixa.Domain;
using RendaFixa.Service;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace RendaFixa.WebApi.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void RegisterDIContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();// WebRequestLifestyle();

            InitializeContainer(container);

            //container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<ICDB, CDBService>(Lifestyle.Scoped);

            container.RegisterSingleton(() => AutoMapperConfig.GetMapperConfiguration().CreateMapper(container.GetInstance));
        }
    }
}