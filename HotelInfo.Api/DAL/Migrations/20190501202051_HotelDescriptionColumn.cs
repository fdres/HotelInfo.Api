using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelInfo.Api.DAL.Migrations
{
    public partial class HotelDescriptionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Hotel",
                maxLength: 500,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "CustomerName", "CustomerSurname", "HotelId", "PaxNumber" },
                values: new object[] { new Guid("6ebc2ce2-8efb-41ae-ac21-539c4e3e8433"), "Darth", "Vader", new Guid("caeeea98-23c2-4e29-9550-7417123b0ea1"), (short)1 });

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("45199a17-0d92-4c55-bcf9-1c9c99c931f1"),
                column: "Description",
                value: "The one with the heist and all the murdering during Christmas '88");

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("caeeea98-23c2-4e29-9550-7417123b0ea1"),
                column: "Description",
                value: "The one where Darth Vader captured Han Solo and met with his son for the first time");

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("fb5312f7-559a-4ddf-840a-353fa5b54f82"),
                column: "Description",
                value: "The one where all the \"monsters\" gather to just relax and have some fun");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: new Guid("6ebc2ce2-8efb-41ae-ac21-539c4e3e8433"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Hotel");
        }
    }
}
