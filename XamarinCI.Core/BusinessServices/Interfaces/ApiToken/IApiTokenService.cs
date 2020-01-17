using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCI.Core.BusinessServices.Dtos.ApiToken;

namespace XamarinCI.Core.BusinessServices.Interfaces.ApiToken
{
    public interface IApiTokenService
    {
        #region GET Methods
        Task<List<ApiTokenDto>> GetApiToken();
        #endregion GET Methods

        #region POST Methods
        Task<ApiTokenResponse> CreateApiToken([Body] ApiTokenModel newApiToken);
        #endregion POST Methods
    }
}
