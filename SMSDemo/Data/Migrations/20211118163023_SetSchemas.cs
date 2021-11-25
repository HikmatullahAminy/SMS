using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSDemo.Data.Migrations
{
    public partial class SetSchemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Stores_StoreId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Salles_Stores_StoreId",
                table: "Salles");

            migrationBuilder.DropIndex(
                name: "IX_Salles_StoreId",
                table: "Salles");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_StoreId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Salles");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Purchase");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Salles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Purchase",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salles_CourseId",
                table: "Salles",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CourseId",
                table: "Purchase",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Courses_CourseId",
                table: "Purchase",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salles_Courses_CourseId",
                table: "Salles",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Courses_CourseId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Salles_Courses_CourseId",
                table: "Salles");

            migrationBuilder.DropIndex(
                name: "IX_Salles_CourseId",
                table: "Salles");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_CourseId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Salles");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Purchase");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Salles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salles_StoreId",
                table: "Salles",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_StoreId",
                table: "Purchase",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Stores_StoreId",
                table: "Purchase",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salles_Stores_StoreId",
                table: "Salles",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
