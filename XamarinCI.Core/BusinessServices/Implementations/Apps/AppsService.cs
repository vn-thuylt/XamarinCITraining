using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCI.Core.ApiDefinitions.Apps;
using XamarinCI.Core.BusinessServices.Dtos.Apps;
using XamarinCI.Core.BusinessServices.Interfaces.Apps;

namespace XamarinCI.Core.BusinessServices.Implementations.Apps
{
    public class AppsService : IAppsService
    {
        private readonly IAppsApi _appsApi;

        public AppsService(IAppsApi appsApi) => _appsApi = appsApi;

        #region GET Methods
        public Task<List<AppsUserDto>> GetUser(string owner_name, string app_name)
        {
            return _appsApi.GetUser(owner_name, app_name);
        }

        public Task<List<AppsDistributionGroupDto>> GetDistributionGroup(string owner_name, string app_name)
        {
            return _appsApi.GetDistributionGroup(owner_name, app_name);
        }

        public Task<List<AppsTesterDto>> GetTester(string owner_name, string app_name)
        {
            return _appsApi.GetTester(owner_name, app_name);
        }

        public Task<List<AppsDistributionGroupMemberDto>> GetDistributionGroupMember(string owner_name,
                                                                                     string app_name,
                                                                                     string distribution_group_name)
        {
            return _appsApi.GetDistributionGroupMember(owner_name, app_name, distribution_group_name);
        }

        public Task<List<AppsAzureSubscriptionDto>> GetAzureSubscription(string owner_name, string app_name)
        {
            return _appsApi.GetAzureSubscription(owner_name, app_name);
        }
        #endregion GET Methods

        #region POST Methods
        public Task SendInvitation([Body] AppsInvitation newInvitation, string owner_name, string app_name)
        {
            return _appsApi.SendInvitation(newInvitation, owner_name, app_name);
        }

        public Task<AppsTransferOwnership> TransferOwnership(string owner_name, string app_name, string destination_owner_name)
        {
            return _appsApi.TransferOwnership(owner_name, app_name, destination_owner_name);
        }

        public Task ResendInvitation([Body] AllUserEmails emailList, string owner_name, string app_name, string distribution_group_name)
        {
            return _appsApi.ResendInvitation(emailList, owner_name, app_name, distribution_group_name);
        }

        public Task<DistributionGroup> CreateDistributionGroup([Body] DistributionGroup newDistributionGroup, string owner_name, string app_name)
        {
            return _appsApi.CreateDistributionGroup(newDistributionGroup, owner_name, app_name);
        }
        #endregion POST Methods

        #region PATCH Methods
        public Task UpdatePendingInvitationPermission([Body] InvitationPermission permission,
                                                      string owner_name,
                                                      string app_name,
                                                      string user_email)
        {
            return _appsApi.UpdatePendingInvitationPermission(permission, owner_name, app_name, user_email);
        }

        public Task<AppsDistributionGroupDto> UpdateDistributionGroupAttributes([Body] AppsDistributionGroupDto attributes,
                                                                                string owner_name,
                                                                                string app_name,
                                                                                string distribution_group_name)
        {
            return _appsApi.UpdateDistributionGroupAttributes(attributes, owner_name, app_name, distribution_group_name);
        }
        #endregion PATCH Methods

        #region DELETE Methods
        public Task RemoveAppUserInvitation(string owner_name, string app_name, string user_email)
        {
            return _appsApi.RemoveAppUserInvitation(owner_name, app_name, user_email);
        }

        public Task<AppsDto> DeleteAppAvatar(string owner_name, string app_name)
        {
            return _appsApi.DeleteAppAvatar(owner_name, app_name);
        }

        public Task RemoveUserFromApp(string owner_name, string app_name, string user_email)
        {
            return _appsApi.RemoveUserFromApp(owner_name, app_name, user_email);
        }
        #endregion DELETE Methods
    }
}
