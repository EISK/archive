using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;

namespace Eisk.Helpers
{
    public static class DependencyHelper
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                if (_container == null)
                    Initialize();
                return DependencyHelper._container;
            }
        }
        
        /// <summary>
        /// Initializes the dependency injection container according to config settings.
       /// </summary>
        public static void Initialize()
        {
            _container = new UnityContainerFactory().CreateConfiguredContainer();     
            var serviceLocator = new UnityServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            DependencyResolver.SetResolver(new UnityDependencyResolver(_container));
        }

        public static TService GetInstance<TService>()
        {
            if (_container == null)
                Initialize();

            return ServiceLocator.Current.GetInstance<TService>();
        }

        public static void ClearContainer()
        {
            _container = null;
        }
    }
}