using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebFinal.Service.Migrations
{
    /// <inheritdoc />
    public partial class takiGuncel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Takiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakiAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProfileImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takiler", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
            //        Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Locked = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedAd = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Giyimler",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CategoryId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Tur = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Giyimler", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Giyimler_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Giyimler_CategoryId",
        //        table: "Giyimler",
        //        column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Giyimler");

            migrationBuilder.DropTable(
                name: "Takiler");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
