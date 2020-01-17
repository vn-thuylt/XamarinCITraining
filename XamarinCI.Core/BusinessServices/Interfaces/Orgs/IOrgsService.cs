using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using XamarinCI.Core.BusinessServices.Dtos.Orgs;

namespace XamarinCI.Core.BusinessServices.Interfaces.Orgs
{
    public interface IOrgsService
    {
        #region GET Methods 
        Task<List<OrgsTestersDto>> GetTesters(string org_name);
        Task<List<OrgsDistributionGroupsDetailsDto>> GetDistributionGroupsDetails(string org_name);
        Task<List<OrgsAppsDto>> GetApps(string org_name);
        Task<OrgsUserDto> GetUser(string org_name, string user_name);
        Task<List<OrgsTeamUserDto>> GetTeamUser(string org_name, string team_name);
        Task<List<OrgsTeamDto>> GetTeam(string org_name);
        Task<List<OrgsDistributionGroupMemberDto>> GetDistributionGroupMember(string org_name, string distribution_group_name);
        Task<List<OrgsDistributionGroupDto>> GetDistributionGroup(string org_name);
        Task<List<OrgsAadGroupsDto>> GetAadGroups(string org_name);
        #endregion GET Methods

        #region POST Methods
        Task<OrgsTeamApp> CreateAppInTeam([Body] OrgsTeamApp teamApp, string org_name, string team_name);
        Task<AppsModel> CreateAppInOrgs([Body] AppsModel newApp, string org_name);
        Task CreateUserEmail([Body] OrgsDisGrMemBulkDelete newEmail,
                             string org_name,
                             string distribution_group_name);
        Task OrgsUserInvitation([Body] OrgsInvitation invite, string org_name);
        Task<List<AcceptUserResponse>> AddMemberToGroup([Body] MembersInGroup member, string org_name, string distribution_group_name);
        Task<OrgsDistributionGroupDto> CreateDistributionGroup([Body] DistributionGroupModel newDistributionGroup, string org_name);
        #endregion POST Methods

        #region PATCH Methods
        Task<OrgsTeamDto> UpdateSingleTeam([Body] OrgsTeamDto teamItem, string org_name, string team_name);
        Task UpdateUsersRole([Body] OrgsInvitation newRole, string org_name, string email);
        Task<OrgsDto> OrgsList([Body] OrgsDto updateOrgs, string org_name);
        Task<OrgsUserDto> UpdateOrgsUser([Body] RoleChanged userRole, string org_name, string user_name);
        #endregion PATCH Methods

        #region DELETE Methods
        Task RemoveUser(string org_name, string team_name, string user_name);
        Task RemoveUserInvitation([Body] OrgsInvitation invitation, string org_name);
        Task DeleteSingleTeam(string org_name, string team_name);
        Task RemoveUserFromOrgs(string org_name, string user_name);
        #endregion DELETE Methods
    }
}
