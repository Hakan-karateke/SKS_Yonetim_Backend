using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SKS_Yonetim_Backend.Migrations
{
    /// <inheritdoc />
    public partial class changepasswordGuncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RandevuTipId",
                table: "Randevu",
                newName: "RandevuTurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RandevuTurId",
                table: "Randevu",
                newName: "RandevuTipId");
        }
    }
}
