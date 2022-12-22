using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataFacade.Migrations
{
    /// <inheritdoc />
    public partial class ChangePublishedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Publish",
                table: "Stories",
                newName: "PublishedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishedDate",
                table: "Stories",
                newName: "Publish");
        }
    }
}
