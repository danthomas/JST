using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace JST.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            Business.UnityConfig.RegisterComponents(container);
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}