using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Infrastructure.Migrations
{
    public partial class AdminPasswordCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15480979-8cbd-44cf-a085-f7e32c1b50f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a788dd77-3077-4ad3-ac5a-ceb3b2577eb0", null, "aeda1b32-64a1-425f-bcd0-016ab1504f48" });

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
        }
    }
}
