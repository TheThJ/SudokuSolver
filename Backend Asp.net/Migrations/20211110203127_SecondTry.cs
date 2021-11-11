using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class SecondTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cell_Tables_Tableid",
                table: "Cell");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cell",
                table: "Cell");

            migrationBuilder.DropIndex(
                name: "IX_Cell_Tableid",
                table: "Cell");

            migrationBuilder.DropColumn(
                name: "Tableid",
                table: "Cell");

            migrationBuilder.RenameTable(
                name: "Cell",
                newName: "Cells");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "Cells",
                newName: "cellValue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cells",
                table: "Cells",
                columns: new[] { "row", "col" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cells",
                table: "Cells");

            migrationBuilder.RenameTable(
                name: "Cells",
                newName: "Cell");

            migrationBuilder.RenameColumn(
                name: "cellValue",
                table: "Cell",
                newName: "value");

            migrationBuilder.AddColumn<int>(
                name: "Tableid",
                table: "Cell",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cell",
                table: "Cell",
                columns: new[] { "row", "col" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Cell_Tableid",
                table: "Cell",
                column: "Tableid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cell_Tables_Tableid",
                table: "Cell",
                column: "Tableid",
                principalTable: "Tables",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
