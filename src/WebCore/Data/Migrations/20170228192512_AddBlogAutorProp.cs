using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCore.Data.Migrations
{
    public partial class AddBlogAutorProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Blog",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Blog",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Tilulo",
                table: "Blog",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Resumo",
                table: "Blog",
                maxLength: 300,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Blog");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Blog",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tilulo",
                table: "Blog",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Resumo",
                table: "Blog",
                nullable: true);
        }
    }
}
