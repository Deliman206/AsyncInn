using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class seededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "ROOM",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "The Pad");

            migrationBuilder.UpdateData(
                table: "ROOM",
                keyColumn: "ID",
                keyValue: 2,
                column: "Name",
                value: "Relax and Meditate");

            migrationBuilder.UpdateData(
                table: "ROOM",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "The Get Away");

            migrationBuilder.UpdateData(
                table: "ROOM",
                keyColumn: "ID",
                keyValue: 4,
                column: "Name",
                value: "Comfy Office");

            migrationBuilder.UpdateData(
                table: "ROOM",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "Family Snoozer");

            migrationBuilder.UpdateData(
                table: "ROOM",
                keyColumn: "ID",
                keyValue: 6,
                column: "Name",
                value: "Party Room");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AMENITIES",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AMENITIES",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AMENITIES",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AMENITIES",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AMENITIES",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "ROOM",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "ROOM",
                keyColumn: "ID",
                keyValue: 2,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "ROOM",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "ROOM",
                keyColumn: "ID",
                keyValue: 4,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "ROOM",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "ROOM",
                keyColumn: "ID",
                keyValue: 6,
                column: "Name",
                value: "");
        }
    }
}
