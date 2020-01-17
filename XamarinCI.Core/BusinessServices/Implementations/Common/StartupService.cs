using XamarinCI.Core.BusinessServices.Interfaces.Common;
using System.Threading.Tasks;

namespace XamarinCI.Core.BusinessServices.Implementations.Common
{
    public class StartupService : IStartupService
    {
        public void PrepareMetaDataInBackground()
        {
            Task.Run(() =>
            {
                /* ==================================================================================================
                 * prepare all our metadata here, such as: defauts values, enviroment...
                 * ================================================================================================*/
            });
        }
    }
}
