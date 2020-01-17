using Rg.Plugins.Popup.Pages;

namespace XamarinCI.UI.Views.Base
{
    public class PopupBase : PopupPage
    {
        public PopupBase()
        {
            HasSystemPadding = false;
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
