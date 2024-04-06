using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Infrastructure.Migrations
{
    public partial class UniqueConstraintForNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_PhoneNumber",
                table: "Assignees",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Assignees_PhoneNumber",
                table: "Assignees");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "593baa47-2b6a-4cf8-abb5-aad19155dc13", "AQAAAAEAACcQAAAAEN7FiHMjRkrzdmPPCJ96vm//qwa+yhQLGKGuqhtHkJUbogfutWq4T3n/YTtfFNVJZQ==", "35cc91bc-2d39-48d5-b7a2-7f04c9f46a1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "017c946c-5e34-4476-9d6c-ffeb2ec09ec0", "AQAAAAEAACcQAAAAED53hDj4JIaLoT5v3b2r7U0lcRAvQCxtC5NukSdu/Pchnx2L5vzHrpeEjkYwqhmMUQ==", "6698997f-47a7-4d82-b97d-5f1ddb0edb75" });
        }
    }
}
