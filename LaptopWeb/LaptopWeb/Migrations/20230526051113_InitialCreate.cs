using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trademarks",
                columns: table => new
                {
                    TrademarkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrademarkName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trademarks", x => x.TrademarkId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrademarkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    LaptopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price_real = table.Column<int>(type: "int", nullable: false),
                    series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    past_price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpu_compact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ram_compact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    memory_compact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    card = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    screen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    screen_compact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link_img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrademarkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.LaptopId);
                    table.ForeignKey(
                        name: "FK_Laptops_Trademarks_TrademarkId",
                        column: x => x.TrademarkId,
                        principalTable: "Trademarks",
                        principalColumn: "TrademarkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_TrademarkId",
                table: "Laptops",
                column: "TrademarkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Trademarks");
        }
    }
}
