using System;
namespace XamarinCI.Core.Constants
{
    public static class NameMethodAPI
    {
        public const string GetTesters = "/orgs/{org_name}/testers";
        public const string GetDistributionGroupsDetails = "/orgs/{org_name}/distribution_groups_details";
        public const string GetApps = "/orgs/{org_name}/apps";
        public const string GetUser = "/orgs/{org_name}/users/{user_name}";
        public const string GetTeamUser = "/orgs/{org_name}/teams/{team_name}/users";
    }
    public static class HTTPMethodAPI
    {
        public const string GetMethod = "GET";
        public const string PostMethod = "POST";
        public const string PatchMethod = "PATCH";
        public const string DeletetMethod = "DELECT";
    }
}
