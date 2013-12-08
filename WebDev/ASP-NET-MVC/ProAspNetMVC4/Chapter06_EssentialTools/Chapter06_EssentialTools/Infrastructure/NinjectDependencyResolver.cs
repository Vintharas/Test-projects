using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Chapter06_EssentialTools.Interfaces;
using Chapter06_EssentialTools.Models;
using Ninject;

namespace Chapter06_EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            // This binding for IDiscountHelper would act as default
            kernel.Bind<IDiscountHelper>()
                  .To<DefaultDiscountHelper>()
                  .WithPropertyValue("DiscountSize", 10M); // Passing properties when object is constructed
            // This binding for IDiscountHelper would be preferred for LinqValueCalculator
            kernel.Bind<IDiscountHelper>()
                .To<AnotherDefaultDiscountHelper>()
                .WhenInjectedInto<LinqValueCalculator>()             // Conditional Binding
                .WithConstructorArgument("discountSize", 50M);       // Passing parameters to constructor
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}