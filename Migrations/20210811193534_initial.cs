using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DOService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    quti = table.Column<string>(type: "text", nullable: true)
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
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doi_headers", x => x.id);
                    table.ForeignKey(
                        name: "FK_doi_headers_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_doi_owners_doi_headers_doi_header_id",
                        column: x => x.doi_header_id,
                        principalTable: "doi_headers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doi_owners_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doi_headers_organization_id",
                table: "doi_headers",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "IX_doi_owners_doi_header_id",
                table: "doi_owners",
                column: "doi_header_id");

            migrationBuilder.CreateIndex(
                name: "IX_doi_owners_organization_id",
                table: "doi_owners",
                column: "organization_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doi_owners");

            migrationBuilder.DropTable(
                name: "doi_headers");

            migrationBuilder.DropTable(
                name: "organizations");
        }
    }
}
