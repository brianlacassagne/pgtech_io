using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PGTech_io.Migrations
{
    /// <inheritdoc />
    public partial class sectorchanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subsector",
                schema: "identity",
                table: "Sends");

            migrationBuilder.AddColumn<int>(
                name: "IdSubsector",
                schema: "identity",
                table: "Sends",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdsubsectorNavigationId",
                schema: "identity",
                table: "Sends",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sends_IdsubsectorNavigationId",
                schema: "identity",
                table: "Sends",
                column: "IdsubsectorNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sends_Subsectors_IdsubsectorNavigationId",
                schema: "identity",
                table: "Sends",
                column: "IdsubsectorNavigationId",
                principalSchema: "identity",
                principalTable: "Subsectors",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sends_Subsectors_IdsubsectorNavigationId",
                schema: "identity",
                table: "Sends");

            migrationBuilder.DropIndex(
                name: "IX_Sends_IdsubsectorNavigationId",
                schema: "identity",
                table: "Sends");

            migrationBuilder.DropColumn(
                name: "IdSubsector",
                schema: "identity",
                table: "Sends");

            migrationBuilder.DropColumn(
                name: "IdsubsectorNavigationId",
                schema: "identity",
                table: "Sends");

            migrationBuilder.AddColumn<string>(
                name: "subsector",
                schema: "identity",
                table: "Sends",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
