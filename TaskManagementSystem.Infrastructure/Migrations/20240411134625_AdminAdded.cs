using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Infrastructure.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7db6a2f-9385-4afc-aa55-ae1536d93e48");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b667c4cb-fc04-41d5-ac2f-35db7f3de91f", "AQAAAAEAACcQAAAAEH8siYaMxasyHPcq4tlrh5d+bLkw4hnGeGQy0lgaW/uphBC0mkcFa4TvogA8PLzT6w==", "dd88aa07-a552-4f65-8d6e-337f1c628162" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "251a495d-698d-4eb5-8f5a-c35faec2efda", "AQAAAAEAACcQAAAAEJADOnzmXiWwD3WHetDvqrNK8N9hIqP0LNI6E03ssfpkK/BMn3NDTBZOgVHhZeqeAQ==", "e440b1ca-80e1-4892-bac9-21105f3909a6" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "15480979-8cbd-44cf-a085-f7e32c1b50f2", 0, "a788dd77-3077-4ad3-ac5a-ceb3b2577eb0", "admin@mail.com", false, "Admin", "Adminov", false, null, "admin@MAIL.COM", "admin@MAIL.COM", null, null, false, "aeda1b32-64a1-425f-bcd0-016ab1504f48", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Assignees",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: "15480979-8cbd-44cf-a085-f7e32c1b50f2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15480979-8cbd-44cf-a085-f7e32c1b50f2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ee287af-f165-4801-b377-e41819bb3fe8", "AQAAAAEAACcQAAAAEC84SMQFLU4oQ+etNcNOWmR3EFNDKGPYrurXb5oIMAnA0PkbVUPc6cuIUN7slxGzQQ==", "3d3f8093-6dc7-4212-b720-064965d590d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02948a1b-0693-42ca-8b6b-c3cabe4c4c76", "AQAAAAEAACcQAAAAEIxJQ5L/g7Kd90WSWBkTd7boXlwXc3CLsEJ7SjGOTmncDopRvmYYUJxHni9JPix8sA==", "0ca8ab92-bd0e-4162-a9d5-84438577048e" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a7db6a2f-9385-4afc-aa55-ae1536d93e48", 0, "71292651-c99b-40ce-8953-ba65aa89ffb6", "admin@mail.com", false, "Admin", "Adminov", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEFM3jTFz/m2j0FLeR0uWPGRnNzfAlFDcZqqKXMX+V+qNkL4n88mSmvVg3ePWsCGCRA==", null, false, "7d4bcba1-8371-4347-ba6e-97b0344b568b", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Assignees",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: "a7db6a2f-9385-4afc-aa55-ae1536d93e48");
        }
    }
}
