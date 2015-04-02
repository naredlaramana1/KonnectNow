using KonnectNow.Repository.EF;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Configuration;
using System.Web.Http;

namespace KonnectNow.WebAPI.IOC
{
    /// <summary>
    /// Handles unity configuration
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Registers unity configurations
        /// </summary>
        public static void RegisterComponents()
        {
            IUnityContainer container = new UnityContainer();
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unityPE");
            section.Configure(container);
            container.RegisterType<KonnectNowContext>(new HierarchicalLifetimeManager(),
                                           new InjectionFactory(c =>
                                           {
                                               return new KonnectNowContext();
                                           }));
            container.AddNewExtension<Interception>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}