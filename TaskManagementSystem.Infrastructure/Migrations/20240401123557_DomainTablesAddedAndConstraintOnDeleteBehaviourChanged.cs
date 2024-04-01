using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Infrastructure.Migrations
{
    public partial class DomainTablesAddedAndConstraintOnDeleteBehaviourChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Assignee identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Assignee's phone"),
                    Gmail = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Assignee's Gmail, Must Be G-Mail, Regex Checked"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Task Category");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Task Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Task Title/Name"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Task Description"),
                    Paid = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Assignment Paid Upon Completion"),
                    Assigned = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Task Assigned Date"),
                    DoneBy = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Task Done By Date"),
                    AssigneeId = table.Column<int>(type: "int", nullable: false, comment: "Assignee identifier"),
                    WorkerId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "User id of the worker accepting the task"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Identifier For Task Category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Assignees_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Assignees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Task To Do");

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_UserId",
                table: "Assignees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssigneeId",
                table: "Assignments",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CategoryId",
                table: "Assignments",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Assignees");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
