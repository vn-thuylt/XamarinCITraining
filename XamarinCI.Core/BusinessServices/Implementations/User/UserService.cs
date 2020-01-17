using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XamarinCI.Core.ApiDefinitions.User;
using XamarinCI.Core.BusinessServices.Dtos.User;
using XamarinCI.Core.BusinessServices.Interfaces.User;

namespace XamarinCI.Core.BusinessServices.Implementations.User
{
    public class UserService : IUserService
    {
        private readonly IUserApi _userApi;

        public UserService(IUserApi userApi) => _userApi = userApi;

        #region GET Methods
        public Task<UserDto> Get()
        {
            return _userApi.Get(new CancellationToken());
        }

        public Task<List<UserExportServiceConnectionsDto>> GetUserExportServiceConnections()
        {
            return _userApi.GetUserExportServiceConnections(new CancellationToken());
        }
        #endregion GET Methods
    }
}
