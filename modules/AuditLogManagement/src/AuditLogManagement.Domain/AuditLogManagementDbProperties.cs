namespace AuditLogManagement;

public static class AuditLogManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "AuditLogManagement";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "AuditLogManagement";
}
