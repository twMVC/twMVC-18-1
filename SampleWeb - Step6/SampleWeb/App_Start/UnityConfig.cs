using System;
using System.Reflection;
using System.Web.Configuration;
using Microsoft.Practices.Unity;
using SampleWeb.Models.DbContextFactory;
using SampleWeb.Models.Interface;
using SampleWeb.Models.Repository;

namespace SampleWeb.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container

        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(
            () =>
            {
                var container = new UnityContainer();
                RegisterTypes(container);
                return container;
            });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            //資料庫連接字串由執行端環境來給予，而不寫死在 DbContextFactory 當中.
            var connectionString =
                WebConfigurationManager.ConnectionStrings["NorthwindEntities"].ConnectionString;

            container
                .RegisterType<IDbContextFactory, DbContextFactory>(
                    new PerRequestLifetimeManager(),
                    new InjectionConstructor(connectionString))
                .RegisterType(
                    typeof(IRepository<>),
                    typeof(GenericRepository<>),
                    new PerRequestLifetimeManager())
                .RegisterTypes(
                    AllClasses.FromAssemblies(true, Assembly.Load("SampleWeb.Service")),
                    WithMappings.FromMatchingInterface,
                    WithName.Default,
                    WithLifetime.Custom<PerRequestLifetimeManager>);
        }
    }
}