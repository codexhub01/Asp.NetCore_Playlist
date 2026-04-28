using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetCore_Playlist.Migrations
{
    /// <inheritdoc />
    public partial class seeemployeetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 10, "cse", "om@gmail.com", "Omkara" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
