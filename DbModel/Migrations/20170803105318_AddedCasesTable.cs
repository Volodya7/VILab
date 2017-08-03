using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbModel.Migrations
{
    public partial class AddedCasesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Case_Subcategories_UnitId",
                table: "Case");

            migrationBuilder.DropTable(
                name: "CaseImg");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Case",
                table: "Case");

            migrationBuilder.RenameTable(
                name: "Case",
                newName: "Cases");

            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Cases",
                newName: "AfterImgUrl");

            migrationBuilder.RenameIndex(
                name: "IX_Case_UnitId",
                table: "Cases",
                newName: "IX_Cases_UnitId");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "BeforeImgUrl",
                table: "Cases",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Cases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubcategoryId",
                table: "Cases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Subname",
                table: "Cases",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cases",
                table: "Cases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Subcategories_UnitId",
                table: "Cases",
                column: "UnitId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Subcategories_UnitId",
                table: "Cases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cases",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "BeforeImgUrl",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Subname",
                table: "Cases");

            migrationBuilder.RenameTable(
                name: "Cases",
                newName: "Case");

            migrationBuilder.RenameColumn(
                name: "AfterImgUrl",
                table: "Case",
                newName: "ImgUrl");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_UnitId",
                table: "Case",
                newName: "IX_Case_UnitId");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Case",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Case",
                table: "Case",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CaseImg",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CaseId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseImg_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseImg_CaseId",
                table: "CaseImg",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Case_Subcategories_UnitId",
                table: "Case",
                column: "UnitId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
