using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gestion_des_formations_final.Migrations
{
    public partial class migration_first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAjout",
                table: "Certification",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModif",
                table: "Certification",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAjout",
                table: "Certification");

            migrationBuilder.DropColumn(
                name: "DateModif",
                table: "Certification");
        }
    }
}
