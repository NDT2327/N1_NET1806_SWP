using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWP391API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    table.PrimaryKey("PK__Court__C3A67CFA1A3441D9", x => x.CourtID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__8AFACE3A9FA2D725", x => x.RoleID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Court");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
