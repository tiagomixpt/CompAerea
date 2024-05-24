using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompAerea.Infrastrutura.Migrations
{
    /// <inheritdoc />
    public partial class AddVoosToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voos",
                columns: table => new
                {
                    Numero_Voo = table.Column<int>(type: "int", nullable: false),
                    AvioesId = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voos", x => x.Numero_Voo);
                    table.ForeignKey(
                        name: "FK_Voos_Avioes_AvioesId",
                        column: x => x.AvioesId,
                        principalTable: "Avioes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Voos",
                columns: new[] { "Numero_Voo", "AvioesId", "Details" },
                values: new object[,]
                {
                    { 102, 1, null },
                    { 103, 1, null },
                    { 104, 1, null },
                    { 111, 1, null },
                    { 201, 2, null },
                    { 202, 2, null },
                    { 203, 2, null },
                    { 301, 3, null },
                    { 302, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voos_AvioesId",
                table: "Voos",
                column: "AvioesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voos");
        }
    }
}
