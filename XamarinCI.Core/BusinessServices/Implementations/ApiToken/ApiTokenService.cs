using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XamarinCI.Core.ApiDefinitions.ApiToken;
using XamarinCI.Core.BusinessServices.Dtos.ApiToken;
using XamarinCI.Core.BusinessServices.Interfaces.ApiToken;

namespace XamarinCI.Core.BusinessServices.Implementations.ApiToken
{
    public class ApiTokenService : IApiTokenService
    {
        private readonly IApiTokenApi _apiTokenApi;

        public ApiTokenService(IApiTokenApi apiTokenApi) => _apiTokenApi = apiTokenApi;

        #region GET Methods
        public Task<List<ApiTokenDto>> GetApiToken()
        {
            return _apiTokenApi.GetApiToken(new CancellationToken());
        }
        #endregion GET Methods

        #region POST Methods
        public Task<ApiTokenResponse> CreateApiToken([Body] ApiTokenModel newApiToken)
        {
            return _apiTokenApi.CreateApiToken(newApiToken);
        }
        #endregion POST Methods
    }
}
