namespace Vehicle.App.Permissions;

public static class AppPermissions
{
    public const string GroupName = "App";



    public static class Organization
    {
        public const string GroupName = "OrganizationManagement";
        public const string Default = GroupName + ".Organization";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string ManageMembers = Default + ".ManageMembers";
    }
}
