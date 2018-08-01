using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BwcAgent.Migrations
{
    public partial class AgentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BaseCommission = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Target = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    TargetPeriod = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    IncreaseIfTargetMet = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Maximum = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    RestToBase = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    AgentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleType_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleType_AgentId",
                table: "SaleType",
                column: "AgentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleType");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
