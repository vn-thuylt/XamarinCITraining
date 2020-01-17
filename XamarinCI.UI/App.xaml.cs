using Akavache;
using Autofac;
using AutoMapper;
using Plugin.Multilingual;
using Prism;
using Prism.Autofac;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Plugin.Popups;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCI.Core.BusinessServices;
using XamarinCI.Core.BusinessServices.Interfaces.Common;
using XamarinCI.Core.Infrastructure.Logging;
using XamarinCI.Core.Shared;
using XamarinCI.Core.Storage;
using XamarinCI.UI.Languages;
using XamarinCI.UI.Models;
using XamarinCI.UI.Utils;
using XamarinCI.UI.ViewModels.Common;
using XamarinCI.UI.Views.Common;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinCI.UI
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer) : base(initializer)
        {
            /* ==================================================================================================
             * Init config auto mapper for UI level
             * ================================================================================================*/
            AutoMapperSetup();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            /* ==================================================================================================
             * Register for app navigation
             * ================================================================================================*/
            RegisterNavigation(containerRegistry);

            /* ==================================================================================================
             * Register for serivices which used in app
             * This moved to inner call of project for Logic test.
             * ================================================================================================*/
            DependencyRegistrar.Current.Init(containerRegistry as IContainerExtension);
        }

        private void RegisterNavigation(IContainerRegistry containerRegistry)
        {
            /* ==================================================================================================
             * todo: moved to of UI project inner call => for future UI test
             * ================================================================================================*/

            // register popup navigation
            containerRegistry.RegisterPopupNavigationService();

            /* ==================================================================================================
             * Main navaigation containers, dont has any viewmodels. 
             * Especially, we register without the viewmodel's name, it's implicit use view name.
             * ================================================================================================*/
            containerRegistry.RegisterForNavigation<NavigationPage>();

            /* ==================================================================================================
             * As our team-rule: all pages used in app will be registerd with their explicit 
             * viewmodel's name instead of view's name.
             * Using 'nameof' key word to restrict defined more constant string values
             * ================================================================================================*/
            containerRegistry.RegisterForNavigation<HomePage>(nameof(HomePageViewModel));
        }

        /// <summary>
        /// map viewType to viewmodel type (base on prism default)
        /// </summary>
        /// <returns>The type to view model type.</returns>
        /// <param name="viewType">View type.</param>
        Type ViewTypeToViewModelType(Type viewType)
        {
            /* ==================================================================================================
             * Based on prism built-in map. In the future, we can change it if needed
             * ================================================================================================*/
            var viewName = viewType.FullName;
            viewName = viewName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var suffix = viewName.EndsWith("View", StringComparison.Ordinal) ? "Model" : "ViewModel";
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}{1}, {2}", viewName, suffix, viewAssemblyName);
            return Type.GetType(viewModelName);
        }

        async void InitNavigation()
        {
            /* ==================================================================================================
             * Init the first navigation of our app
             * ================================================================================================*/
            await NavigationHelper.GoToMainPageAsync(NavigationService);
        }

        void StorageSettup()
        {
            /* ==================================================================================================
             * Your application's name. Set this at startup, this defines where your data will be stored 
             * (usually at %AppData%\[ApplicationName])
             * ================================================================================================*/
            BlobCache.ApplicationName = "XamarinCI";
            BlobCache.EnsureInitialized();
        }

        void AutoMapperSetup()
        {
            try
            {
                /* ==================================================================================================
                 * detect the auto mapper intialized. if not initialized, it will throw InvalidOperationException
                 * ================================================================================================*/
                Mapper.AssertConfigurationIsValid();
            }
            catch (InvalidOperationException)
            {
                /* ==================================================================================================
                 * decent hack: auto mapper had not been initialized
                 * ================================================================================================*/
                Mapper.Initialize(cfg =>
                {
                    cfg.AddProfile<AutoMapperUIProfile>();
                    cfg.AddProfile<AutoMapperCoreProfile>();
                });
            }
        }

        #region App lifecycle

        protected override void OnInitialized()
        {
#if DEBUG
            var stopWatch = Stopwatch.StartNew();
#endif
            InitializeComponent();
#if DEBUG
            LogCommon.Info($"{stopWatch.ElapsedMilliseconds} ms for InitializeComponent()");
            stopWatch.Restart();
#endif
            /* ==================================================================================================
             * Init the thread helper. store current uicontext for future use whole app
             * ================================================================================================*/
            ThreadHelper.Init(SynchronizationContext.Current);
#if DEBUG
            LogCommon.Info($"{stopWatch.ElapsedMilliseconds} ms for ThreadHelper.Init()");
            stopWatch.Restart();
#endif
            /* ==================================================================================================
             * Setting up the local storage
             * ================================================================================================*/
            StorageSettup();
#if DEBUG
            LogCommon.Info($"{stopWatch.ElapsedMilliseconds} ms for StorageSettup()");
            stopWatch.Restart();
#endif
            /* ==================================================================================================
             * Resolve the startup service, use it for prepare all metada for whole app
             * ================================================================================================*/
            var startupService = Container.Resolve<IStartupService>();
            startupService.PrepareMetaDataInBackground();
#if DEBUG
            LogCommon.Info($"{stopWatch.ElapsedMilliseconds} ms for PrepareMetaDataInBackground()");
            stopWatch.Restart();
#endif
        }

        void LanguageSetup()
        {
            /* ==================================================================================================
             * default app language: English
             * Todo: apply localization for done/cancel button of Picker, DatePicker, TimePicker... with 2 options 
             * 1. Apply an addtional localize strings for each platform => no need to custom built-in rendererer
             * 2. Custom/re-render some custom renderer for each platform
             * ================================================================================================*/
            var setting = StorageContext.Current.BussinessSettings;
            if (string.IsNullOrWhiteSpace(setting.Language))
            {
                setting.Language = "en";
                StorageContext.Current.BussinessSettings = setting;
            }
            AppResource.Culture = CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo(setting.Language);
        }

        protected override void OnStart()
        {
#if DEBUG
            var stopWatch = Stopwatch.StartNew();
#endif
            /* ==================================================================================================
             * Set default viewtype to viewmodel type resolver. In future, we can change the naming rule if needed
             * ================================================================================================*/
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(ViewTypeToViewModelType);
#if DEBUG
            LogCommon.Info($"{stopWatch.ElapsedMilliseconds} ms SetDefaultViewTypeToViewModelTypeResolver()");
            stopWatch.Restart();
#endif
            /* ==================================================================================================
             * language
             * ================================================================================================*/
            LanguageSetup();
#if DEBUG
            LogCommon.Info($"{stopWatch.ElapsedMilliseconds} ms LanguageSetup()");
            stopWatch.Restart();
#endif
            InitNavigation();
#if DEBUG
            LogCommon.Info($"{stopWatch.ElapsedMilliseconds} ms InitNavigation()");
            stopWatch.Stop();
#endif
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #endregion
    }
}
