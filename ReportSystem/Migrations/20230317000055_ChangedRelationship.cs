using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Tenants_TenantId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_TenantId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_AddressId",
                table: "Tenants",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Address_AddressId",
                table: "Tenants",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Address_AddressId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_AddressId",
                table: "Tenants");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Address_TenantId",
                table: "Address",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Tenants_TenantId",
                table: "Address",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
