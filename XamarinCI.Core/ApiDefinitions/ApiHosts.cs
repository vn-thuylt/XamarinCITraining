using System;
using System.Threading;
using XamarinCI.Core.BusinessServices.Dtos.User;

namespace XamarinCI.Core.ApiDefinitions
{
    public static class ApiHosts
    {
        /* ==================================================================================================
         * sample api host for concept
         * ================================================================================================*/
        public const string AppCenterApiDomain = "https://api.appcenter.ms";
        public const string AppCenterApiVersion = "0.1";
        public static string MainHost = $"{AppCenterApiDomain}/v{AppCenterApiVersion}";

        
    }
}
