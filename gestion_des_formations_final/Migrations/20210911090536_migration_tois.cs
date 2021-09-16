using Microsoft.EntityFrameworkCore.Migrations;

namespace gestion_des_formations_final.Migrations
{
    public partial class migration_tois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialite",
                table: "FormateurP");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroCni",
                table: "FormateurP",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NiveauAcademique",
                table: "FormateurP",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Specialités",
                table: "FormateurP",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialités",
                table: "FormateurP");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCni",
                table: "FormateurP",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "NiveauAcademique",
                table: "FormateurP",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialite",
                table: "FormateurP",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
