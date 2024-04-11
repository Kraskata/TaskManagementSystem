using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Infrastructure.Migrations
{
    public partial class IsApprovedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Assignments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is house approved by an admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15480979-8cbd-44cf-a085-f7e32c1b50f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b3780e4-8390-4e98-9b9a-7a499d455282", "AQAAAAEAACcQAAAAEEEOaPwlb3hCcxUcjEaVZzT7hhEiVdr4fFw2wKxQBlfzNSip5h1dKWVq7YJ5FtKIRA==", "22cc4e59-4511-466a-b3f3-7e8d68cfe716" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46fa260a-43c7-4777-b602-52db134a0b38", "AQAAAAEAACcQAAAAECzNcZI1IeqKzgvp5+l4FpQsJALft8uXkFB3Gq7wZRSIgX/b+iWXDJoZeTfnKyDQ6Q==", "65b441ab-69a6-427e-bc5b-c73f731e2072" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82bf0665-d36a-455f-be96-844f76625881", "AQAAAAEAACcQAAAAEBxXC+6eKbgR4Apgp19EqwxapshThcmKgguwVsn5K+svikz4mN73git7it7fMNTLuQ==", "9a3a1283-802b-42ae-91af-a1d3aeee2ffb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Assignments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15480979-8cbd-44cf-a085-f7e32c1b50f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "301a5080-bbd1-41e7-9c57-faf1b6bfd894", "AQAAAAEAACcQAAAAEPhjeoAUxyOuxN4VsJrE+4I/onKw8s4TyGPPAj6ImNMBIjCjb+KxtmEYsRIf8tKSTg==", "f91bfec4-ab7d-49f6-8362-3d7b8b37bad6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48a8e5f0-3980-4c30-a13b-8d291925dfbf", "AQAAAAEAACcQAAAAEKQps2cUlCbbF70YtWAnyjE++TGm+CG7fJaI3QXdDoVb7gkkixRUn2syxijISGv2Gg==", "edec942d-81ad-4217-881f-b9ec1e7d5253" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89f9e2d2-3fd0-4f9d-bb31-7ab0b27c2b84", "AQAAAAEAACcQAAAAECRUFexZFlv/qp/jkn6VjEmrzQ6x0OoS206RQThZizQhDqcDNKzejugeyfirl4aHww==", "4f247dc6-a5bc-47c1-a19d-bb3cfcd0b4cb" });
        }
    }
}
