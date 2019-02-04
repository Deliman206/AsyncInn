using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class hrViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetFriendly",
                table: "HOTELROOM");

            migrationBuilder.AlterColumn<string>(
                name: "RoomNumber",
                table: "HOTELROOM",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Rate",
                table: "HOTELROOM",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RoomNumber",
                table: "HOTELROOM",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "HOTELROOM",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "PetFriendly",
                table: "HOTELROOM",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
