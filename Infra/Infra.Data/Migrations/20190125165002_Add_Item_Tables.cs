using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class Add_Item_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "CategoryFieldTypes",
            //    nullable: false,
            //    oldClrType: typeof(Guid))
            //    .Annotation("Sqlite:Autoincrement", true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "CategoryId",
            //    table: "CategoryFields",
            //    nullable: true,
            //    oldClrType: typeof(Guid),
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "CategoryFieldTypeId",
            //    table: "CategoryFields",
            //    nullable: true,
            //    oldClrType: typeof(Guid),
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "CategoryFields",
            //    nullable: false,
            //    oldClrType: typeof(Guid))
            //    .Annotation("Sqlite:Autoincrement", true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Categories",
            //    nullable: false,
            //    oldClrType: typeof(Guid))
            //    .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FieldId = table.Column<int>(nullable: true),
                    FieldValue = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemValues_CategoryFields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "CategoryFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemValues_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemValues_FieldId",
                table: "ItemValues",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemValues_ItemId",
                table: "ItemValues",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemValues");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CategoryFieldTypes",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "CategoryFields",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryFieldTypeId",
                table: "CategoryFields",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CategoryFields",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Sqlite:Autoincrement", true);
        }
    }
}
