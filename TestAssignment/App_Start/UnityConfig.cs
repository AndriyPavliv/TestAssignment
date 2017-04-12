using Microsoft.Practices.Unity;
using System.Web.Http;
using TestAssignment.Services;
using TestAssignment.Services.Impl;
using Unity.WebApi;

namespace TestAssignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IDataService, DataService>();            

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}