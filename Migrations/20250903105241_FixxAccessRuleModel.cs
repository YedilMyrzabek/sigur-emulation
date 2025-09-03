using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sigur_emulation.Migrations
{
    /// <inheritdoc />
    public partial class FixxAccessRuleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessRoles_Personnels_EmployeeId",
                table: "AccessRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessRoles",
                table: "AccessRoles");

            migrationBuilder.RenameTable(
                name: "AccessRoles",
                newName: "AccessRules");

            migrationBuilder.RenameIndex(
                name: "IX_AccessRoles_EmployeeId_AccessRuleId",
                table: "AccessRules",
                newName: "IX_AccessRules_EmployeeId_AccessRuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessRules",
                table: "AccessRules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessRules_Personnels_EmployeeId",
                table: "AccessRules",
                column: "EmployeeId",
                principalTable: "Personnels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessRules_Personnels_EmployeeId",
                table: "AccessRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessRules",
                table: "AccessRules");

            migrationBuilder.RenameTable(
                name: "AccessRules",
                newName: "AccessRoles");

            migrationBuilder.RenameIndex(
                name: "IX_AccessRules_EmployeeId_AccessRuleId",
                table: "AccessRoles",
                newName: "IX_AccessRoles_EmployeeId_AccessRuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessRoles",
                table: "AccessRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessRoles_Personnels_EmployeeId",
                table: "AccessRoles",
                column: "EmployeeId",
                principalTable: "Personnels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
