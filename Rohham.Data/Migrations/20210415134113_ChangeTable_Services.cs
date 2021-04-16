using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rohham.Data.Migrations
{
    public partial class ChangeTable_Services : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Services",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Services",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "ServiceFiles",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "ServiceFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "ServiceFeatures",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "ServiceFeatures",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "ServiceFiles");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ServiceFeatures");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "ServiceFeatures");

            migrationBuilder.AlterColumn<int>(
                name: "Title",
                table: "Services",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Services",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "FileName",
                table: "ServiceFiles",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
