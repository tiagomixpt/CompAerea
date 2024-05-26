using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompAerea.Infrastrutura.Migrations
{
    /// <inheritdoc />
    public partial class AddFlightToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plane = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightNumber",
                columns: table => new
                {
                    Flight_Number = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightNumber", x => x.Flight_Number);
                    table.ForeignKey(
                        name: "FK_FlightNumber_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Description", "FlightFrom", "FlightTo", "ImageUrl", "Plane", "Price", "Seats" },
                values: new object[,]
                {
                    { 1, "Fast plane with lots of seats", "Portugal", "Italy", "https://placehold.co/600x400", "Airbus A300", 25000.0, 200 },
                    { 2, "Comercial plane with Origin in France and Italy ", "France", "Italy", "https://placehold.co/600x400", "ATR 72", 30000.0, 125 },
                    { 3, "A Turboprop Regional Airliner", "France", "Switzerland", "https://placehold.co/600x400", "ATR 42", 15000.0, 80 }
                });

            migrationBuilder.InsertData(
                table: "FlightNumber",
                columns: new[] { "Flight_Number", "Details", "FlightId" },
                values: new object[,]
                {
                    { 101, null, 1 },
                    { 102, null, 1 },
                    { 103, null, 1 },
                    { 104, null, 1 },
                    { 201, null, 2 },
                    { 202, null, 2 },
                    { 203, null, 2 },
                    { 301, null, 3 },
                    { 302, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightNumber_FlightId",
                table: "FlightNumber",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightNumber");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
