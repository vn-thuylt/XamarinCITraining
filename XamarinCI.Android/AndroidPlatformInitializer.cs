using Prism;
using Prism.Ioc;
using XamarinCI.Core.BusinessServices.Interfaces.Common;
using XamarinCI.Droid.Services.Implementations;

namespace XamarinCI.Droid
{
    public class AndroidPlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterPlatformSpecifiedServices(containerRegistry);
        }

        void RegisterPlatformSpecifiedServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IClipboardService, ClipboardService>();
            // register base on OS service, ie: TextToSpeechService...
        }
    }
}