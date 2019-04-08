using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmenityPackages",
                columns: table => new
                {
                    AmenityPackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    AC = table.Column<bool>(nullable: false),
                    OceanView = table.Column<bool>(nullable: false),
                    MountainView = table.Column<bool>(nullable: false),
                    Minibar = table.Column<bool>(nullable: false),
                    PrivateBeach = table.Column<bool>(nullable: false),
                    Hottub = table.Column<bool>(nullable: false),
                    Penthouse = table.Column<bool>(nullable: false),
                    Valet = table.Column<bool>(nullable: false),
                    ContinentalBreakfast = table.Column<bool>(nullable: false),
                    Coffee = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityPackages", x => x.AmenityPackageId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bedrooms = table.Column<int>(nullable: false),
                    Nickname = table.Column<string>(nullable: true),
                    Roomshape = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "RoomLocations",
                columns: table => new
                {
                    RoomLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    PetFriendly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomLocations", x => x.RoomLocationId);
                    table.ForeignKey(
                        name: "FK_RoomLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomLocations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomLocationAmenities",
                columns: table => new
                {
                    RoomLocationId = table.Column<int>(nullable: false),
                    AmenityPackageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomLocationAmenities", x => new { x.RoomLocationId, x.AmenityPackageId });
                    table.ForeignKey(
                        name: "FK_RoomLocationAmenities_AmenityPackages_AmenityPackageId",
                        column: x => x.AmenityPackageId,
                        principalTable: "AmenityPackages",
                        principalColumn: "AmenityPackageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomLocationAmenities_RoomLocations_RoomLocationId",
                        column: x => x.RoomLocationId,
                        principalTable: "RoomLocations",
                        principalColumn: "RoomLocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AmenityPackages",
                columns: new[] { "AmenityPackageId", "AC", "Coffee", "ContinentalBreakfast", "Cost", "Hottub", "Minibar", "MountainView", "Name", "OceanView", "Penthouse", "PrivateBeach", "Valet" },
                values: new object[] { 1, true, true, true, 9001m, true, true, true, "The Fresh", true, true, true, true });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "City", "Name", "Phone", "State" },
                values: new object[] { 1, "123 Place Street", "City of Sea", "Sea City", "1111111111", "Some State" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Bedrooms", "Nickname", "Roomshape" },
                values: new object[,]
                {
                    { 1, 3, "The Boxer", "Square" },
                    { 2, 3, "The Pyramid", "Triangle" },
                    { 3, 2, "The Tower", "Multifloor" },
                    { 4, 0, "The Beer Glass", "Circle" }
                });

            migrationBuilder.InsertData(
                table: "RoomLocations",
                columns: new[] { "RoomLocationId", "LocationId", "PetFriendly", "Price", "RoomId" },
                values: new object[] { 1, 1, true, 1000, 1 });

            migrationBuilder.InsertData(
                table: "RoomLocationAmenities",
                columns: new[] { "RoomLocationId", "AmenityPackageId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_RoomLocationAmenities_AmenityPackageId",
                table: "RoomLocationAmenities",
                column: "AmenityPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomLocations_LocationId",
                table: "RoomLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomLocations_RoomId",
                table: "RoomLocations",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomLocationAmenities");

            migrationBuilder.DropTable(
                name: "AmenityPackages");

            migrationBuilder.DropTable(
                name: "RoomLocations");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
