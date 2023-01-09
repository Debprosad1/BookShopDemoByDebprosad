using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Data.Migrations
{
    public partial class addBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ABook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    BookTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ABook_ABookTypes_BookTypeId",
                        column: x => x.BookTypeId,
                        principalTable: "ABookTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ABook_BookTypeId",
                table: "ABook",
                column: "BookTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ABook");
        }
    }
}
