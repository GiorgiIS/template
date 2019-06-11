using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTemplate.Repository.EF.Migrations
{
    public partial class datetimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SomeTestEntities",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SomeTestEntities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SomeTestEntities");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SomeTestEntities",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
