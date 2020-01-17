using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCI.Core.BusinessServices.Dtos.Apps;

namespace XamarinCI.Core.BusinessServices.Interfaces.Apps
{
    public interface IAppsService
    {
        #region GET Methods
        Task<List<AppsUserDto>> GetUser(string owner_name, string app_name);
        Task<List<AppsDistributionGroupDto>> GetDistributionGroup(string owner_name, string app_name);
        Task<List<AppsTesterDto>> GetTester(string owner_name, string app_name);
        Task<List<AppsDistributionGroupMemberDto>> GetDistributionGroupMember(string owner_name,
                                                                              string app_name,
                                                                              string distribution_group_name);
        Task<List<AppsAzureSubscriptionDto>> GetAzureSubscription(string owner_name, string app_name);
        #endregion GET Methods

        #region POST Methods
        Task SendInvitation([Body] AppsInvitation newInvitation, string owner_name, string app_name);
        Task<AppsTransferOwnership> TransferOwnership(string owner_name, string app_name, string destination_owner_name);
        Task ResendInvitation([Body] AllUserEmails emailList, string owner_name, string app_name, string distribution_group_name);
        Task<DistributionGroup> CreateDistributionGroup([Body] DistributionGroup newDistributionGroup, string owner_name, string app_name);
        #endregion POST Methods

        #region PATCH Methods
        Task UpdatePendingInvitationPermission([Body] InvitationPermission permission,
                                               string owner_name,
                                               string app_name,
                                               string user_email);
        Task<AppsDistributionGroupDto> UpdateDistributionGroupAttributes([Body] AppsDistributionGroupDto attributes,
                                                                         string owner_name,
                                                                         string app_name,
                                                                         string distribution_group_name);
        #endregion PATCH Methods

        #region DELETE Methods
        Task RemoveAppUserInvitation(string owner_name, string app_name, string user_email);
        Task<AppsDto> DeleteAppAvatar(string owner_name, string app_name);
        Task RemoveUserFromApp(string owner_name, string app_name, string user_email);
        #endregion DELETE Methods
    }
}
