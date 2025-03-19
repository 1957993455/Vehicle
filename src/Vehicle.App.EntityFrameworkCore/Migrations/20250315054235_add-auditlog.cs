using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle.App.Migrations
{
    /// <inheritdoc />
    public partial class addauditlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WxUnionId",
                table: "AbpUsers",
                newName: "wxUnionId");

            migrationBuilder.RenameColumn(
                name: "WxOpenId",
                table: "AbpUsers",
                newName: "wxOpenId");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "AbpUsers",
                newName: "sex");

            migrationBuilder.RenameColumn(
                name: "RealName",
                table: "AbpUsers",
                newName: "realName");

            migrationBuilder.RenameColumn(
                name: "IsVerified",
                table: "AbpUsers",
                newName: "isVerified");

            migrationBuilder.RenameColumn(
                name: "IDCardNo",
                table: "AbpUsers",
                newName: "idCardNo");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "AbpUsers",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "AbpUsers",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Avatar",
                table: "AbpUsers",
                newName: "avatar");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "AbpUsers",
                newName: "area");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "AbpUsers",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AbpUsers",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "AbpRoles",
                newName: "displayName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "wxUnionId",
                table: "AbpUsers",
                newName: "WxUnionId");

            migrationBuilder.RenameColumn(
                name: "wxOpenId",
                table: "AbpUsers",
                newName: "WxOpenId");

            migrationBuilder.RenameColumn(
                name: "sex",
                table: "AbpUsers",
                newName: "Sex");

            migrationBuilder.RenameColumn(
                name: "realName",
                table: "AbpUsers",
                newName: "RealName");

            migrationBuilder.RenameColumn(
                name: "isVerified",
                table: "AbpUsers",
                newName: "IsVerified");

            migrationBuilder.RenameColumn(
                name: "idCardNo",
                table: "AbpUsers",
                newName: "IDCardNo");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "AbpUsers",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "AbpUsers",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "avatar",
                table: "AbpUsers",
                newName: "Avatar");

            migrationBuilder.RenameColumn(
                name: "area",
                table: "AbpUsers",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "AbpUsers",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "AbpUsers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "displayName",
                table: "AbpRoles",
                newName: "DisplayName");
        }
    }
}
