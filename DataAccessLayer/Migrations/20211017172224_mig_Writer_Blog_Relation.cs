using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_Writer_Blog_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Writers",
                newName: "WriterId");

            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Blogs",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_WriterId",
                table: "Blogs",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Writers_WriterId",
                table: "Blogs",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Writers_WriterId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_WriterId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "WriterId",
                table: "Writers",
                newName: "Id");
        }
    }
}
