using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "755425b1-8c9f-4496-8cd8-7065271d2382", "", "", "AQAAAAEAACcQAAAAEJfZELyIebJyB7GnxLQ+TR8saDnWBlmQ9c/sl1q36eECC3xofjP1i3Z6DE0M4C7INQ==", "d46b705a-f17a-4a32-b343-3406cbc55c5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd406bb1-667f-4c98-b9a4-fd587cc99c6d", "", "", "AQAAAAEAACcQAAAAEAVttopSTtA/4GjayKJ+UbZYCZdSGKUHZsKVe666KDVL68XnlffUgRwJKJTgDwaGRQ==", "10d38ae0-7300-4a33-b7ba-4b5bbb7d49b9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fe4cde1-08db-41ac-9cc8-3eb037b2bbdc", "AQAAAAEAACcQAAAAEKdoJDP8d1eVZib/upMkpR7Sz9nxv2mKExlWBq+7Y1DYhCK3J/zIs5yaiFdx0uBACQ==", "9d8c93bd-3eb1-4f2f-bf47-ca4148850097" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28855f92-e0ed-4a68-a416-c9112fedde94", "AQAAAAEAACcQAAAAEKaKiF4dH+3TuE6UPE81cwGwY94IrK54u3vQ1wQ9AWavvi8bKGH6xeXiWz1xIQif/A==", "ebee90e1-20dc-4be5-8f97-8698de3a892e" });
        }
    }
}
