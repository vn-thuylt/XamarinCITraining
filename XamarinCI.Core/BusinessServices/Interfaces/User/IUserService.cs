using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCI.Core.BusinessServices.Dtos.User;

namespace XamarinCI.Core.BusinessServices.Interfaces.User
{
    public interface IUserService
    {
        #region GET Methods
        Task<UserDto> Get();
        Task<List<UserExportServiceConnectionsDto>> GetUserExportServiceConnections();
        #endregion GET Methods
    }
}
