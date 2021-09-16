using Microsoft.EntityFrameworkCore.Migrations;

namespace gestion_des_formations_final.Migrations
{
    public partial class migration_four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Statut",
                table: "FormateurP",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statut",
                table: "FormateurP");
        }
    }
}
