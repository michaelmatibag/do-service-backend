using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DOService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });

            migrationBuilder.CreateTable(
                name: "doi_owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoiHeaderId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerName = table.Column<string>(type: "text", nullable: true),
                    PayCode = table.Column<string>(type: "text", nullable: true),
                    SuspenseReason = table.Column<string>(type: "text", nullable: true),
                    InterestType = table.Column<string>(type: "text", nullable: true),
                    NriDecimal = table.Column<decimal>(type: "numeric", nullable: false),
                    BurdenGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    EffectiveFromDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EffectiveToDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doi_owners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doi_headers");

            migrationBuilder.DropTable(
                name: "doi_owners");
        }
    }
}
