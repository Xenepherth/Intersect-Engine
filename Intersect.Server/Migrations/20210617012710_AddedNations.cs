using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intersect.Server.Migrations
{
    public partial class AddedNations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DbNationId",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NationJoinDate",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Nations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FoundingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_DbNationId",
                table: "Players",
                column: "DbNationId");

            //migrationBuilder.AddForeignKey(
                //name: "FK_Players_Nations_DbNationId",
                //table: "Players",
                //column: "DbNationId",
                //principalTable: "Nations",
                //principalColumn: "Id",
                //onDelete: ReferentialAction.Restrict);
        }
    }
}
