using System;

using XamarinCI.Core.ApiDefinitions.User;
using XamarinCI.Core.BusinessServices.Dtos.User;
using XamarinCI.Core.BusinessServices.Interfaces.User;

namespace XamarinCI.Core.BusinessServices.Implementations.User
{
    public class IOrgsUsersAPI : IOrgsUsersService
    {
        private readonly IUserApi _userApi;

        public UserService(IUserApi userApi)
        {
            _userApi = userApi;
        }
        public Task<UserDto> Get()
        {
            return _userApi.Get(new System.Threading.CancellationToken());
        }
    }
}
