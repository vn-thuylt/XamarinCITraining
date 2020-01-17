using System;
using Prism.Ioc;
using XamarinCI.Core.ApiDefinitions.ApiToken;
using XamarinCI.Core.ApiDefinitions.Apps;
using XamarinCI.Core.ApiDefinitions.Invitations;
using XamarinCI.Core.ApiDefinitions.Orgs;
using XamarinCI.Core.ApiDefinitions.User;
using XamarinCI.Core.BusinessServices.Implementations.ApiToken;
using XamarinCI.Core.BusinessServices.Implementations.Apps;
using XamarinCI.Core.BusinessServices.Implementations.Common;
using XamarinCI.Core.BusinessServices.Implementations.Invitations;
using XamarinCI.Core.BusinessServices.Implementations.Orgs;
using XamarinCI.Core.BusinessServices.Implementations.User;
using XamarinCI.Core.BusinessServices.Interfaces.ApiToken;
using XamarinCI.Core.BusinessServices.Interfaces.Apps;
using XamarinCI.Core.BusinessServices.Interfaces.Common;
using XamarinCI.Core.BusinessServices.Interfaces.Invitations;
using XamarinCI.Core.BusinessServices.Interfaces.Orgs;
using XamarinCI.Core.BusinessServices.Interfaces.User;
using XamarinCI.Core.Extensions;
using XamarinCI.Core.Infrastructure.Networking.Refit;

namespace XamarinCI.Core.Shared
{
    /// <summary>
    /// Helper context for us to resolve our managed services, types.
    /// </summary>
    public sealed class DependencyRegistrar
    {
        private static readonly Lazy<DependencyRegistrar> Lazy = new Lazy<DependencyRegistrar>(() => new DependencyRegistrar());

        public static DependencyRegistrar Current => Lazy.Value;

        /* ==================================================================================================
         * use Pris,.Ioc.IContainerProvider instead of Autofac.IContainer.
         * BC in future, we can change dependency container easier, such as: Unity, DryIoc...
         * ================================================================================================*/
        private IContainerProvider _containerProvider;

        private DependencyRegistrar()
        {
            //hidden ctor
        }

        /// <summary>
        /// Init this instance
        /// </summary>
        /// <param name="containerExtension">Container.</param>
        public void Init(IContainerExtension containerExtension)
        {
            /* ==================================================================================================
             * Register real services first
             * Then register mock. the service with mock implementation overwrite the real implementation
             * ================================================================================================*/
            RegisterServices(containerExtension);
            RegisterMockServices(containerExtension);
            /* ==================================================================================================
             * store the main container
             * ================================================================================================*/
            _containerProvider = containerExtension as IContainerProvider;
        }

        public object Resolve(Type type, string name)
        {
            if (_containerProvider == null)
                throw new Exception($"You must call {nameof(DependencyRegistrar)}.{nameof(Init)}(containerExtension) before use!");
            return _containerProvider.Resolve(type, name);
        }

        public object Resolve(Type type)
        {
            if (_containerProvider == null)
                throw new Exception($"You must call {nameof(DependencyRegistrar)}.{nameof(Init)}(containerExtension) before use!");
            return _containerProvider.Resolve(type);
        }

        public T Resolve<T>()
        {
            if (_containerProvider == null)
                throw new Exception($"You must call {nameof(DependencyRegistrar)}.{nameof(Init)}(containerExtension) before use!");
            return _containerProvider.Resolve<T>();
        }

        public T Resolve<T>(string name)
        {
            if (_containerProvider == null)
                throw new Exception($"You must call {nameof(DependencyRegistrar)}.{nameof(Init)}(containerExtension) before use!");
            return _containerProvider.Resolve<T>(name);
        }

        /// <summary>
        /// Register all service with its implementation
        /// </summary>
        /// <param name="containerRegistry">Container registry.</param>
        private void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IStartupService, StartupService>();

            /* ==================================================================================================
             * Register for api gateway, use register instance
             * ================================================================================================*/
            //containerRegistry.RegisterInstance(RestServiceHelper.GetApi<IPhotoApi>());
            containerRegistry.RegisterInstance(RestServiceHelper.GetApi<IUserApi>());
            containerRegistry.RegisterInstance(RestServiceHelper.GetApi<IOrgsApi>());
            containerRegistry.RegisterInstance(RestServiceHelper.GetApi<IApiTokenApi>());
            containerRegistry.RegisterInstance(RestServiceHelper.GetApi<IInvitationsApi>());
            containerRegistry.RegisterInstance(RestServiceHelper.GetApi<IAppsApi>());
            RegisterAppCenterApis(containerRegistry);

            /* ==================================================================================================
             * register logic services which using for app
             * ...
             * ================================================================================================*/
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IOrgsService, OrgsService>();
            containerRegistry.Register<IApiTokenService, ApiTokenService>();
            containerRegistry.Register<IInvitationsService, InvitationsService>();
            containerRegistry.Register<IAppsService, AppsService>();
        }

        private void RegisterMockServices(IContainerRegistry containerRegistry)
        {
            /* ==================================================================================================
             * register mock service for devs undependent develop
             * ...            
             * ================================================================================================*/
        }

        private void RegisterAppCenterApis(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterAppCenterApi<IUserApi>();
        }
    }

}
