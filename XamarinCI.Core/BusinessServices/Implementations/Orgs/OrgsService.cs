using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCI.Core.ApiDefinitions.Orgs;
using XamarinCI.Core.BusinessServices.Dtos.Orgs;
using XamarinCI.Core.BusinessServices.Interfaces.Orgs;

namespace XamarinCI.Core.BusinessServices.Implementations.Orgs
{
    public class OrgsService : IOrgsService
    {
        private readonly IOrgsApi _orgsApi;

        public OrgsService(IOrgsApi orgsApi) => _orgsApi = orgsApi;

        #region GET Methods
        public Task<List<OrgsTestersDto>> GetTesters(string org_name)
        {
            return _orgsApi.GetTesters(org_name);
        }

        public Task<List<OrgsDistributionGroupsDetailsDto>> GetDistributionGroupsDetails(string org_name)
        {
            return _orgsApi.GetDistributionGroupsDetails(org_name);
        }

        public Task<List<OrgsAppsDto>> GetApps(string org_name)
        {
            return _orgsApi.GetApps(org_name);
        }

        public Task<OrgsUserDto> GetUser(string org_name, string user_name)
        {
            return _orgsApi.GetUser(org_name, user_name);
        }

        public Task<List<OrgsTeamUserDto>> GetTeamUser(string org_name, string team_name)
        {
            return _orgsApi.GetTeamUser(org_name, team_name);
        }

        public Task<List<OrgsTeamDto>> GetTeam(string org_name)
        {
            return _orgsApi.GetTeam(org_name);
        }

        public Task<List<OrgsDistributionGroupMemberDto>> GetDistributionGroupMember(string org_name, string distribution_group_name)
        {
            return _orgsApi.GetDistributionGroupMember(org_name, distribution_group_name);
        }

        public Task<List<OrgsDistributionGroupDto>> GetDistributionGroup(string org_name)
        {
            return _orgsApi.GetDistributionGroup(org_name);
        }

        public Task<List<OrgsAadGroupsDto>> GetAadGroups(string org_name)
        {
            return _orgsApi.GetAadGroup(org_name);
        }
        #endregion GET Methods

        #region POST Methods
        public Task<OrgsTeamApp> CreateAppInTeam([Body] OrgsTeamApp teamApp, string org_name, string team_name)
        {
            return _orgsApi.CreateAppInTeam(teamApp, org_name, team_name);
        }

        public Task<AppsModel> CreateAppInOrgs([Body] AppsModel newApp, string org_name)
        {
            return _orgsApi.CreateAppInOrgs(newApp, org_name);
        }

        public Task CreateUserEmail([Body] OrgsDisGrMemBulkDelete newEmail,
                                    string org_name,
                                    string distribution_group_name)
        {
            return _orgsApi.CreateUserEmail(newEmail, org_name, distribution_group_name);
        }

        public Task OrgsUserInvitation([Body] OrgsInvitation invite, string org_name)
        {
            return _orgsApi.OrgsUserInvitation(invite, org_name);
        }

        public Task<List<AcceptUserResponse>> AddMemberToGroup([Body] MembersInGroup member, string org_name, string distribution_group_name)
        {
            return _orgsApi.AddMemberToGroup(member, org_name, distribution_group_name);
        }

        public Task<OrgsDistributionGroupDto> CreateDistributionGroup([Body] DistributionGroupModel newDistributionGroup, string org_name)
        {
            return _orgsApi.CreateDistributionGroup(newDistributionGroup, org_name);
        }
        #endregion POST Methods

        #region PATCH Methods
        public Task<OrgsTeamDto> UpdateSingleTeam([Body] OrgsTeamDto teamItem, string org_name, string team_name)
        {
            return _orgsApi.UpdateSingleTeam(teamItem, org_name, team_name);
        }

        public Task UpdateUsersRole([Body] OrgsInvitation newRole, string org_name, string email)
        {
            return _orgsApi.UpdateUsersRole(newRole, org_name, email);
        }

        public Task<OrgsDto> OrgsList([Body] OrgsDto updateOrgs, string org_name)
        {
            return _orgsApi.OrgsList(updateOrgs, org_name);
        }

        public Task<OrgsUserDto> UpdateOrgsUser([Body] RoleChanged userRole, string org_name, string user_name)
        {
            return _orgsApi.UpdateOrgsUser(userRole, org_name, user_name);
        }
        #endregion PATCH Methods

        #region DELETE Methods
        public Task RemoveUser(string org_name, string team_name, string user_name)
        {
            return _orgsApi.RemoveUser(org_name, team_name, user_name);
        }

        public Task RemoveUserInvitation([Body] OrgsInvitation invitation, string org_name)
        {
            return _orgsApi.RemoveUserInvitation(invitation, org_name);
        }

        public Task DeleteSingleTeam(string org_name, string team_name)
        {
            return _orgsApi.DeleteSingleTeam(org_name, team_name);
        }

        public Task RemoveUserFromOrgs(string org_name, string user_name)
        {
            return _orgsApi.RemoveUserFromOrgs(org_name, user_name);
        }
        #endregion DELETE Methods
    }
}
