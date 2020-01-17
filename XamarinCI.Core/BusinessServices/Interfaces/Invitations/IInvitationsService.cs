using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCI.Core.BusinessServices.Dtos.Invitations;

namespace XamarinCI.Core.BusinessServices.Interfaces.Invitations
{
    public interface IInvitationsService
    {
        #region GET Methods
        Task<List<InvitationsSentDto>> GetInvitationsSent();
        #endregion GET Methods
    }
}