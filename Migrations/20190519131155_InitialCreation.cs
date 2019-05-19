using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "api");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    DateOfDeath = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "api",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 300, nullable: false),
                    Descrition = table.Column<string>(maxLength: 600, nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "api",
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "api",
                table: "Author",
                columns: new[] { "Id", "Birthday", "DateOfDeath", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1969, 5, 31, 9, 11, 54, 801, DateTimeKind.Local).AddTicks(6989), new DateTime(2018, 5, 20, 9, 11, 54, 802, DateTimeKind.Local).AddTicks(9757), "Fake", "Author" });

            migrationBuilder.InsertData(
                schema: "api",
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Descrition", "Title" },
                values: new object[] { 1, 1, "The book represents a series of murders and homicides that have been made by some misterious Guy named Mr. Crazyand calls the attention of two young investigators named Tommy and Tuppence who try to stop him", "Misterious Mr. Crazy" });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                schema: "api",
                table: "Book",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book",
                schema: "api");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "api");
        }
    }
}
