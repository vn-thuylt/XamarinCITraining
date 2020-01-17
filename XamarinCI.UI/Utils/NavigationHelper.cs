using System;
using System.Threading.Tasks;
using Prism.Navigation;
using XamarinCI.UI.ViewModels.Common;

namespace XamarinCI.UI.Utils
{
    public static class NavigationHelper
    {
        #region pre-defined
        /// <summary>
        /// go to the login page and clear all navi stacks
        /// </summary>
        /// <returns>The to login page async.</returns>
        /// <param name="navigationService">Navigation service.</param>
        public static Task GoToLoginPageAsync(INavigationService navigationService)
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));
            throw new NotImplementedException();
            //await navigationService.NavigateAsync($"/{nameof(LoginPageViewModel)}");
        }

        /// <summary>
        /// Go to main page and clear all nav stack
        /// </summary>
        /// <returns>The to main page.</returns>
        /// <param name="navigationService">Navigation service.</param>
        public static Task GoToMainPageAsync(INavigationService navigationService)
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));

            return navigationService.NavigateAsync(nameof(HomePageViewModel));
        }

        #endregion
    }
}
