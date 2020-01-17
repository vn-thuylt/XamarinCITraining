using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCI.Core.BusinessServices.Dtos.Orgs;

namespace XamarinCI.Core.ApiDefinitions.Orgs
{
    public interface IOrgsApi
    {
        #region GET Methods
        [Get("/orgs/{org_name}/testers")]
        Task<List<OrgsTestersDto>> GetTesters(string org_name);

        [Get("/orgs/{org_name}/distribution_groups_details")]
        Task<List<OrgsDistributionGroupsDetailsDto>> GetDistributionGroupsDetails(string org_name);

        [Get("/orgs/{org_name}/apps")]
        Task<List<OrgsAppsDto>> GetApps(string org_name);

        [Get("/orgs/{org_name}/users/{user_name}")]
        Task<OrgsUserDto> GetUser(string org_name, string user_name);

        [Get("/orgs/{org_name}/teams/{team_name}/users")]
        Task<List<OrgsTeamUserDto>> GetTeamUser(string org_name, string team_name);

        [Get("/orgs/{org_name}/teams")]
        Task<List<OrgsTeamDto>> GetTeam(string org_name);

        [Get("/orgs/{org_name}/distribution_groups/{distribution_group_name}/members")]
        Task<List<OrgsDistributionGroupMemberDto>> GetDistributionGroupMember(string org_name, string distribution_group_name);

        [Get("/orgs/{org_name}/distribution_groups")]
        Task<List<OrgsDistributionGroupDto>> GetDistributionGroup(string org_name);

        [Get("/orgs/{org_name}/aad_groups")]
        Task<List<OrgsAadGroupsDto>> GetAadGroup(string org_name);
        #endregion GET Methods

        #region POST Methods
        [Post("/orgs/{org_name}/teams/{team_name}/apps")]
        Task<OrgsTeamApp> CreateAppInTeam([Body] OrgsTeamApp teamApp, string org_name, string team_name);

        [Post("/orgs/{org_name}/apps")]
        Task<AppsModel> CreateAppInOrgs([Body] AppsModel newApp, string org_name);

        [Post("/orgs/{org_name}/distribution_groups/{distribution_group_name}/members/bulk_delete")]
        Task CreateUserEmail([Body] OrgsDisGrMemBulkDelete newEmail,
                             string org_name,
                             string distribution_group_name);

        [Post("/orgs/{org_name}/invitations")]
        Task OrgsUserInvitation([Body] OrgsInvitation invite, string org_name);

        [Post("/orgs/{org_name}/distribution_groups/{distribution_group_name}/members")]
        Task<List<AcceptUserResponse>> AddMemberToGroup([Body] MembersInGroup member, string org_name, string distribution_group_name);

        [Post("/orgs/{org_name}/distribution_groups")]
        Task<OrgsDistributionGroupDto> CreateDistributionGroup([Body] DistributionGroupModel newDistributionGroup, string org_name);
        #endregion POST Methods

        #region PATCH Methods
        [Patch("/orgs/{org_name}/teams/{team_name}")]
        Task<OrgsTeamDto> UpdateSingleTeam([Body] OrgsTeamDto teamItem, string org_name, string team_name);

        [Patch("/orgs/{org_name}/invitations/{email}")]
        Task UpdateUsersRole([Body] OrgsInvitation newRole, string org_name, string email);

        [Patch("/orgs/{org_name}")]
        Task<OrgsDto> OrgsList([Body] OrgsDto updateOrgs, string org_name);

        [Patch("/orgs/{org_name}/users/{user_name}")]
        Task<OrgsUserDto> UpdateOrgsUser([Body] RoleChanged userRole, string org_name, string user_name);
        #endregion PATCH Methods

        #region DELETE Methods
        [Delete("/orgs/{org_name}/teams/{team_name}/users/{user_name}")]
        Task RemoveUser(string org_name, string team_name, string user_name);

        [Delete("/orgs/{org_name}/invitations")]
        Task RemoveUserInvitation([Body] OrgsInvitation invitation, string org_name);

        [Delete("/orgs/{org_name}/teams/{team_name}")]
        Task DeleteSingleTeam(string org_name, string team_name);

        [Delete("/orgs/{org_name}/users/{user_name}")]
        Task RemoveUserFromOrgs(string org_name, string user_name);
        #endregion DELETE Methods
    }
}