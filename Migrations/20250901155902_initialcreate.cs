using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sigur_emulation.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "jsonb", nullable: false),
                    ShortName = table.Column<string>(type: "jsonb", nullable: false),
                    ExternalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Organizations_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "jsonb", nullable: false),
                    ShortName = table.Column<string>(type: "jsonb", nullable: false),
                    ExternalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StructuralUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "jsonb", nullable: false),
                    ShortName = table.Column<string>(type: "jsonb", nullable: true),
                    ExternalId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StructuralUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StructuralUnits_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StructuralUnits_StructuralUnits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "StructuralUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Personnels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    PositionId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    StructuralUnitId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExternalId = table.Column<int>(type: "integer", nullable: false),
                    TabulatedNumber = table.Column<string>(type: "text", nullable: false),
                    IsUnderground = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnels_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personnels_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personnels_StructuralUnits_StructuralUnitId",
                        column: x => x.StructuralUnitId,
                        principalTable: "StructuralUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ExternalId",
                table: "Organizations",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ParentId",
                table: "Organizations",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_ExternalId",
                table: "Personnels",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_OrganizationId",
                table: "Personnels",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_PositionId",
                table: "Personnels",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_StructuralUnitId",
                table: "Personnels",
                column: "StructuralUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_TabulatedNumber",
                table: "Personnels",
                column: "TabulatedNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_ExternalId",
                table: "Positions",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StructuralUnits_ExternalId",
                table: "StructuralUnits",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StructuralUnits_OrganizationId",
                table: "StructuralUnits",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_StructuralUnits_ParentId",
                table: "StructuralUnits",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personnels");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "StructuralUnits");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
