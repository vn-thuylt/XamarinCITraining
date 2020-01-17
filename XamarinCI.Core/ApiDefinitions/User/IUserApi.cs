using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;
using XamarinCI.Core.BusinessServices.Dtos.User;

namespace XamarinCI.Core.ApiDefinitions.User
{
    public interface IUserApi
    {
        #region GET Methods
        [Get("/user")]
        Task<UserDto> Get(CancellationToken token);

        [Get("/user/export/serviceConnections")]
        Task<List<UserExportServiceConnectionsDto>> GetUserExportServiceConnections(CancellationToken token);
        #endregion GET Methods
    }
}
