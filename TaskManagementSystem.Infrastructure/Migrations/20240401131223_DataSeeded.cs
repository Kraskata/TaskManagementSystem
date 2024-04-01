using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Infrastructure.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "593baa47-2b6a-4cf8-abb5-aad19155dc13", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEN7FiHMjRkrzdmPPCJ96vm//qwa+yhQLGKGuqhtHkJUbogfutWq4T3n/YTtfFNVJZQ==", null, false, "35cc91bc-2d39-48d5-b7a2-7f04c9f46a1f", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "017c946c-5e34-4476-9d6c-ffeb2ec09ec0", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAED53hDj4JIaLoT5v3b2r7U0lcRAvQCxtC5NukSdu/Pchnx2L5vzHrpeEjkYwqhmMUQ==", null, false, "6698997f-47a7-4d82-b97d-5f1ddb0edb75", false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Minimal" },
                    { 2, "High Threat" },
                    { 3, "Critical" }
                });

            migrationBuilder.InsertData(
                table: "Assignees",
                columns: new[] { "Id", "Gmail", "PhoneNumber", "UserId" },
                values: new object[] { 1, "", "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "Assigned", "AssigneeId", "CategoryId", "Description", "DoneBy", "Paid", "Title", "WorkerId" },
                values: new object[] { 1, "03/27/2024", 1, 3, "The domain tables have the wrong properties.", "04/05/2024", 2100.00m, "Domain Tables", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "Assigned", "AssigneeId", "CategoryId", "Description", "DoneBy", "Paid", "Title", "WorkerId" },
                values: new object[] { 2, "03/23/2024", 1, 1, "We require more guest users, alongside a new level of threat inside the categories (modify the domain tables).", "05/22/2024", 2100.00m, "More Data Seeded Needed (Testing Purposes)", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "Assigned", "AssigneeId", "CategoryId", "Description", "DoneBy", "Paid", "Title", "WorkerId" },
                values: new object[] { 3, "03/01/2024", 1, 2, "Find a way to test if the application is durable to pressure.", "04/15/2024", 2100.00m, "Pressure Test", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assignees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
