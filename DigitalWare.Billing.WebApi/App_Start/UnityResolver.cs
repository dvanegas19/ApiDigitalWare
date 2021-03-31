using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;


namespace DigitalWare.Billing.WebApi.App_Start
{
    using Unity;
    using Unity.Exceptions;

    /// <summary>
    ///  Class UnityResolver  Unity Resolver for Web Api Controllers Dependency Injection
    /// </summary>
    /// <history>
    ///    Version      Author              Date         Description
    ///    1.0.0.0      David Vanegas    27/11/2021  Creation
    /// </history>
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        /// <summary>
        /// Method  UnityResolver Constructor.
        /// </summary>
        /// <param name="container"><see cref="IUnityContainer"/></param>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas    27/11/2021  Creation
        /// </history>
        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        /// <summary>
        ///Method <c>GetServices</c> Resolve All Services.
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/>Service Type</param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas    27/11/2021  Creation
        /// </history>
        public object GetService(Type serviceType)
       {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        /// <summary>
        ///Method <c>GetServices</c> Resolve All Services.
        ///</summary>
        /// <param name="serviceType"><see cref="Type"/>Service Type</param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        /// <history>
        ///    Version      Author              Date        Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        /// <summary>
        /// Method BeginScope Begin Dependency Scope.
        /// </summary>
        /// <returns><see cref="IDependencyScope"/></returns>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     27/11/2021  Creation
        /// </history>
        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
           
        }

    }

}