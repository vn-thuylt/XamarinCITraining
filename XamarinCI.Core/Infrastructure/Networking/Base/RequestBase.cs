using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace XamarinCI.Core.Infrastructure.Networking.Base
{
    public abstract class RequestBase
    {
        /* ==================================================================================================
         * sample usage of base property 'Token'
         * Readonly mode
         * ================================================================================================*/
        public static string Token => _token;

        // Admin's API Token
        //private static string _token = "1bf5e7efcaa8cf97d1f0c2c5b612f8e9e5a16623";

        // Developer's API Token
        private static string _token = "c011581f2fbc824301bce901f757eb1ff7f3e5ca";

        public static void SessionId(string session)
        {
            /* ==================================================================================================
             * store the token in a backing static store
             * ================================================================================================*/
            _token = session;
        }
    }
}
