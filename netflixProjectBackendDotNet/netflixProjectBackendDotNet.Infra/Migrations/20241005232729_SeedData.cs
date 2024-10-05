using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace netflixProjectBackendDotNet.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "Id", "CreatedAt", "Name", "Order", "SecondsLong", "SerieId", "Synopsis", "ThumbnailUrl", "VideoUrl" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(3840), "Episode 1", 0, 325, 1, "This is the Episode 1", "/thumbnails/serie-7/hotd.jpg", "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4" },
                    { 2, new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(4006), "Episode 2", 1, 325, 1, "This is the Episode 2", "/thumbnails/serie-7/hotd.jpg", "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4" },
                    { 3, new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(4009), "Episode 3", 2, 325, 1, "This is the Episode 3", "/thumbnails/serie-7/hotd.jpg", "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4" },
                    { 4, new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(4010), "Episode 1", 0, 325, 7, "This is the Episode 1", "/thumbnails/serie-7/hotd.jpg", "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4" },
                    { 5, new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(4012), "Episode 1", 0, 325, 3, "This is the Episode 1", "/thumbnails/serie-7/hotd.jpg", "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4" },
                    { 6, new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(4018), "Episode 1", 0, 325, 2, "This is the Episode 1", "/thumbnails/serie-7/hotd.jpg", "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4" }
                });

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 5, 23, 27, 28, 721, DateTimeKind.Utc).AddTicks(9901));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(10));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(21));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 10, 5, 23, 27, 28, 721, DateTimeKind.Utc).AddTicks(5686), "$2a$12$Yy.Yal.jrqvAPlMDhUhKBOtRfQT5/LjIeYm329hgy2J0HSZR5WKsa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 31, 17, 40, 18, 111, DateTimeKind.Utc).AddTicks(567));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 31, 17, 40, 18, 111, DateTimeKind.Utc).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 31, 17, 40, 18, 111, DateTimeKind.Utc).AddTicks(707));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 31, 17, 40, 18, 111, DateTimeKind.Utc).AddTicks(708));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 31, 17, 40, 18, 111, DateTimeKind.Utc).AddTicks(710));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 31, 17, 40, 18, 111, DateTimeKind.Utc).AddTicks(726));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 31, 17, 40, 18, 111, DateTimeKind.Utc).AddTicks(728));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 31, 17, 40, 18, 111, DateTimeKind.Utc).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 31, 17, 40, 18, 111, DateTimeKind.Utc).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 8, 31, 17, 40, 18, 110, DateTimeKind.Utc).AddTicks(4606), "$2a$12$HlcWfVkbJLTIn0t/WYCpIOLPM71gaXWqKMesftq8ixYezPL50MeyK" });
        }
    }
}
