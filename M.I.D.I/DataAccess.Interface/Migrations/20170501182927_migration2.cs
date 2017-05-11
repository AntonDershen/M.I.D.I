using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Interface.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "AlbumModelId",
                table: "MusicModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConvertedMusicModelId",
                table: "MusicModel",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "MusicModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "MusicModel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlbumModel",
                columns: table => new
                {
                    AlbumModelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumModel", x => x.AlbumModelId);
                });

            migrationBuilder.CreateTable(
                name: "ConvertedMusicModel",
                columns: table => new
                {
                    ConvertedMusicModelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConvertedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvertedMusicModel", x => x.ConvertedMusicModelId);
                });

            migrationBuilder.CreateTable(
                name: "NoteModel",
                columns: table => new
                {
                    NoteModelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Channel = table.Column<int>(nullable: false),
                    CommandCode = table.Column<int>(nullable: false),
                    ConvertedMusicModelId = table.Column<int>(nullable: true),
                    NoteNumber = table.Column<int>(nullable: false),
                    RealTime = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteModel", x => x.NoteModelId);
                    table.ForeignKey(
                        name: "FK_NoteModel_ConvertedMusicModel_ConvertedMusicModelId",
                        column: x => x.ConvertedMusicModelId,
                        principalTable: "ConvertedMusicModel",
                        principalColumn: "ConvertedMusicModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicModel_AlbumModelId",
                table: "MusicModel",
                column: "AlbumModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicModel_ConvertedMusicModelId",
                table: "MusicModel",
                column: "ConvertedMusicModelId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteModel_ConvertedMusicModelId",
                table: "NoteModel",
                column: "ConvertedMusicModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicModel_AlbumModel_AlbumModelId",
                table: "MusicModel",
                column: "AlbumModelId",
                principalTable: "AlbumModel",
                principalColumn: "AlbumModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicModel_ConvertedMusicModel_ConvertedMusicModelId",
                table: "MusicModel",
                column: "ConvertedMusicModelId",
                principalTable: "ConvertedMusicModel",
                principalColumn: "ConvertedMusicModelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicModel_AlbumModel_AlbumModelId",
                table: "MusicModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicModel_ConvertedMusicModel_ConvertedMusicModelId",
                table: "MusicModel");

            migrationBuilder.DropTable(
                name: "AlbumModel");

            migrationBuilder.DropTable(
                name: "NoteModel");

            migrationBuilder.DropTable(
                name: "ConvertedMusicModel");

            migrationBuilder.DropIndex(
                name: "IX_MusicModel_AlbumModelId",
                table: "MusicModel");

            migrationBuilder.DropIndex(
                name: "IX_MusicModel_ConvertedMusicModelId",
                table: "MusicModel");

            migrationBuilder.DropColumn(
                name: "AlbumModelId",
                table: "MusicModel");

            migrationBuilder.DropColumn(
                name: "ConvertedMusicModelId",
                table: "MusicModel");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "MusicModel");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "MusicModel");

            migrationBuilder.AddColumn<byte[]>(
                name: "ConvertedContent",
                table: "MusicModel",
                nullable: true);
        }
    }
}
