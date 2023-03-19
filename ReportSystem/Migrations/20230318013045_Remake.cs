using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportSystem.Migrations
{
    /// <inheritdoc />
    public partial class Remake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantReports");

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "Tenants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ReportId",
                table: "Tenants",
                column: "ReportId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Reports_ReportId",
                table: "Tenants",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Reports_ReportId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_ReportId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Tenants");

            migrationBuilder.CreateTable(
                name: "TenantReports",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantReports", x => new { x.TenantId, x.ReportId });
                    table.ForeignKey(
                        name: "FK_TenantReports_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantReports_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantReports_ReportId",
                table: "TenantReports",
                column: "ReportId");
        }
    }
}
