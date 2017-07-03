using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbModel.Migrations
{
    public partial class ChangedStoringImgsInDBToUrlsInS3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "CaseImg");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Case");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Unit",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Subjects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "CaseImg",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Case",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "CaseImg");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Case");

            migrationBuilder.AddColumn<byte[]>(
                name: "Img",
                table: "Unit",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "Img",
                table: "Subjects",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "Img",
                table: "CaseImg",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "Img",
                table: "Case",
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
