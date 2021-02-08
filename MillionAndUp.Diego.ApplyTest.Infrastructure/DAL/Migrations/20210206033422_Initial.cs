using Microsoft.EntityFrameworkCore.Migrations;

namespace MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "VARCHAR(45)", maxLength: 45, nullable: false),
                    surname = table.Column<string>(type: "VARCHAR(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "editorials",
                columns: table => new
                {
                    editorial_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(45)", maxLength: 45, nullable: false),
                    headquarter = table.Column<string>(type: "VARCHAR(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editorials", x => x.editorial_id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    isbn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_editorial_id = table.Column<int>(type: "int", nullable: false),
                    fk_author_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "VARCHAR(45)", maxLength: 45, nullable: false),
                    synopsis = table.Column<string>(type: "TEXT", nullable: false),
                    number_of_pages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.isbn);
                    table.ForeignKey(
                        name: "FK_books_authors_fk_author_id",
                        column: x => x.fk_author_id,
                        principalTable: "authors",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_editorials_fk_editorial_id",
                        column: x => x.fk_editorial_id,
                        principalTable: "editorials",
                        principalColumn: "editorial_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_fk_author_id",
                table: "books",
                column: "fk_author_id");

            migrationBuilder.CreateIndex(
                name: "IX_books_fk_editorial_id",
                table: "books",
                column: "fk_editorial_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "editorials");
        }
    }
}
