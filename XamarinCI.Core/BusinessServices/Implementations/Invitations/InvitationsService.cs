using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCI.Core.ApiDefinitions.Invitations;
using XamarinCI.Core.BusinessServices.Dtos.Invitations;
using XamarinCI.Core.BusinessServices.Interfaces.Invitations;

namespace XamarinCI.Core.BusinessServices.Implementations.Invitations
{
    public class InvitationsService : IInvitationsService
    {
        private readonly IInvitationsApi _invitationsApi;

        public InvitationsService(IInvitationsApi invitationsApi) => _invitationsApi = invitationsApi;

        public Task<List<InvitationsSentDto>> GetInvitationsSent()
        {
            return _invitationsApi.GetInvitationsSent();
        }
    }
}
