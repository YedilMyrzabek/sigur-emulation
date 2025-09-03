using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sigur_emulation.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoToPersonnel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Personnels",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Personnels");
        }
    }
}
