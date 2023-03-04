using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class seedTheTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "No Notes",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EpisodeType",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Episode Type",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1000, "Ahmad" },
                    { 1001, "Mohammad" },
                    { 1002, "Amr" },
                    { 1003, "Subhi" },
                    { 1004, "Rana" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "Susan Foreman", "Carole Ann Ford" },
                    { 2, "Polly", "Anneke Wills" },
                    { 3, "Liz Shaw", "Caroline John" },
                    { 7, "Mel Bush", "Bonnie Langford" },
                    { 12, "River Song", "Alex Kingston" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 200, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), "William Hartnell", 1, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 201, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), "Peter Capaldi", 2, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 202, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), "Jon Pertwee", 3, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 203, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), "Patrick Troughton", 4, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 204, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), "Sylvester McCoy", 5, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 100, "Armies are small armadillo enemies that appear in Donkey Kong Country and Donkey Kong Land.", "Army" },
                    { 101, "is a Koopa Troopa that has lost its shell and wears nothing more than an undershirt", "Beach Koopa" },
                    { 102, "also named Green Zingers and Buzzers", "Buzzes" },
                    { 103, "Croctopuses appear in blue and purple varieties, and their color scheme resembles the venomous blue-ringed octopus.", "Croctopus" },
                    { 104, "are heavy enemies found in Wario Land II", "Grunts" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 300, 1002, 200, new DateTime(1963, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "The Forest of Fear" },
                    { 301, 1000, 200, new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 3, "An Unearthly Child" },
                    { 302, 1001, 202, new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 241, 9, "The Time of the Doctor" },
                    { 303, 1003, 204, new DateTime(2014, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 8, "Deep Breath" },
                    { 304, 1004, 201, new DateTime(2013, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 275, 10, "The Doctor Falls" }
                });
            migrationBuilder.InsertData(
               table: "CompanionEpisode",
               columns: new[] { "EpisodesEpisodeId", "CompanionsCompanionId" },
               values: new object[,]
               {
                    { 301,2 },
                    { 302,12 },
                    { 301,1 },
                    { 304,7 },
                    { 303,3 }
               }
               );
            migrationBuilder.InsertData(
                table:"EnemyEpisode",
                columns: new[] { "EpisodesEpisodeId" , "EnemiesEnemyId"},
                values: new object[,]
                {
                    { 300, 101 },
                    { 301, 101 },
                    { 304, 103 },
                    { 302, 102 },
                    { 303, 100 }
                }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 204);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "No Notes");

            migrationBuilder.AlterColumn<string>(
                name: "EpisodeType",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Episode Type");
        }
    }
}
