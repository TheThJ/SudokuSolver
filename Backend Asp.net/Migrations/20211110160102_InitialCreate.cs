using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cell",
                columns: table => new
                {
                    row = table.Column<int>(type: "int", nullable: false),
                    col = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tableid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cell", x => new { x.row, x.col });
                    table.ForeignKey(
                        name: "FK_Cell_Tables_Tableid",
                        column: x => x.Tableid,
                        principalTable: "Tables",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cell",
                columns: new[] { "col", "row", "Tableid", "value" },
                values: new object[,]
                {
                    { 2, 0, null, "1" },
                    { 5, 7, null, "9" },
                    { 3, 7, null, "1" },
                    { 8, 6, null, "9" },
                    { 5, 6, null, "4" },
                    { 3, 6, null, "3" },
                    { 0, 6, null, "1" },
                    { 7, 5, null, "3" },
                    { 6, 5, null, "6" },
                    { 2, 5, null, "4" },
                    { 1, 5, null, "5" },
                    { 2, 8, null, "2" },
                    { 7, 3, null, "5" },
                    { 2, 3, null, "8" },
                    { 1, 3, null, "2" },
                    { 8, 2, null, "1" },
                    { 5, 2, null, "6" },
                    { 3, 2, null, "9" },
                    { 0, 2, null, "3" },
                    { 8, 1, null, "3" },
                    { 5, 1, null, "8" },
                    { 3, 1, null, "4" },
                    { 6, 0, null, "7" },
                    { 6, 3, null, "1" },
                    { 6, 8, null, "3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cell_Tableid",
                table: "Cell",
                column: "Tableid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cell");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
