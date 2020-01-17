using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCI.Core.BusinessServices.Dtos.Apps;

namespace XamarinCI.Core.ApiDefinitions.Apps
{
    public interface IAppsApi
    {
        #region GET Methods
        [Get("/apps/{owner_name}/{app_name}/users")]
        Task<List<AppsUserDto>> GetUser(string owner_name, string app_name);

        [Get("/apps/{owner_name}/{app_name}/distribution_groups")]
        Task<List<AppsDistributionGroupDto>> GetDistributionGroup(string owner_name, string app_name);

        [Get("/apps/{owner_name}/{app_name}/testers")]
        Task<List<AppsTesterDto>> GetTester(string owner_name, string app_name);

        [Get("/apps/{owner_name}/{app_name}/distribution_groups/{distribution_group_name}/members")]
        Task<List<AppsDistributionGroupMemberDto>> GetDistributionGroupMember(string owner_name,
                                                                              string app_name,
                                                                              string distribution_group_name);

        [Get("/apps/{owner_name}/{app_name}/azure_subscriptions")]
        Task<List<AppsAzureSubscriptionDto>> GetAzureSubscription(string owner_name, string app_name);
        #endregion GET Methods

        #region POST Methods
        [Post("/apps/{owner_name}/{app_name}/invitations")]
        Task SendInvitation([Body] AppsInvitation newInvitation, string owner_name, string app_name);

        [Post("/apps/{owner_name}/{app_name}/transfer/{destination_owner_name}")]
        Task<AppsTransferOwnership> TransferOwnership(string owner_name, string app_name, string destination_owner_name);

        [Post("/apps/{owner_name}/{app_name}/distribution_groups/{distribution_group_name}/resend_invite")]
        Task ResendInvitation([Body] AllUserEmails emailList, string owner_name, string app_name, string distribution_group_name);

        [Post("/apps/{owner_name}/{app_name}/distribution_groups")]
        Task<DistributionGroup> CreateDistributionGroup([Body] DistributionGroup newDistributionGroup, string owner_name, string app_name);
        #endregion POST Methods

        #region PATCH Methods
        [Patch("/apps/{owner_name}/{app_name}/invitations/{user_email}")]
        Task UpdatePendingInvitationPermission([Body] InvitationPermission permission,
                                               string owner_name,
                                               string app_name,
                                               string user_email);

        [Patch("/apps/{owner_name}/{app_name}/distribution_groups/{distribution_group_name}")]
        Task<AppsDistributionGroupDto> UpdateDistributionGroupAttributes([Body] AppsDistributionGroupDto attributes,
                                                                         string owner_name,
                                                                         string app_name,
                                                                         string distribution_group_name);
        #endregion PATCH Methods

        #region DELETE Methods
        [Delete("/apps/{owner_name}/{app_name}/invitations/{user_email}")]
        Task RemoveAppUserInvitation(string owner_name, string app_name, string user_email);

        [Delete("/apps/{owner_name}/{app_name}/avatar")]
        Task<AppsDto> DeleteAppAvatar(string owner_name, string app_name);

        [Delete("/apps/{owner_name}/{app_name}/users/{user_email}")]
        Task RemoveUserFromApp(string owner_name, string app_name, string user_email);
        #endregion DELETE Methods
    }
}
