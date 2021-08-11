using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DOService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doi_owners",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    organization_id = table.Column<Guid>(type: "uuid", nullable: false),
                    doi_header_id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner_name = table.Column<string>(type: "text", nullable: true),
                    pay_code = table.Column<string>(type: "text", nullable: true),
                    suspense_reason = table.Column<string>(type: "text", nullable: true),
                    interest_type = table.Column<string>(type: "text", nullable: true),
                    nri_decimal = table.Column<decimal>(type: "numeric", nullable: false),
                    burden_group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    effective_from_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    effective_to_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doi_owners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "doi_headers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    organization_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    approved_flag = table.Column<bool>(type: "boolean", nullable: false),
                    approved_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    approved_user_id = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    organization_id1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doi_headers", x => x.id);
                    table.ForeignKey(
                        name: "FK_doi_headers_organizations_organization_id1",
                        column: x => x.organization_id1,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doi_headers_organization_id1",
                table: "doi_headers",
                column: "organization_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doi_headers");

            migrationBuilder.DropTable(
                name: "doi_owners");

            migrationBuilder.DropTable(
                name: "organizations");
        }
    }
}
