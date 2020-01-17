using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCI.Core.BusinessServices.Dtos.Invitations;

namespace XamarinCI.Core.ApiDefinitions.Invitations
{
    public interface IInvitationsApi
    {
        #region GET Methods
        [Get("/invitations/sent")]
        Task<List<InvitationsSentDto>> GetInvitationsSent();
        #endregion GET Methods
    }
}