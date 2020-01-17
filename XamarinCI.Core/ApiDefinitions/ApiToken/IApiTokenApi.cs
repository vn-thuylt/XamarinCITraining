using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XamarinCI.Core.BusinessServices.Dtos.ApiToken;

namespace XamarinCI.Core.ApiDefinitions.ApiToken
{
    public interface IApiTokenApi
    {
        #region GET Methods
        [Get("/api_tokens")]
        Task<List<ApiTokenDto>> GetApiToken(CancellationToken token);
        #endregion GET Methods

        #region POST Methods
        [Post("/api_tokens")]
        Task<ApiTokenResponse> CreateApiToken([Body] ApiTokenModel newApiToken);
        #endregion POST Methods
    }
}
