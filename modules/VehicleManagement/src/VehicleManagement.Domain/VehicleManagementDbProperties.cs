namespace VehicleManagement;

public static class VehicleManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "VehicleManagement";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "VehicleManagement";
}
