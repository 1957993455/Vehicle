using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle.App.Migrations
{
    /// <inheritdoc />
#pragma warning disable IDE1006 // 命名样式
    public partial class addidentity : Migration
#pragma warning restore IDE1006 // 命名样式
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AbpUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDCardNo",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "AbpUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealName",
                table: "AbpUsers",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "AbpUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WxOpenId",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WxUnionId",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AbpRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "IDCardNo",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "RealName",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "WxOpenId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "WxUnionId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AbpRoles");
        }
    }
}
