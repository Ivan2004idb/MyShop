using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Migrations
{
    /// <inheritdoc />
    public partial class AddSearchKeyWord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchKeywords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Keyword = table.Column<string>(type: "TEXT", nullable: false),
                    PagePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchKeywords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchKeywords");
        }
    }
}
