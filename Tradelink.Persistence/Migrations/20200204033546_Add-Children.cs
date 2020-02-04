using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tradelink.Persistence.Migrations
{
    public partial class AddChildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.AddColumn<Guid>(
                name: "providerId",
                table: "Request",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    RequestId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provider_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Request_providerId",
                table: "Request",
                column: "providerId");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_ContactId",
                table: "Provider",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_RequestId",
                table: "Transaction",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Provider_providerId",
                table: "Request",
                column: "providerId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Provider_providerId",
                table: "Request");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Request_providerId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "providerId",
                table: "Request");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    enabled = table.Column<ulong>(type: "bit(1)", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    password = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    username = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "UK_r43af9ap4edm43mmtq01oddj6",
                table: "users",
                column: "username",
                unique: true);
        }
    }
}
