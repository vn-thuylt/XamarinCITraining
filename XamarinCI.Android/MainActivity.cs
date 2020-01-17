using XamarinCI.UI;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Platform;
using Xamarin.Forms;
using Plugin.CurrentActivity;
using Akavache;
using Android;

namespace XamarinCI.Droid
{
    [Activity(Label = "XamarinCI", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public partial class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            /* ==================================================================================================
             * init the popup page plugin
             * ================================================================================================*/
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            /* ==================================================================================================
             * use Xamarin.Forms Fast Renderers
             * https://docs.microsoft.com/en-us/xamarin/xamarin-forms/internals/fast-renderers            
             * ================================================================================================*/
            Forms.SetFlags("FastRenderers_Experimental");

            Forms.Init(this, savedInstanceState);

            /* ==================================================================================================
             * init the FFImageLoading component
             * ================================================================================================*/
            CachedImageRenderer.Init(true);

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            /* ==================================================================================================
             * start load the app
             * ================================================================================================*/
            LoadApplication(new App(new AndroidPlatformInitializer()));
        }

        protected override void OnDestroy()
        {
            BlobCache.Shutdown().Wait();
            base.OnDestroy();
        }
    }
}