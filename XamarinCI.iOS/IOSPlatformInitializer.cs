using Prism;
using Prism.Ioc;
using XamarinCI.Core.BusinessServices.Interfaces.Common;
using XamarinCI.iOS.Services.Implementations;

namespace XamarinCI.iOS
{
    public class IOSPlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterPlatformSpecifiedServices(containerRegistry);
        }

        void RegisterPlatformSpecifiedServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IClipboardService, ClipboardService>();
            /* ==================================================================================================
             * register base on OS service, ie: TextToSpeechService...
             * ================================================================================================*/
        }
    }
}
