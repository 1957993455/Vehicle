using Vehicle.App.Domain.Shared.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Vehicle.App.Application.Contracts.Permissions;

public class AppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AppPermissions.GroupName);

        // 组织分组
        var orgGroup = context.AddGroup(
            AppPermissions.Organization.GroupName,
            L("Permission:OrganizationManagement"));

        var orgPermission = orgGroup.AddPermission(
            AppPermissions.Organization.Default,
            L("Permission:Organization"));

        orgPermission.AddChild(
            AppPermissions.Organization.Create,
            L("Permission:Organization.Create"));
        orgPermission.AddChild(
            AppPermissions.Organization.Update,
            L("Permission:Organization.Update"));
        orgPermission.AddChild(
            AppPermissions.Organization.Delete,
            L("Permission:Organization.Delete"));
        orgPermission.AddChild(
            AppPermissions.Organization.ManageMembers,
            L("Permission:Organization.ManageMembers"));

        // 车辆管理分组
        var vehicleGroup = context.AddGroup(
            AppPermissions.Vehicle.GroupName,
            L("Permission:VehicleManagement"));

        var vehiclePermission = vehicleGroup.AddPermission(
            AppPermissions.Vehicle.Default,
            L("Permission:Vehicle"));

        vehiclePermission.AddChild(
            AppPermissions.Vehicle.Create,
            L("Permission:Vehicle.Create"));
        vehiclePermission.AddChild(
            AppPermissions.Vehicle.Update,
            L("Permission:Vehicle.Update"));
        vehiclePermission.AddChild(
            AppPermissions.Vehicle.Delete,
            L("Permission:Vehicle.Delete"));
        vehiclePermission.AddChild(
            AppPermissions.Vehicle.UpdateMileage,
            L("Permission:Vehicle.UpdateMileage"));
        vehiclePermission.AddChild(
            AppPermissions.Vehicle.ChangeStatus,
            L("Permission:Vehicle.ChangeStatus"));

        // 维护记录分组
        var maintenanceGroup = context.AddGroup(
            AppPermissions.MaintenanceRecord.GroupName,
            L("Permission:MaintenanceManagement"));

        var maintenancePermission = maintenanceGroup.AddPermission(
            AppPermissions.MaintenanceRecord.Default,
            L("Permission:MaintenanceRecord"));

        maintenancePermission.AddChild(
            AppPermissions.MaintenanceRecord.Create,
            L("Permission:MaintenanceRecord.Create"));
        maintenancePermission.AddChild(
            AppPermissions.MaintenanceRecord.View,
            L("Permission:MaintenanceRecord.View"));

        // 门店分组
        var storeGroup = context.AddGroup(
            AppPermissions.Store.GroupName,
            L("Permission:StoreManagement"));

        var storePermission = storeGroup.AddPermission(
            AppPermissions.Store.Default,
            L("Permission:Store"));

        storePermission.AddChild(
            AppPermissions.Store.Create,
            L("Permission:Store.Create"));
        storePermission.AddChild(
            AppPermissions.Store.Update,
            L("Permission:Store.Update"));
        storePermission.AddChild(
            AppPermissions.Store.Delete,
            L("Permission:Store.Delete"));
        storePermission.AddChild(
            AppPermissions.Store.ChangeStatus,
            L("Permission:Store.ChangeStatus"));
        storePermission.AddChild(
            AppPermissions.Store.Relocate,
            L("Permission:Store.Relocate"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AppResource>(name);
    }
}
