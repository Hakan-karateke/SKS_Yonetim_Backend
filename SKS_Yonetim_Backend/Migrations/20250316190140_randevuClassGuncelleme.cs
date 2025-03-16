using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SKS_Yonetim_Backend.Migrations
{
    /// <inheritdoc />
    public partial class randevuClassGuncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaslangicDakika",
                table: "RandevuAlinmayacakSaat");

            migrationBuilder.DropColumn(
                name: "BaslangicSaat",
                table: "RandevuAlinmayacakSaat");

            migrationBuilder.DropColumn(
                name: "BitisDakika",
                table: "RandevuAlinmayacakSaat");

            migrationBuilder.DropColumn(
                name: "BaslangicDakika",
                table: "RandevuAlinanSaat");

            migrationBuilder.DropColumn(
                name: "BaslangicSaat",
                table: "RandevuAlinanSaat");

            migrationBuilder.DropColumn(
                name: "BitisDakika",
                table: "RandevuAlinanSaat");

            migrationBuilder.DropColumn(
                name: "BitisSaat",
                table: "RandevuAlinanSaat");

            migrationBuilder.RenameColumn(
                name: "BitisSaat",
                table: "RandevuAlinmayacakSaat",
                newName: "TekrarDurumu");

            migrationBuilder.RenameColumn(
                name: "RandevuTip",
                table: "Randevu",
                newName: "RandevuTipId");

            migrationBuilder.AlterColumn<string>(
                name: "RandevuYeriAdi",
                table: "RandevuYeri",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "RenkKodu",
                table: "RandevuTur",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BaslangicZamani",
                table: "RandevuAlinmayacakSaat",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BitisZamani",
                table: "RandevuAlinmayacakSaat",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BaslangicZamani",
                table: "RandevuAlinanSaat",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BitisZamani",
                table: "RandevuAlinanSaat",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "RandevuSuresi",
                table: "Randevu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RenkKodu",
                table: "RandevuTur");

            migrationBuilder.DropColumn(
                name: "BaslangicZamani",
                table: "RandevuAlinmayacakSaat");

            migrationBuilder.DropColumn(
                name: "BitisZamani",
                table: "RandevuAlinmayacakSaat");

            migrationBuilder.DropColumn(
                name: "BaslangicZamani",
                table: "RandevuAlinanSaat");

            migrationBuilder.DropColumn(
                name: "BitisZamani",
                table: "RandevuAlinanSaat");

            migrationBuilder.DropColumn(
                name: "RandevuSuresi",
                table: "Randevu");

            migrationBuilder.RenameColumn(
                name: "TekrarDurumu",
                table: "RandevuAlinmayacakSaat",
                newName: "BitisSaat");

            migrationBuilder.RenameColumn(
                name: "RandevuTipId",
                table: "Randevu",
                newName: "RandevuTip");

            migrationBuilder.AlterColumn<string>(
                name: "RandevuYeriAdi",
                table: "RandevuYeri",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "BaslangicDakika",
                table: "RandevuAlinmayacakSaat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaslangicSaat",
                table: "RandevuAlinmayacakSaat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BitisDakika",
                table: "RandevuAlinmayacakSaat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaslangicDakika",
                table: "RandevuAlinanSaat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaslangicSaat",
                table: "RandevuAlinanSaat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BitisDakika",
                table: "RandevuAlinanSaat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BitisSaat",
                table: "RandevuAlinanSaat",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
