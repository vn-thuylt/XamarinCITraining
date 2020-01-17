using System;
using System.Collections.ObjectModel;
using Prism.Ioc;
using XamarinCI.Core.BusinessServices.Dtos.ApiDto;
using XamarinCI.Core.Infrastructure.Networking.Refit;

namespace XamarinCI.Core.Extensions
{
    public static class AppCenterApiHelper
    {
        public static void RegisterAppCenterApi<T>(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(RestServiceHelper.GetApi<T>());
        }
    }
}
