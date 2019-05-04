using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelInfo.Api.DAL.Migrations
{
    public partial class DatabaseCreationAndInitDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    StarRating = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerSurname = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerName = table.Column<string>(maxLength: 50, nullable: true),
                    PaxNumber = table.Column<short>(nullable: false),
                    HotelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "Address", "Name", "StarRating" },
                values: new object[] { new Guid("45199a17-0d92-4c55-bcf9-1c9c99c931f1"), "Los Angeles, CA 90067, USA", "Nakatomi Tower Plaza", 5.0 });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "Address", "Name", "StarRating" },
                values: new object[] { new Guid("caeeea98-23c2-4e29-9550-7417123b0ea1"), "Second cloud on the left, Cloud City, Bespin System", "Cloud City Inn", 2.0 });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "Address", "Name", "StarRating" },
                values: new object[] { new Guid("fb5312f7-559a-4ddf-840a-353fa5b54f82"), "Somewhere in the transylvanian mountains, Romania", "Hotel Transylvania", 4.0 });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "CustomerName", "CustomerSurname", "HotelId", "PaxNumber" },
                values: new object[,]
                {
                    { new Guid("20790ead-e580-42db-af4e-54c126a02a7e"), "Hans", "Gruber", new Guid("45199a17-0d92-4c55-bcf9-1c9c99c931f1"), (short)2 },
                    { new Guid("c45ab61c-f957-4f14-8f86-e83f81829238"), "John", "McLane", new Guid("45199a17-0d92-4c55-bcf9-1c9c99c931f1"), (short)4 },
                    { new Guid("d60fbaec-00b5-409a-aa1c-46c969e6bfb1"), "Han", "Solo", new Guid("caeeea98-23c2-4e29-9550-7417123b0ea1"), (short)1 },
                    { new Guid("37bd242d-b39f-4593-9142-3614357a58c4"), "Luke", "Skywalker", new Guid("caeeea98-23c2-4e29-9550-7417123b0ea1"), (short)3 },
                    { new Guid("55852b8f-6bc9-4b2e-9768-8d918d2ac09e"), "Leia", "Organa", new Guid("caeeea98-23c2-4e29-9550-7417123b0ea1"), (short)1 },
                    { new Guid("3899fb02-83c3-46a7-8c4f-a1167a56a95d"), "-", "Count Dracula", new Guid("fb5312f7-559a-4ddf-840a-353fa5b54f82"), (short)2 },
                    { new Guid("f4945645-1ddb-4e2e-9a33-845562e8ad3c"), "-", "Frankenstein's Monster", new Guid("fb5312f7-559a-4ddf-840a-353fa5b54f82"), (short)2 },
                    { new Guid("cf4b082c-377c-4afd-baf7-038fac25c4fe"), "-", "The Wolfman", new Guid("fb5312f7-559a-4ddf-840a-353fa5b54f82"), (short)12 },
                    { new Guid("fe04cf9b-04d0-42d4-89e9-9233a314b82f"), "Jack", "Skellington", new Guid("fb5312f7-559a-4ddf-840a-353fa5b54f82"), (short)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_HotelId",
                table: "Booking",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Name",
                table: "Hotel",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
