using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SKS_Yonetim_Backend.Migrations
{
    /// <inheritdoc />
    public partial class secondchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AkadademikRol",
                table: "Kullanici");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AkadademikRol",
                table: "Kullanici",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
