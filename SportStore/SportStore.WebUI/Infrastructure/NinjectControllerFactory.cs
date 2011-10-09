using System.Web.Mvc;
using Ninject;

namespace SportStore.WebUI.Infrastructure
{
    /// <summary>
    /// Controller factory that makes use of Ninject DI container to manage instantiation and lifecycle of 
    /// the web app controllers.
    /// </summary>
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        /// <summary>
        /// Initialize ninject kernel and setup bindings
        /// </summary>
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            SetupBindings();
        }

        /// <summary>
        /// Get a controller instance using the Ninject DI container
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            return controllerType == null ? null : (IController) ninjectKernel.Get(controllerType);
        }

        /// <summary>
        /// Setup Ninject DI container bindings i.e. the container configuration that associates interfaces and
        /// abstract classes with concrete implementations.
        /// </summary>
        private void SetupBindings()
        {
        
        }
    }
}