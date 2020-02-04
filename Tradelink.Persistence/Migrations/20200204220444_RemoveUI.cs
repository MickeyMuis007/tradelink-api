using Microsoft.EntityFrameworkCore.Migrations;

namespace Tradelink.Persistence.Migrations
{
    public partial class RemoveUI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Provider_providerId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "UK_Number",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "providerId",
                table: "Request",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_providerId",
                table: "Request",
                newName: "IX_Request_ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Provider_ProviderId",
                table: "Request",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Provider_ProviderId",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Request",
                newName: "providerId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_ProviderId",
                table: "Request",
                newName: "IX_Request_providerId");

            migrationBuilder.CreateIndex(
                name: "UK_Number",
                table: "Request",
                column: "Number",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Provider_providerId",
                table: "Request",
                column: "providerId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
