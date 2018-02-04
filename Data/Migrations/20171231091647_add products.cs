using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace product.Data.Migrations
{
    public partial class addproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    CreaterId = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            
            migrationBuilder.CreateIndex(
                name: "IX_Products_CreaterId",
                table: "Products",
                column: "CreaterId");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropTable(
                name: "Products");

            
        }
    }
}
