using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AMENITIES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AMENITIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HOTEL",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Phone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOTEL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROOM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Layout = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROOM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HOTELROOM",
                columns: table => new
                {
                    HotelID = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<string>(nullable: true),
                    Rate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOTELROOM", x => new { x.HotelID, x.RoomID });
                    table.ForeignKey(
                        name: "FK_HOTELROOM_HOTEL_HotelID",
                        column: x => x.HotelID,
                        principalTable: "HOTEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HOTELROOM_ROOM_RoomID",
                        column: x => x.RoomID,
                        principalTable: "ROOM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ROOMAMENITIES",
                columns: table => new
                {
                    AmenitiesID = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROOMAMENITIES", x => new { x.RoomID, x.AmenitiesID });
                    table.ForeignKey(
                        name: "FK_ROOMAMENITIES_AMENITIES_AmenitiesID",
                        column: x => x.AmenitiesID,
                        principalTable: "AMENITIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ROOMAMENITIES_ROOM_RoomID",
                        column: x => x.RoomID,
                        principalTable: "ROOM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AMENITIES",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Coffee Maker" },
                    { 2, "TV" },
                    { 3, "WiFi" },
                    { 4, "Bathroom Attire" },
                    { 5, "Mini Bar" }
                });

            migrationBuilder.InsertData(
                table: "HOTEL",
                columns: new[] { "ID", "City", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Seattle", "Hotel Seattle", 2065556699L },
                    { 2, "Colorado Springs", "Hotel Springs", 5095556699L },
                    { 3, "Paia", "Hotel Surf", 8085556699L },
                    { 4, "Salem", "Hotel Magic", 2065556699L },
                    { 5, "Las Vegas", "Hotel Risk", 2065556699L }
                });

            migrationBuilder.InsertData(
                table: "ROOM",
                columns: new[] { "ID", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 0, "The Pad" },
                    { 2, 0, "Relax and Meditate" },
                    { 3, 1, "The Get Away" },
                    { 4, 1, "Comfy Office" },
                    { 5, 2, "Family Snoozer" },
                    { 6, 2, "Party Room" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HOTELROOM_RoomID",
                table: "HOTELROOM",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_ROOMAMENITIES_AmenitiesID",
                table: "ROOMAMENITIES",
                column: "AmenitiesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HOTELROOM");

            migrationBuilder.DropTable(
                name: "ROOMAMENITIES");

            migrationBuilder.DropTable(
                name: "HOTEL");

            migrationBuilder.DropTable(
                name: "AMENITIES");

            migrationBuilder.DropTable(
                name: "ROOM");
        }
    }
}
