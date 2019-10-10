using MasGlobal.Employees.Common.ProveedoresDependencias;
using Spring.Context;
using Spring.Context.Support;
using System.Web.Http;
//using Unity;
//using Unity.Lifetime;

namespace MasGlobal.Employees.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //Se registra el encargado de resolver las instancias y dependencias
            IApplicationContext context = ContextRegistry.GetContext();
            config.DependencyResolver = new SolucionadorDependencia(context);

            //var container = new UnityContainer();
            //container.RegisterType<IEmployeeIntegrationDAO, EmployeeIntegrationDAO>(new HierarchicalLifetimeManager());
            //config.DependencyResolver = new UnityResolver(container);

            // Web API routes

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );            
        }
    }
}
