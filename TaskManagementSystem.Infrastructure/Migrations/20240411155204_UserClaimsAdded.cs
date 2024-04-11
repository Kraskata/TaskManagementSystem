using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Infrastructure.Migrations
{
    public partial class UserClaimsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15480979-8cbd-44cf-a085-f7e32c1b50f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d67ed46-dc23-4c41-b19d-3941c1446d5d", "AQAAAAEAACcQAAAAEGbzXwEoWxXIm7/z1/zKoqrgo3y2Y3Iu3oqqlw9WMol9PESYS0+p55kR7dbE+T+4eg==", "e4f86eb0-dbcd-42e3-952c-e67c19b317df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d629023b-48be-46c3-85cf-b1c119e9e1ca", "AQAAAAEAACcQAAAAEK26LDvPLWGM8exKqt8iPuXUEQBX4tzU/zGUlmwrG0XIgkniqUu6RzaTKgMlip0eJQ==", "dc7d1b1e-d5f3-40e1-b420-38cbdc964a22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "420735fe-4815-43bc-a616-d062bfb2c39d", "AQAAAAEAACcQAAAAEAaUmFvtGL5Fy2BbFzYVSxRfCAqiaM2eXICwXPiQMkcgVMdA6QQbPL3AgCkeZzMNFA==", "3ce572f4-b692-4a98-a11e-91e4264ed4ce" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15480979-8cbd-44cf-a085-f7e32c1b50f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9eda5ed1-8701-4808-97de-355ffa472367", "AQAAAAEAACcQAAAAEA0FsY96EIVq8T8xkugNp0vZuPdV9SYNWwg0s0KfIH4O+IF2io1Op5Vs//T3amQriw==", "4c8cd62e-2edf-4901-a3e2-fa54c382ada2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd4b45de-9493-4f19-9cc8-248570ab8b3b", "AQAAAAEAACcQAAAAEMyoTaKqhsM2Ilb5U7/q2DUdc1tRa9aIv43FpLOLibzLwAr7WQycl2I11xZTvkucKA==", "a20dedb1-ebfc-4345-9dd3-5615819116d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0634c483-1ad2-4115-ae5d-f4b4de4761ac", "AQAAAAEAACcQAAAAEBGXhF1t3uOmPUKpvlrW89ZRIEtoBsfAAgT2txfThCsQm+hBCARTC8EEEfFMCgXWmA==", "9d9ebc23-e1cd-4565-ae6d-77e50e58bcd7" });
        }
    }
}
