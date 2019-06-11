using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTemplate.Repository.EF.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SomeTestEntities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    SomeIntValue = table.Column<int>(nullable: false),
                    SomeStringValue = table.Column<string>(nullable: true),
                    SomeDateTimeValue = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SomeTestEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SomeTestEntities");
        }
    }
}
