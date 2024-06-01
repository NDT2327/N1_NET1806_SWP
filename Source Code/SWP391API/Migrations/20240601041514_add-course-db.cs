using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWP391API.Migrations
{
    /// <inheritdoc />
    public partial class addcoursedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Court",
                columns: table => new
                {
                    CourtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    OperatingHour = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PaymentInfor = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Court", x => x.CourtID);
                    table.ForeignKey(
                        name: "FK_Court_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Court_UserID",
                table: "Court",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Court");
        }
    }
}
