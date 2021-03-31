using System.Web.Http;

[assembly: WebActivator.PostApplicationStartMethod(typeof(DigitalWare.Billing.WebApi.App_Start.InjectorInitializer), "Initialize")]
namespace DigitalWare.Billing.WebApi.App_Start
{
    using Unity;
    using Unity.Lifetime;


    /// <summary>
    /// Injector for Web Api Controllers Dependency Injection
    /// </summary>
    /// <history>
    ///    Version      Autor              Date         Description
    ///    1.0.0.0      David Vanegas    27/11/2021  Creation
    /// </history>
    public static class InjectorInitializer
    {
        /// <summary>
        /// Initialize dependency injector.
        /// </summary>
        public static void Initialize()
        {
            var container = new UnityContainer();

            //Initialize container, register types of interfaces with services
            InitializeContainer(container); 

            //Configure Dependency Injection Resolver
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }

        /// <summary>
        ///  Initialize container
        /// </summary>
        /// <param name="container"><see cref="UnityContainer"/>Unity Container</param>
        /// <history>
        ///    Version      Autor              Date         Description
        ///    1.0.0.0      David Vanegas    27/11/2021  Creation
        /// </history>
        private static void InitializeContainer(UnityContainer container)
        {
            container.RegisterType<Common.Interface.Business.IInvoice, Business.Invoice>(new HierarchicalLifetimeManager());
            container.RegisterType<Common.Interface.Business.IInvoiceDetail, Business.InvoiceDetail>(new HierarchicalLifetimeManager());
            container.RegisterType<Common.Interface.Business.IProduct, Business.Product>(new HierarchicalLifetimeManager());
            container.RegisterType<Common.Interface.Business.IClient, Business.Client>(new HierarchicalLifetimeManager());
            container.AddNewExtension<Business.DependencyOfDependencyExtension>();
        }
        
    }
}